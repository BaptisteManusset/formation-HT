using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
  [SerializeField] private SceneReference scene;
  public bool callOnEnable = false;


  private void Awake()
  {
    if (callOnEnable)
      SetScene();
  }


  [ContextMenu("Changer de scene")]
  public void SetScene()
  {
    SceneManager.LoadScene(scene);
  }

}
