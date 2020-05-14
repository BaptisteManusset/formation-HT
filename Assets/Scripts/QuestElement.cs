using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ItsBaptiste.QuestSystem
{
  [DisallowMultipleComponent]
  public class QuestElement : MonoBehaviour
  {
    public Step step;
    public int number;

    [Header("Effect")]
    public GameObject effect;

    bool isErrorNotAlreadyAppend = false;

    QuestOutline[] objectToHighlight;

    [Space(30)]public UnityEvent onQuestStart;
    public UnityEvent onQuestEnd;




    private void Awake()
    {
      objectToHighlight = GetComponentsInChildren<QuestOutline>();
    }

    private void Update()
    {
      if (step.isActif && step.isERROR && isErrorNotAlreadyAppend == false)
      {
        isErrorNotAlreadyAppend = true;
        StartCoroutine(CallError());
      }
    }

    public void TriggerError()
    {
      if (step.isActif && step.isERROR && isErrorNotAlreadyAppend == false)
      {
        isErrorNotAlreadyAppend = true;
        StartCoroutine(CallError());
      }
    }


    public IEnumerator CallError()
    {
      effect.SetActive(true);
      yield return new WaitForSeconds(4);

      QuestManager.instance.errorUi.SetActive(true);
      yield return new WaitForSeconds(5);
      PauseManager.instance.RestartLevel();
    }
    public void CompleteWithSucess()
    {
      QuestManager.CompleteStep();
    }

    public void CompleteWithError()
    {
      QuestManager.CompleteStepWithError();
    }

    private void Start()
    {
      if (step.next != null)
        step.next.step.previous = this;
    }

    public void ToggleHighlight(bool enable)
    {
      foreach (QuestOutline item in objectToHighlight)
      {
        if (enable)
        {
          item.EnableOutline();
        } else
        {
          item.DisableOutline();
        }
      }
    }


    private void OnDrawGizmos()
    {
      Color green = new Color(0.33f, 0.67f, 0.42f);

      Gizmos.color = (step == null ? Color.red : green);
      Gizmos.DrawWireSphere(transform.position, .015f); ;

      if (step.next)
        Debug.DrawLine(transform.position, step.next.transform.position);
      if (step.fail)
        Debug.DrawLine(transform.position, step.fail.transform.position, Color.red);
    }
  }
}

