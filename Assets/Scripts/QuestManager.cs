using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ItsBaptiste.QuestSystem
{

  [RequireComponent(typeof(AudioSource))]
  public class QuestManager : MonoBehaviour
  {



    #region singleton
    public static QuestManager instance;
    #endregion

    [Header("Initialisation")]
    public List<QuestElement> questElements;


    [HideInInspector] public List<QuestViewer> questViewers;


    [SerializeField] QuestElement firstStepElement;

    [Header("Etape Actuelle")]
    private QuestElement actualStepElement;

    public static bool isCompleted = false;

    public static int stepCount = 0;

    [Header("audio")]
    [SerializeField] AudioClip audioSucess;
    [SerializeField] AudioClip audioFail;
    AudioSource speaker;


    [Header("Error")]
    public GameObject errorUi;


    [Header("Finish")]
    public GameObject finishUi;
    public static bool isFinish = false;


    private void Awake()
    {
      if (instance == null)
      {
        instance = this;
      } else
      {
        Debug.LogError("Quest Manager allready exist");
      }

      speaker = GetComponent<AudioSource>();

      SetQuestElement(firstStepElement);




      #region count number of step
      foreach (QuestElement item in GameObject.FindObjectsOfType<QuestElement>())
      {
        questElements.Add(item);
      }



      int increment = 1;
      QuestElement temp = actualStepElement;

      do
      {
        temp.number = increment;
        temp = temp.step.next;
        increment++;
      } while (temp != null);
      stepCount = increment - 1;
      #endregion

      QuestManager.instance.UpdateUis();
    }



    /// <summary>
    /// fonction qui permet de completer l'etape et qui choisie l'etape suivante selon si l'etape actuelle est reussite ou non (gerer par le bool isFail)
    /// </summary>
    /// <param name="completeWithError">definie si la quete est reussie ou non</param>
    [ContextMenu("Completer l'étape")]
    public static void CompleteStep(bool completeWithError = false)
    {

      Debug.Log(QuestManager.instance.GetQuestElement().gameObject.name, QuestManager.instance.GetQuestElement().gameObject);

      Debug.DebugBreak();


      // verifie si une quest est definie
      if (QuestManager.instance.GetQuestElement() != null)
      {


        // si l'etape posséde une suite (next) & qu'elle n'est pas raté (isFail)
        // si l'etape posséde une suite raté (fail) & qu'elle est raté  (isFail)
        if ((QuestManager.instance.GetQuestElement().step.next != null && completeWithError == false) ||
            (QuestManager.instance.GetQuestElement().step.fail != null && completeWithError == true))
        {


          #region go to next step
          if (completeWithError == false)
          {
            QuestManager.instance.SetQuestElement(QuestManager.instance.GetQuestElement().step.next);

            #region audio
            PlaySound(QuestManager.instance.audioSucess);
            #endregion

          } else
          {
            QuestManager.instance.GetQuestElement().step.isfail = true;
            QuestManager.instance.SetQuestElement(QuestManager.instance.GetQuestElement().step.fail);
            QuestManager.instance.GetQuestElement().step.isfail = true;

            #region audio & Ui
            PlaySound(QuestManager.instance.audioFail);
            QuestManager.instance.errorUi.SetActive(true);

            #endregion




          }
          #endregion


        } else
        {
          QuestManager.instance.QuestIsFinish();
          QuestManager.instance.enabled = false;
        }
      }
    }


    /// <summary>
    /// complete l'etape actuelle avec une erreur
    /// </summary>
    [ContextMenu("Completer l'étape avec erreur")]
    public static void CompleteStepWithError()
    {
      CompleteStep(true);
      QuestManager.instance.UpdateUis();
    }


    private void QuestIsFinish()
    {
      foreach (var item in FindObjectsOfType<QuestOutline>())
      {
        item.DisableOutline();
      }

      isFinish = true;
      GetComponent<WinManager>().PlayWin();
    }




    /// <summary>
    /// mise a jours de tous les elements d'ui affichants les etapes
    /// </summary>
    private void UpdateUis()
    {
      foreach (var item in questViewers)
      {
        item.DisplayActual();
      }
    }


    /// <summary>
    /// retourne l'element qui contient l'etape actuelle
    /// </summary>
    /// <returns></returns>
    public QuestElement GetQuestElement()
    {
      return actualStepElement;
    }

    /// <summary>
    /// Definition de l'etape actuel de la quete et initilisation des variables d'etape
    /// </summary>
    /// <param name="elemen">nouvelle etape</param>
    public void SetQuestElement(QuestElement elemen)
    {
      #region previous step
      if (QuestManager.instance.GetQuestElement())
      {
        QuestManager.instance.GetQuestElement().step.isActif = false;
        QuestManager.instance.GetQuestElement().step.isComplete = true;
        QuestManager.instance.GetQuestElement().ToggleHighlight(false);
      }
      #endregion

      actualStepElement = elemen;
      #region editor
#if UNITY_EDITOR
      if (GetQuestElement())
        if (GetQuestElement().gameObject)
          Selection.objects = new GameObject[1] { GetQuestElement().gameObject };
      //Selection.objects = new GameObject[1] { GetQuestElement().gameObject };

#endif
      #endregion


      #region next step
      QuestManager.instance.GetQuestElement().step.isActif = true;
      QuestManager.instance.GetQuestElement().step.isComplete = false;
      QuestManager.instance.GetQuestElement().step.isfail = false;
      QuestManager.instance.UpdateUis();
      QuestManager.instance.GetQuestElement().ToggleHighlight(true);
      #endregion
    }

    #region editor
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
      if (GetQuestElement())
      {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(GetQuestElement().transform.position, .015f);
      }
    }
    public static void ResetStep()
    {
      foreach (var item in QuestManager.instance.questElements)
      {
        item.step.isActif = false;
        item.step.isComplete = false;
        item.step.isfail = false;
      }

      if (QuestManager.instance.firstStepElement == null) return;
      QuestManager.instance.SetQuestElement(QuestManager.instance.firstStepElement);
    }
    [ContextMenu("Open editor")]
    public void OpenEditor()
    {
      QuestEditor.OpenWindow();
    }

    private void OnGUI()
    {
      return;
      string ntm = "";

      ntm += GetQuestElement().number + "\n";
      ntm += GetQuestElement().gameObject.name + " ";
      ntm += GetQuestElement().step.title + "\n";
      ntm += GetQuestElement().step.description;

      GUI.Label(new Rect(10, 600, 1200, 600), ntm);
    }
#endif
    #endregion

    /// <summary>
    /// set the sound and play
    /// </summary>
    /// <param name="clip"></param>
    public static void PlaySound(AudioClip clip)
    {
      QuestManager.instance.speaker.PlayOneShot(clip);
    }
  }
}
