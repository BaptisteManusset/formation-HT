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

}
