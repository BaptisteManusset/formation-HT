using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[DisallowMultipleComponent]
public class QuestOutline : MonoBehaviour
{

  /**
   * Creer le Layer 9 avec pour nom "Outline"
   * puis dans Quality > le scriptable render pipeline settings
   * General > RenderList, ajouter une "Renderer Feature"
   *
   * Event                     = "After Rendering Opaques"
   * 
   * Filters > Queue           = "Opaque"
   * Filters > Layer Mask      = "Outline"
   * 
   * Overrides > Material      = (Le materiaux voulut) 
   * Overrides > Depth test    = Always 
   * 
   *
   * Ajouter une autre "Renderer Feature" memes parametre sauf
   * 
   * Event                     = "After Rendering Transparents"
   * Filters > Queue           = "Transparent"
   *
   *
   * ET VOILAA
 
           . `'.
       .`' ` * .
      :  *  *|  :
       ' |  || '
        `|~'||'
        v~v~v~v
        !@!@!@!
       _!_!_!_!_
      |  ||    ||
      |  ||   |||
      }{{{{}}}{{{
   */




  int originalLayer;

  [SerializeField] bool hideOnClick = false;
  [SerializeField] bool desactiveOnClick = false;
  void Awake()
  {
    originalLayer = gameObject.layer;

    if (gameObject.layer == 10)
    {
      Collider c = GetComponent<Collider>();
      if (c)
        c.isTrigger = true;
    }
  }

  [ContextMenu("Enable")]
  public void EnableOutline()
  {
    gameObject.layer = 9;
  }
  [ContextMenu("Disable")]
  public void DisableOutline()
  {
    gameObject.layer = originalLayer;
  }

  void OnMouseDown()
  {
    if (hideOnClick) DisableOutline();
    if (desactiveOnClick) gameObject.SetActive(false);
  }
}
