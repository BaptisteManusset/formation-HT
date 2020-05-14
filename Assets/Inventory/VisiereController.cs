using System.Collections;
using UnityEngine;

public class VisiereController : MonoBehaviour
{

  public static Animator anim;
  public static bool choose = false;
  public static VisiereController instance;

  public bool haveVisiere = false;
  void Start()
  {
    choose = false;
    instance = this;
    anim = GetComponent<Animator>();
    anim.SetTrigger("Open");
    transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
  }

  void Update()
  {
    if (haveVisiere)
    {
      if (Input.GetKeyDown(KeyCode.V))
      {
        anim.SetTrigger(choose ? "open" : "close");
        choose = !choose;
      }
    }
  }

  [ContextMenu("Get Visisere")]
  //j'avais pas d'idée de nom ¯\_(ツ)_/¯
  public void slt()
  {
    EnableVisiere();
  }

  public static void EnableVisiere()
  {
    instance.haveVisiere = true;
    instance.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
    anim.SetTrigger("Close");
  }

  public static bool VisiereIsDown()
  {
    return !choose;
  }

  #region editor
#if UNITY_EDITOR
  //private void OnGUI()
  //{
  //  GUI.Label(new Rect(600, 590, 100, 100), (haveVisiere ? "visiere: Ok" : "visiere: NOPE"));
  //  GUI.Label(new Rect(600, 600, 100, 100), (choose ? "La visiere est relevée" : "La visiere est baissée"));
  //}

#endif
  #endregion

}
