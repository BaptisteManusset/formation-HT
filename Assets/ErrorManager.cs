using ItsBaptiste.QuestSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorManager : MonoBehaviour
{

  [SerializeField] TextMeshProUGUI ui;
  [SerializeField] [Multiline] string formatting;
  Timer t;


  void OnEnable()
  {
    t = Timer.instance;
    t.errorCount++;

    Step step = QuestManager.instance.GetQuestElement().step;

    Debug.Log(step.title);
    Debug.Log(step.description);


    ui.text = string.Format(formatting, step.title, step.description, t.formattedTime, t.formattedTimeActual, t.count, t.errorCount);

  }

  /*
<size=300%>{0}</size>
<size=150%>{1}</size>

Temps Total : {2}
Temps Actuel: {3}
Nbr d'essaie: {4}
Nbr d'erreur: {5}

   */

}
