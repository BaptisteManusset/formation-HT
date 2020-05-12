using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;

namespace ItsBaptiste.QuestSystem
{
  public class QuestViewer : MonoBehaviour
  {

    [SerializeField] QuestElement stepToDisplay;

    [Header("UI")] [SerializeField] GameObject stepScreen;
    [SerializeField] TextMeshProUGUI texte;
    [SerializeField] TextMeshProUGUI count;

    [Space(10)] [SerializeField] GameObject errorScreen;
    [SerializeField] TextMeshProUGUI errorTexte;

    [Header("Buttons")] [SerializeField] Button previous;
    [SerializeField] Button actual;
    [SerializeField] Button next;
    [SerializeField] Image icon;
    [SerializeField] EventSystem eventSystem;






    [Header("Etats disponibles")] [SerializeField] QuestStat[] questStats;


    private void Start()
    {
      Subscribe();
      stepToDisplay = QuestManager.instance.GetQuestElement();
      UpdateUi();



    }
    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.LeftArrow))
      {
        if (stepToDisplay.step.previous != null)
          DisplayPrevious();
      }
      if (Input.GetKeyDown(KeyCode.RightArrow))
      {
        if (stepToDisplay.step.next != null)
          DisplayNext();
      }
      if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
      {

        DisplayActual();

      }
    }
    public void Subscribe()
    {
      QuestManager.instance.questViewers.Add(this);
      UpdateUi();
    }
    public void UpdateUi(QuestElement element = null)
    {


      if (stepToDisplay == null) stepToDisplay = QuestManager.instance.GetQuestElement();
      if (element != null) stepToDisplay = element;


      #region choose what screen to display
      //errorScreen.SetActive(stepToDisplay.step.isERROR);
      //stepScreen.SetActive(!stepToDisplay.step.isERROR);
      #endregion

      texte.text = UiNormalize(stepToDisplay.step.title, stepToDisplay.step.description);

      count.text = stepToDisplay.number + "/" + (QuestManager.stepCount);

      #region set the icon
      int stat = 3;

      if (stepToDisplay.step.isActif)
      {
        stat = 1;
      } else if (stepToDisplay.step.isComplete)
      {
        if (stepToDisplay.step.isfail)
        {
          stat = 2;
        } else
        {
          stat = 0;
        }
      }

      icon.sprite = questStats[stat].sprite;
      icon.color = questStats[stat].color;
      #endregion


      #region Buttons
      next.interactable = stepToDisplay.step.next == null ? false : true;
      previous.interactable = stepToDisplay.step.previous == null ? false : true;
      //actual.interactable = stepToDisplay == QuestManager.instance.GetQuestElement() ? false : true;
      eventSystem = GameObject.FindObjectOfType<EventSystem>();
      eventSystem.firstSelectedGameObject = actual.gameObject;

      #endregion


    }
    #region UI
    public void DisplayNext()
    {
      SetStepToDisplay(stepToDisplay.step.next);
      UpdateUi();
    }
    public void DisplayPrevious()
    {

      SetStepToDisplay(stepToDisplay.step.previous);
      UpdateUi();
    }
    public void DisplayActual()
    {
      UpdateUi(QuestManager.instance.GetQuestElement());
    }
    #endregion
    public void DisplayError(QuestElement elem)
    {
      errorTexte.text = UiNormalize(elem.step.title, elem.step.description);
    }
    public void HideError()
    {
      errorScreen.SetActive(false);
      DisplayActual();
    }
    private void SetStepToDisplay(QuestElement elem)
    {
      stepToDisplay = elem;
    }

    [System.Serializable]
    private class QuestStat
    {
      public string name;
      public Color color;
      public Sprite sprite;
    }
    private string UiNormalize(string title, string description)
    {
      string slt = $"<size=300%>{title}</size>\n";
      slt += $"{description}\n";

      return slt;
    }
  }
}
