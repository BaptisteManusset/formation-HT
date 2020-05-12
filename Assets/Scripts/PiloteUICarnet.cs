using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiloteUICarnet : MonoBehaviour
{
    public GameObject uiCarnet;
    private bool activeCarnet = false;

    private void Start()
    {
        uiCarnet.SetActive(activeCarnet);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (activeCarnet == false)
            {
                Debug.Log("Activation UI CARNET");
                activeCarnet = true;
                uiCarnet.SetActive(activeCarnet);
            }
            else if (activeCarnet == true)
            {
                Debug.Log("Désactivation UI CARNET");
                activeCarnet = false;
                uiCarnet.SetActive(activeCarnet);
            }
        }   
    }
}
