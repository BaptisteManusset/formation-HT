using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.Rendering.PostProcessing;

public class MenuManager : MonoBehaviour
{


  public static MenuManager instance;

  [Tooltip("Control if the menu trigger the pauseManager on show and hide")]
  [SerializeField] private bool togglePause = false;
  [SerializeField] private bool openOnStart = false;
  [SerializeField] private bool keepMenuOpen = false;

  [Header("Elements")]
  [SerializeField] private GameObject actifMenu;
  [SerializeField] private List<GameObject> menus;


  //[Header("Ui")] [SerializeField] private PostProcessVolume effects;





  private void Awake()
  {
    #region Singleton
    if (instance == null)
    {
      instance = this;
    } else
    {
      Debug.LogError("PauseManager already exist.");
      enabled = false;
    }
    #endregion

    #region Require
    if (!GameObject.FindObjectOfType<StandaloneInputModule>())
    {
      Debug.LogError("<color=red>StandaloneInputModule</color> in your scene is require");
    }
    #endregion

    for (int i = 0; i < transform.childCount; i++)
    {

      menus.Add(transform.GetChild(i).gameObject);
      menus[i].SetActive(false);
    }
  }
  private void Start()
  {
    if (openOnStart)
    {
      ShowTheMenu();
      PauseManager.DisablePause();
    } else
    {
      //if (effects) effects.enabled = false;
    }


  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (actifMenu == null)
      {
        ShowTheMenu();
      } else
      {

        //if is not the main menu open the main menu
        if (menus[0] == actifMenu)
        {
          if (actifMenu.activeSelf)
          {
            if (keepMenuOpen == false)
              HideMenu();
          } else
          {
            ShowTheMenu();
          }
        } else
        {
          //if you need to never close menu, show the main menu, else hide the menu
          if (keepMenuOpen)
          {
            ShowTheMenu();
          } else
          {
            HideMenu();
          }
        }
      }
    }
  }

  /// <summary>
  /// Hide the menu and disable pause if necessary
  /// </summary>
  public void HideMenu()
  {
    actifMenu.SetActive(false);
    actifMenu = null;
    if (togglePause)
      PauseManager.DisablePause();
    //if (effects) effects.enabled = false;

  }


  public void ShowTheMenu(GameObject menu = null)
  {

    if (menu == null) menu = menus[0];


    actifMenu = menu;

    foreach (var item in menus)
    {
      item.SetActive(false);
    }

    actifMenu.SetActive(true);

    StartCoroutine(SelectContinueButtonLater());
    

    if (togglePause)
      PauseManager.EnablePause();

    //if (effects) effects.enabled = true;
  }
  IEnumerator SelectContinueButtonLater()
  {
    Button slt = actifMenu.GetComponentsInChildren<Button>()[0];
    yield return null;
    FindObjectOfType<EventSystem>().SetSelectedGameObject(null);
    FindObjectOfType<EventSystem>().SetSelectedGameObject(slt.gameObject);
    Debug.Log(slt.gameObject.name);

  }

}
