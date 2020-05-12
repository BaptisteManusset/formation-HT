using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSacoche : MonoBehaviour
{
    public static Animator sacocheAnim;

    private void Start()
    {
        sacocheAnim = this.GetComponent<Animator>();
    }

    public static void SetOpenSacoche(bool choose)
    {
        sacocheAnim.SetBool("openSacoche", choose); 
    }
}
