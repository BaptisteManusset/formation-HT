using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using TMPro;

public class InventoryManager : MonoBehaviour
{


  [SerializeField] List<GameObject> boxes;
  [SerializeField] List<GameObject> itemsInInventory;

  int slt = 0;

  public static InventoryManager instance;

  private void Awake()
  {
    instance = this;

    transform.GetChild(0).gameObject.SetActive(false);

  }

  //Ajouter un objet
  public void AddObject(GameObject item)
  {
    Debug.Log(item.name);
    if (item.name == "Visiere" || item.name == "Visière") VisiereController.EnableVisiere();

    itemsInInventory.Add(item);

    boxes[slt].GetComponentInChildren<TextMeshPro>().text = item.gameObject.name;

    item.transform.parent = boxes[slt].transform;

    item.transform.localPosition = Vector3.zero;
    item.transform.rotation = Quaternion.identity;
    item.transform.localScale = Vector3.one * 2.5f;

    item.GetComponent<BoxCollider>().enabled = false;

    if (slt < boxes.Count)
      slt++;
  }

}
