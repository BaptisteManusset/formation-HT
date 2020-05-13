using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WinUi : MonoBehaviour
{
  [SerializeField] TextMeshProUGUI ui;
  [SerializeField] [TextArea] string formatting;
  Timer t;


  private void Start()
  {
    Cursor.lockState = CursorLockMode.Confined;
    if (t == null)
      t = Timer.instance;

    t.PauseTimer();
    ui.text = string.Format(formatting, t.formattedTime, t.formattedTimeActual, t.count, t.errorCount);

  }
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Escape))
    {
      GetComponent<ChangeScene>().SetScene();
    }
  }



  /*
<size=300%>Félicitation</size>
Vous avez reussie votre mission,
Temps Total  : {0}
Temps Actuel : {1}
Nbr d'essaie : {2}
Nbr d'erreur : {3}
   */
  /*

_______oBBBBB8o______oBBBBBBB 
_____o8BBBBBBBBBBB__BBBBBBBBB8________o88o, 
___o8BBBBBB**8BBBB__BB(0)B(0)BB_____oBBBBBBBo, 
__oBBBBBBB*___***___BBBB/_\BBBB_____BBBBBBBBBBo, 
_8BBBBBBBBBBooooo___*BBBBBBB8______*BB*_8BBBBBBo, 
_8BBBBBBBBBBBBBBBB8ooBBBBBBB8___________8BBBBBBB8, 
__*BBBBBBBBBBBBBBBBBBBBBBBBBB8_o88BB88BBBBBBBBBBBB, 
____*BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB8, 
______**8BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB*, 
___________*BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB8*, 
____________*BBBBBBBBBBBBBBBBBBBBBBBB8888**, 
_____________BBBBBBBBBBBBBBBBBBBBBBB*, 
_____________*BBBBBBBBBBBBBBBBBBBBB*, 
______________*BBBBBBBBBBBBBBBBBB8, 
_______________*BBBBBBBBBBBBBBBB*, 
________________8BBBBBBBBBBBBBBB8, 
_________________8BBBBBB()BBBBBBBo, 
__________________BBBBBBBBBBBBBBB8, 
__________________BBBBBBBBBBBBBBBB,
   */
}
