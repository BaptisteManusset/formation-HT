using UnityEngine;


namespace ItsBaptiste.QuestSystem
{
  [System.Serializable]
  public class Step
  {
    public string title = "Titre de l'étape";
    [TextArea]
    public string description = "Description de l'étape";


    public bool isActif = false;
    public bool isComplete = false;
    public bool isfail = false;
    public bool isERROR = false;

    [Header("Suite")] public QuestElement next;
    public QuestElement previous;
    public QuestElement fail;
  }
}



