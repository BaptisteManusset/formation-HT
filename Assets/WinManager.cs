using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{

  public GameObject finishUi;
  public GameObject[] lights;
  public void PlayWin()
  {
    StartCoroutine(animation());
  }

  private IEnumerator animation()
  {
    yield return new WaitForSeconds(5f);
    foreach (var item in lights)
    {
      item.SetActive(true);
    }
    yield return new WaitForSeconds(5f);
    finishUi.SetActive(true);
  }
}
