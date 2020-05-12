using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

  public static PauseManager instance;


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
  }





  private static bool isPaused = false;

  public static bool IsPaused { get => isPaused; set => isPaused = value; }



  [ContextMenu("Enable Pause")]
  public static void EnablePause()
  {
    Time.timeScale = 0f;
    IsPaused = true;
  }

  [ContextMenu("Disable Pause")]
  public static void DisablePause()
  {
    Time.timeScale = 1.0f;
    IsPaused = false;
  }

  public void RestartLevel()
  {
    Debug.Log("<color=purple>TODO: Add call to script necessary for the reload</color>");

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    DisablePause();
  }


}
