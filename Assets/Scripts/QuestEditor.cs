#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ItsBaptiste.QuestSystem
{
  public class QuestEditor : EditorWindow
  {

    int toolbarInt = 0;
    string[] toolbarStrings = { "Cheat C0de", "Coucou", "Nannii ??!!?" };



    [MenuItem("Window/QuestEditor")]
    public static void OpenWindow()
    {
      GetWindow<QuestEditor>("Quest editor");
    }

    private void OnGUI()
    {

      toolbarInt = GUILayout.Toolbar(toolbarInt, toolbarStrings);
      switch (toolbarInt)
      {
        case 0:
          if (GUILayout.Button("Etape suivante", GUILayout.MinHeight(50)))
          {
            QuestManager.CompleteStep();
          }
          if (GUILayout.Button("Erreur", GUILayout.MinHeight(50)))
          {
            QuestManager.CompleteStepWithError();
          }
          if (GUILayout.Button("Reset Step", GUILayout.MinHeight(50)))
          {
            QuestManager.ResetStep();
          }




          break;
        //case 1:
          /*EditorGUILayout.BeginHorizontal();
          previousElement = EditorGUILayout.ObjectField(previousElement, typeof(QuestElement), true, GUILayout.MinHeight(50)) as QuestElement;

          EditorGUILayout.LabelField("==>");

          actualElement = EditorGUILayout.ObjectField(actualElement, typeof(QuestElement), true, GUILayout.MinHeight(50)) as QuestElement;
          EditorGUILayout.EndHorizontal();

          //if (GUILayout.Button("Lier les deux étapes", GUILayout.MinHeight(50)))
          //{

          //  previousElement.quest.nextStep = actualElement.quest;


          //}


          break;
        case 2:
          //#region creer une etape
          //if (GUILayout.Button("Creer un Gameobject Etape"))
          //{


          //  #region init
          //  GameObject go = new GameObject();
          //  if (go == null) return;
          //  go.name = "Quest Element";
          //  #endregion

          //  if (Selection.activeGameObject != null)
          //    go.transform.position = Selection.activeGameObject.transform.position;
          //  Selection.activeGameObject = go;

          //  QuestElement questElement = Selection.activeGameObject.AddComponent<QuestElement>();
          //  questElement.quest = CreateSCriptableObject();


          //}
          //#endregion       
          //#region Lier deux etapes
          //foldoutOpen = EditorGUILayout.Foldout(foldoutOpen, "Lier deux etapes");
          //if (foldoutOpen)
          //{
          //  EditorGUILayout.LabelField("Etape précédente");
          //  previousElement = EditorGUILayout.ObjectField(previousElement, typeof(QuestElement), true) as QuestElement;



          //  if (GUILayout.Button("Lier deux etapes"))
          //  {
          //    QuestElement element = Selection.activeGameObject.GetComponent<QuestElement>();

          //    //if (element)
          //    //  element.SetPreviousQuestElement(previousElement);

          //    previousElement.SetNextQuestElement(element);
          //    EditorGUILayout.Space();
          //  }
          //}
          //#endregion
          //#region Add Step
          //if (GUILayout.Button("Ajouter une ScriptableObj etape"))
          //{
          //  QuestElement element = Selection.activeGameObject.GetComponent<QuestElement>();

          //  if (element)
          //  {
          //    if (element.quest == null)
          //      element.quest = CreateSCriptableObject();
          //  }

          //  EditorGUILayout.Space();
          //}

          //#endregion
          break;*/
      }
    }





    public void OnInspectorUpdate()
    {
      this.Repaint();
    }
  }
}
#endif