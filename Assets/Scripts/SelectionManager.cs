using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ItsBaptiste.QuestSystem;

public class SelectionManager : MonoBehaviour
{

  #region Variables DragAndDrop
  public GameObject tempParent;
  public Transform guide;
  public GameObject lampe;
  public GameObject lampeMoving;
  private bool grab = false;
  private bool isMoving = false;

  #endregion

  #region Variables Raycast
  [Header("Variables Raycast")]
  private GameObject raycastedObj;
  [SerializeField] private int rayLength = 10;
  [SerializeField] private LayerMask layerMaskInteract;
  #endregion

  #region Variables UI Raycast
  [Header("Variables UI Raycast")]
  [SerializeField] private Image uiCrossHair;
  public Text commentary;
  public GameObject parentCommentary;
  #endregion

  #region Variables Inventaire 
  [Header("Variables inventaire")]
  [SerializeField] GameObject list; //Inventaire
  [SerializeField] GameObject objectsList;//Inventaire (UI)
  [SerializeField] GameObject button; //Bouton / Item
  ItemScript item;
  GameObject actualButton = null;
  private bool closeSacoche = true;
  public GameObject inventary;
  #endregion

  #region Variables Pilotes des portes
  private Vector3 turnDoor = new Vector3(0, 90, 0);
  private bool openDoor1 = false;
  private bool openDoor2 = false;
  #endregion

  #region  Variables Quête 1
  [System.Serializable]
  public class DoorsQuestOne
  {
    public GameObject doorQuestOne;
    public bool open = false;
  }
  [Header("Variables Quête 1")]
  public DoorsQuestOne[] listDoors;
  private int nbDoorsOpen;
  public QuestElement validQuest1;
  #endregion

  #region Variables Quête 2
  [System.Serializable]
  public class SwitchsQuestOne
  {
    public GameObject switchQuestTwo;
    public bool verif = false;
  }
  [Header("Variables Quête 2")]
  public SwitchsQuestOne[] listSwitchs;
  private int nbSwitchsDown;
  public QuestElement validQuest2;
  public GameObject[] listSwitchLastQuest;
  #endregion

  #region Variables Quête 3
  [Header("Variables Quête 3")]
  public GameObject bar;
  private bool barNoActive = true;
  public QuestElement validQuest3;
  #endregion

  #region Variables Quête 4
  [Header("Variables Quête 4")]
  public QuestElement validQuest4;
  #endregion

  #region Variables Quête 5
  [Header("Variables Quête 5")]
  public QuestElement validQuest5;
  private int nbEPI = 0;
  public Text payAttention;
  public GameObject parentPayAttention;
  #endregion

  #region Variables Quête 6
  [Header("Variables Quête 6")]
  public QuestElement validQuest6;
  public GameObject table;
  public GameObject tableFantome;
  #endregion

  #region Variables Quête 7
  [Header("Variables Quête 7")]
  public GameObject bar2;
  public QuestElement validQuest7;
  private bool bar2NoActive = true;
  #endregion

  #region Variables Quête 8
  [Header("Variables Quête 8")]
  public QuestElement validQuest8;
  #endregion

  #region Variables Quête 9
  [Header("Variables Quête 9")]
  public QuestElement validQuest9;
  public GameObject cleQuestNine;
  #endregion

  #region Variables Quête 10
  [Header("Variables Quête 10")]
  public GameObject barFantome;
  public GameObject barDeFer;
  public QuestElement validQuest10;
  private Vector3 barPosition;
  #endregion

  #region Variables Quête 11
  [Header("Variables Quête 11")]
  public QuestElement validQuest11;
  public Vector3 turnLocket = new Vector3(0, 90, 0);
  #endregion

  #region Variables Quête 12
  [Header("Variables Quête 12")]
  public QuestElement validQuest12;
  public GameObject levier;
  #endregion

  #region Variables Quête 13
  [Header("Variables Quête 13")]
  public GameObject levierFantome;
  public QuestElement validQuest13;
  #endregion

  #region Variables Quête 14
  [Header("Variables Quête 14")]
  public QuestElement validQuest14;
  #endregion

  #region Variables Quête 15
  [Header("Variables Quête 15")]
  public QuestElement validQuest15;
  public GameObject cleQuestFifteen;
  public GameObject levierFantome2;
  public GameObject barError;
  #endregion

  #region Variables Quête 16
  [Header("Variables Quête 16")]
  public QuestElement validQuest16;
  public GameObject greenButton;
  public Vector3 moveForwardButtton = new Vector3(0, 2, 0);

  #endregion

  #region Variables Quête 17
  [Header("Variables Quête 17")]
  public QuestElement validQuest17;
  public GameObject tableFantome2;
  #endregion

  #region Variables Quête 18
  [Header("Variables Quête 18")]
  public QuestElement validQuest18;
  public GameObject keyQuestHeighteen;
  #endregion

  #region Variables Quête 19
  [Header("Variables Quête 19")]
  public QuestElement validQuest19;
  private Vector3 barPosition2;
  public GameObject barFantome2;
  public GameObject barDeFer2;
  #endregion

  #region Variables Quête 20
  [Header("Variables Quête 20")]
  public QuestElement validQuest20;
  public Vector3 turnLocket2 = new Vector3(0, 90, 0);
  #endregion

  #region Variables Quête 21
  [Header("Variables Quête 21")]
  public QuestElement validQuest21;
  public GameObject tableFantome3;
  #endregion

  #region Variables Quête 22
  [Header("Variables Quête 22")]
  public GameObject bar3;
  private bool barNoActive2 = true;
  public QuestElement validQuest22;
  #endregion

  #region Variables Quête 23
  [Header("Variables Quête 23")]
  public QuestElement validQuest23;
  #endregion

  #region Variables Quête 24
  [Header("Variables Quête 24")]
  public QuestElement validQuest24;
  private Vector3 barPosition3;
  public GameObject barFantome3;
  public GameObject barDeFer3;
  #endregion

  #region Variables Quête 25
  [Header("Variables Quête 25")]
  public QuestElement validQuest25;
  #endregion

  #region Variables Quête 26
  [Header("Variables Quête 26")]
  public QuestElement validQuest26;
  public GameObject tableFantome4;
  #endregion

  #region Variables Quête 27
  [Header("Variables Quête 27")]
  private bool barNoActive3 = true;
  public GameObject bar4;
  public QuestElement validQuest27;
  #endregion

  #region Variables Quête 28
  [Header("Variables Quête 28")]
  public QuestElement validQuest28;
  #endregion

  #region Variables Quête 29
  [Header("Variables Quête 29")]
  public QuestElement validQuest29;
  private Vector3 barPosition4;
  public GameObject barFantome4;
  public GameObject barDeFer4;
  #endregion

  #region Variables Quête 30
  [Header("Variables Quête 30")]
  public QuestElement validQuest30;
  #endregion

  #region Variables Quête 31
  [Header("Variables Quête 31")]
  public GameObject keyQuestThirtyOne;
  public QuestElement validQuest31;
  #endregion

  #region Variables Quête 32
  [Header("Variables Quête 32")]
  public GameObject mani1;
  public GameObject maniBase1;
  public QuestElement validQuest32;
  #endregion

  #region Variables Quête 33
  [Header("Variables Quête 33")]
  public GameObject keyQuestThirtyThree;
  public QuestElement validQuest33;
  #endregion

  #region Variables Quête 34
  [Header("Variables Quête 34")]
  public GameObject mani2;
  public GameObject maniBase2;
  public QuestElement validQuest34;
  #endregion

  #region Variables Quête 35
  [System.Serializable]
  public class SwitchsQuestThirtyFive
  {
    public GameObject switchQuestThirtyFive;
    public bool up = false;
  }
  [Header("Variables Quête 35")]
  public SwitchsQuestThirtyFive[] listSwitchs2;
  private int nbSwitchsDown2;
  public Vector3 turnDisjonc = new Vector3(0, -60, 0);
  public QuestElement validQuest35;
  #endregion

  private void Start()
  {
    nbDoorsOpen = 0;
    nbSwitchsDown = 0;
  }

  // Update is called once per frame
  void Update()
  {
    RemoveAndResetLamp();

    #region ! Vérification de la validation des différentes quêtes !

    #region Quête 1
    if (nbDoorsOpen == 4 && validQuest1.GetComponent<QuestElement>().step.isComplete == false)
    {
      Debug.Log("Objectif Réussi Quest One");
      //validQuest1.GetComponent<QuestElement>().CompleteWithSucess();

      QuestManager.CompleteStep();
    }
    #endregion

    #region Quête 2
    if (nbSwitchsDown == 2 && validQuest2.GetComponent<QuestElement>().step.isComplete == false)
    {
      Debug.Log("Objectif Réussi Quest Two");
      validQuest2.GetComponent<QuestElement>().CompleteWithSucess();
      for (int i = 0; i < listSwitchs.Length; i++) // Switch les disjoncteurs avec d'autre pour changer le tag
      {
        listSwitchs[i].switchQuestTwo.SetActive(false);
      }
      for (int i = 0; i < listSwitchLastQuest.Length; i++)
      {
        listSwitchLastQuest[i].gameObject.SetActive(true);
      }
    }
    #endregion

    #region Quête 3
    if (barNoActive == false && validQuest3.GetComponent<QuestElement>().step.isComplete == false)
    {
      Debug.Log("Objectif Réussi Quest Three");
      validQuest3.GetComponent<QuestElement>().CompleteWithSucess();
    }
    #endregion

    #region Quête 4
    //Gérer dans le switch
    #endregion

    #region Quête 5

    if (nbEPI == 3 && validQuest5.GetComponent<QuestElement>().step.isComplete == false)
    {
      validQuest5.GetComponent<QuestElement>().CompleteWithSucess();
    }
    #endregion

    #region Quête 6
    //Gérer dans le switch
    #endregion

    #region Quête 7
    if (bar2NoActive == false && validQuest7.GetComponent<QuestElement>().step.isComplete == false)
    {
      Debug.Log("Objectif Réussi Quest Seven");
      validQuest7.GetComponent<QuestElement>().CompleteWithSucess();
    }
    #endregion

    #region Quête 8
    //Gérer dans le switch
    #endregion

    #region Quête 9 
    //Gérer dans le switch
    #endregion

    #region Quête 10
    //Gérer dans le switch
    #endregion

    #region Quête 11
    //Gérer dans le switch
    #endregion

    #region Quête 12
    //Gérer dans le switch
    #endregion

    #region Quête 13
    //Gérer dans le switch
    #endregion

    #region Quête 14
    //Gérer dans le switch
    #endregion

    #region Quête 15
    //Gérer dans le switch
    #endregion

    #region Quête 16
    //Gérer dans le switch
    #endregion

    #region Quête 17
    //Gérer dans le switch
    #endregion

    #region Quête 18
    //Gérer dans le switch
    #endregion

    #region Quête 19
    //Gérer dans le switch
    #endregion

    #region Quête 20
    //Gérer dans le switch
    #endregion

    #region Quête 21
    //Gérer dans le switch
    #endregion

    #region Quête 22
    //Gérer dans le switch
    #endregion

    #region Quête 23
    //Gérer dans le switch
    #endregion

    #region Quête 24
    //Gérer dans le switch
    #endregion

    #region Quête 25
    //Gérer dans le switch
    #endregion

    #region Quête 26
    //Gérer dans le switch
    #endregion

    #region Quête 27
    //Gérer dans le switch
    #endregion

    #region Quête 28
    //Gérer dans le switch
    #endregion

    #region Quête 29
    //Gérer dans le switch
    #endregion

    #region Quête 30
    //Gérer dans le switch
    #endregion

    #region Quête 31
    //Gérer dans le switch
    #endregion

    #region Quête 32
    //Gérer dans le switch
    #endregion

    #region Quête 33
    //Gérer dans le switch
    #endregion

    #region Quête 34
    //Gérer dans le switch
    #endregion

    #region Quête 35
    if (nbSwitchsDown2 == 2 && validQuest35.GetComponent<QuestElement>().step.isComplete == false)
    {
      Debug.Log("Objectif Réussi Quest Thirty Five");
      validQuest35.GetComponent<QuestElement>().CompleteWithSucess();
    }
    #endregion

    #endregion

    RaycastHit hit;
    Vector3 fwd = transform.TransformDirection(Vector3.forward);
    Debug.DrawRay(transform.position, fwd, Color.green);
    if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
    {
      switch (hit.collider.tag)
      {

        #region Fini

        case "Lampe": // Gère le drag and drop de la lampe

          #region Lampe
          if (grab == false)
          {
            CrosshairActive();
            parentCommentary.SetActive(true);
            commentary.text = "Clique gauche pour récupérer la lampe";
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              grab = true;
              isMoving = true;
              hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
              hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
              hit.collider.gameObject.transform.position = guide.transform.position;
              hit.collider.gameObject.transform.rotation = guide.transform.rotation;
              hit.collider.gameObject.transform.parent = tempParent.transform;

              lampeMoving.transform.position = hit.collider.gameObject.transform.position;
              lampeMoving.transform.rotation = hit.collider.gameObject.transform.rotation;
            }
          } else if (grab == true)
          {
            CrosshairActive();
            parentCommentary.SetActive(true);
            commentary.text = "Clique droit pour lâcher la lampe";

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
              grab = false;
              //hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
              hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
              hit.collider.gameObject.transform.parent = null;
              hit.collider.gameObject.transform.position = guide.transform.position;
            }
          }
          #endregion

          break;


        case "Door1": // Gère la porte 1 ouverture / fermeture

          #region Door1
          HoverCrosshair("Porte", hit.collider.gameObject);
          if (Input.GetKeyDown(KeyCode.Mouse0))
          {
            if (openDoor1 == false)
            {
              //Debug.Log("Open the door 1");
              raycastedObj.transform.Rotate(-turnDoor);
              openDoor1 = true;
            } else if (openDoor1 == true)
            {
              //Debug.Log("Close the door 1");
              raycastedObj.transform.Rotate(turnDoor);
              openDoor1 = false;
            }
          }
          #endregion

          break;

        case "Door2":// Gère la porte 2 ouverture / fermeture

          #region Door2
          HoverCrosshair("Porte", hit.collider.gameObject);
          if (Input.GetKeyDown(KeyCode.Mouse0))
          {
            if (openDoor2 == false)
            {
              //Debug.Log("Open the door 2");
              raycastedObj.transform.Rotate(turnDoor);
              openDoor2 = true;
            } else if (openDoor2 == true)
            {
              //Debug.Log("Close the door 2");
              raycastedObj.transform.Rotate(-turnDoor);
              openDoor2 = false;
            }
          }
          #endregion

          break;

        case "Object":// Gère les Objets récupérables de la scène

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region Object
            HoverCrosshair(hit.collider.gameObject.name, hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              InventoryManager.instance.AddObject(hit.collider.gameObject);
            }
            #endregion
          }
          break;

        case "Sacoche":// Gère l'inventaire

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region Sacoche
            HoverCrosshair("Inventaire", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              if (closeSacoche == true)
              {
                AnimationSacoche.SetOpenSacoche(true);
                inventary.SetActive(true);
                closeSacoche = false;
              } else if (closeSacoche == false)
              {
                AnimationSacoche.SetOpenSacoche(false);
                inventary.SetActive(false);
                closeSacoche = true;
              }
            }
            #endregion
          }
          break;

        case "DoorQuestOne":// Gère les portes de la première quête

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region DoorQuestOne
            HoverCrosshair("Porte armoire", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              for (int i = 0; i < listDoors.Length; i++)
              {
                if (listDoors[i].doorQuestOne.gameObject == raycastedObj)
                {
                  if (listDoors[i].open == false)
                  {
                    raycastedObj.transform.Rotate(-turnDoor);
                    nbDoorsOpen += 1;
                    listDoors[i].open = true;
                  } else if (listDoors[i].open == true)
                  {
                    raycastedObj.transform.Rotate(turnDoor);
                    nbDoorsOpen -= 1;
                    listDoors[i].open = false;
                  }
                }
              }
            }
            #endregion
          }
          break;

        case "SwitchQuestTwo":// Gère les interrupteurs de la quête 2

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region SwitchQuestTwo
            if (validQuest1.GetComponent<QuestElement>().step.isComplete == false || validQuest2.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Disjoncteur à vérifier", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              for (int i = 0; i < listSwitchs.Length; i++)
              {
                if (listSwitchs[i].switchQuestTwo.gameObject == raycastedObj)
                {
                  if (listSwitchs[i].verif == false)
                  {
                    nbSwitchsDown += 1;
                    listSwitchs[i].verif = true;
                  }
                }
              }
            }
            #endregion
          }

          break;

        case "BarQuestThree": // Gère la barre de terre de la quête 3

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region BarQuestThree
            if (validQuest2.GetComponent<QuestElement>().step.isComplete == false || validQuest3.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Barre de Terre", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              if (barNoActive == true)
              {
                bar.GetComponent<Animator>().SetBool("baisseTerre", true);
                barNoActive = false;
              }
            }
            #endregion
          }

          break;

        case "KeyQuestFour": // Gère la récupération de la clé de la quête 4

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region KeyQuestFour
            if (validQuest3.GetComponent<QuestElement>().step.isComplete == false)
            {
              return;
            }
            HoverCrosshair("Clé X1", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              InventoryManager.instance.AddObject(hit.collider.gameObject);
              Debug.Log("Objectif Réussi Quest Four");
              validQuest4.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "EPIQuestFive": // Gère la récupération des EPI de la quête 5

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region EPIQuestFive
            if (validQuest4.GetComponent<QuestElement>().step.isComplete == false)
            {
              return;
            }
            HoverCrosshair(hit.collider.name, hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              if (hit.collider.gameObject.name == "Visiere")
              {
                Debug.Log("On rentre dans la chatte a ta grosse mere");
                InventoryManager.instance.AddObject(hit.collider.gameObject);
                VisiereController.EnableVisiere();
                nbEPI = nbEPI + 1;
              } else
              {
                InventoryManager.instance.AddObject(hit.collider.gameObject);
                nbEPI = nbEPI + 1;
              }
            }
            #endregion
          }

          break;

        case "EPIFalse":

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region EPIFalse
            if (validQuest4.GetComponent<QuestElement>().step.isComplete == false)
            {
              return;
            }
            HoverCrosshair(hit.collider.name, hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              Debug.Log("Gants troués check");
              StartCoroutine(ErrorGants());

            }
            #endregion
          }

          break;

        case "TableQuestSix": // Gère la récupération du tabouret de la quête 6

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region TableQuestSix
            if (validQuest5.GetComponent<QuestElement>().step.isComplete == false || validQuest6.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Tabouret", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              table.SetActive(false);
              tableFantome.SetActive(true);
              validQuest6.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "BarQuestSeven": // Gère la barre de terre de la quête 7

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region BarQuestSeven
            if (validQuest6.GetComponent<QuestElement>().step.isComplete == false || validQuest7.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Barre de Terre", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              if (bar2NoActive == true)
              {
                bar2.GetComponent<Animator>().SetBool("baisseTerre", true);
                bar2NoActive = false;
              }
            }
            #endregion
          }

          break;

        case "KeyQuestHeight": // Gère la récupération de la clé de la quête 8

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region KeyQuestHeight
            if (validQuest7.GetComponent<QuestElement>().step.isComplete == false)
            {
              return;
            }
            HoverCrosshair("Clé Q2", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              InventoryManager.instance.AddObject(hit.collider.gameObject);
              Debug.Log("Objectif Réussi Quest Height");
              validQuest8.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "InsertQuestNine": // Gère l'insertion de la clé X1 de la quête 9

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region InsertQuestNine
            if (validQuest8.GetComponent<QuestElement>().step.isComplete == false || validQuest9.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Insérer clé X1", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              Debug.Log("Objectif Réussi Quest Nine");
              validQuest9.GetComponent<QuestElement>().CompleteWithSucess();
              cleQuestNine.SetActive(true);
            }
            #endregion
          }

          break;

        case "BarQuestTen": // Gère la récupération de la barre de la quête 10

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region BarQuestTen
            if (validQuest9.GetComponent<QuestElement>().step.isComplete == false || validQuest10.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }

            HoverCrosshair("Récupérer la barre de fer", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              barDeFer.SetActive(false);

              Debug.Log("Objectif Réussi Quest Ten");
              validQuest10.GetComponent<QuestElement>().CompleteWithSucess();

            }
            #endregion
          }

          break;

        case "UseBarQuestEleven": // Gère l'utilisation de la barre de la quête 11

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region UseBarQuestEleven
            if (validQuest10.GetComponent<QuestElement>().step.isComplete == false || validQuest11.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Utiliser la barre de fer", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              hit.collider.gameObject.transform.Rotate(turnLocket);
              barFantome.SetActive(true);
              StartCoroutine(GoToBeginIronBar(hit.collider.gameObject, barFantome, barDeFer, "baisseBarDeFer", turnLocket));
              hit.collider.gameObject.GetComponent<Collider>().enabled = false;
              Debug.Log("Objectif Réussi Quest Eleven");
              validQuest11.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "LevierDisjoncteurQuestTwelve": // Gère la récupération du levier pour la quête 12

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region LevierDisjoncteurQuestTwelve
            if (validQuest11.GetComponent<QuestElement>().step.isComplete == false || validQuest12.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Récupérer le levier", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              levier.SetActive(false);
              Debug.Log("Objectif Réussi Quest Twelve");
              validQuest12.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "UseLevierDisjoncteurQuestThirteen": // Gère l'utilisation du levier pour la quête 13

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region LevierDisjoncteurQuestThirteen
            if (validQuest12.GetComponent<QuestElement>().step.isComplete == false || validQuest13.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Utiliser la manivelle", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

              StartCoroutine(LevierAnim("turnLevier", levierFantome));
              hit.collider.gameObject.GetComponent<Collider>().enabled = false;
              Debug.Log("Objectif Réussi Quest Thirteen");
              validQuest13.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }
          break;

        case "TakeKeyQuestFourteen": // Gère la récupération de la clé pour la quête 14

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region TakeKeyQuestFourteen
            if (validQuest13.GetComponent<QuestElement>().step.isComplete == false || validQuest14.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Récupérer la clé Q3", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              InventoryManager.instance.AddObject(hit.collider.gameObject);
              Debug.Log("Objectif Réussi Quest Fourteen");
              validQuest14.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "UseKeyQuestFifteen": // Gère l'utilisation de la clé Q3 pour la quête 15

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region UseKeyQuestFifteen
            if (validQuest14.GetComponent<QuestElement>().step.isComplete == false || validQuest15.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Insérer la clé Q3", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              Debug.Log("Objectif Réussi Quest Fifteen");
              cleQuestFifteen.SetActive(true);
              StartCoroutine(LevierAnim("pompeLevier", levierFantome2));
              hit.collider.gameObject.GetComponent<Collider>().enabled = false;
              validQuest15.GetComponent<QuestElement>().CompleteWithSucess();

            }
            #endregion
          }

          break;

        case "UseGreenButtonQuestSixteen": // Gère l'utilisation du bouton vert pour la quête 16

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region UseGreenButtonQuestSixteen
            if (validQuest15.GetComponent<QuestElement>().step.isComplete == false || validQuest16.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Appuyer sur le bouton vert", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              Debug.Log("Objectif Réussi Quest Sixteen");
              greenButton.transform.position = greenButton.transform.position + moveForwardButtton;
              validQuest16.GetComponent<QuestElement>().CompleteWithSucess();

            }
            #endregion
          }

          break;

        case "UseTabouretQuestSeventeen": // Gère l'utilisation du tabouret pour la quête 17

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region UseTabouretQuestSeventeen
            if (validQuest16.GetComponent<QuestElement>().step.isComplete == false || validQuest17.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Récupérer le tabouret", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              Debug.Log("Objectif Réussi Quest Seventeen");
              tableFantome2.SetActive(true);
              tableFantome.SetActive(false);
              validQuest17.GetComponent<QuestElement>().CompleteWithSucess();


            }
            #endregion
          }

          break;

        case "InsertKeyQuestHeighteen": // Gère l'utilisation de la clé pour la quête 18

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region UseTabouretQuestSeventeen
            if (validQuest17.GetComponent<QuestElement>().step.isComplete == false || validQuest18.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Insérer la clé Q2", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              Debug.Log("Objectif Réussi Quest Heighteen");
              keyQuestHeighteen.GetComponent<MeshRenderer>().enabled = true;
              validQuest18.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "TakeBarQuestNineteen": // Gère la récupération de la barre pour la quête 19

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region UseBarQuestNineteen
            if (validQuest18.GetComponent<QuestElement>().step.isComplete == false || validQuest19.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }

            HoverCrosshair("Récupérer la barre de fer", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              barDeFer2.SetActive(false);

              Debug.Log("Objectif Réussi Quest Nineteen");
              validQuest19.GetComponent<QuestElement>().CompleteWithSucess();

            }
            #endregion
          }

          break;


        case "UseBarQuestTwenty": // Gère l'utilisation de la barre pour la quête 20

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region UseBarQuestTwenty
            if (validQuest19.GetComponent<QuestElement>().step.isComplete == false || validQuest20.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Utiliser la barre de fer", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              hit.collider.gameObject.transform.Rotate(turnLocket2);
              barFantome2.SetActive(true);
              StartCoroutine(GoToBeginIronBar(hit.collider.gameObject, barFantome2, barDeFer2, "leverBarDeFer", turnLocket2));
              hit.collider.gameObject.GetComponent<Collider>().enabled = false;
              Debug.Log("Objectif Réussi Quest Twenty");
              validQuest20.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "TabouretQuestTwentyOne": // Gère la position du tabouret pour la quête 21

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region TabouretQuestTwentyOne
            if (validQuest20.GetComponent<QuestElement>().step.isComplete == false || validQuest21.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Récupérer le tabouret", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              tableFantome2.SetActive(false);
              tableFantome3.SetActive(true);
              Debug.Log("Objectif Réussi Quest Twenty One");
              validQuest21.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "BarQuestTwentyTwo": // Gère la barre de terre de la quête 22

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region BarQuestTwentyTwo
            if (validQuest21.GetComponent<QuestElement>().step.isComplete == false || validQuest22.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Barre de Terre", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              if (barNoActive2 == true)
              {
                bar3.GetComponent<Animator>().SetBool("baisseBarTerre", true);
                barNoActive2 = false;
                validQuest22.GetComponent<QuestElement>().CompleteWithSucess();
              }
            }
            #endregion
          }

          break;

        case "KeyQuestTwentyThree": // Gère la clé de la quête 23

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region KeyQuestTwentyThree
            if (validQuest22.GetComponent<QuestElement>().step.isComplete == false || validQuest23.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }

            HoverCrosshair("Récupérer la clé GC1", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              InventoryManager.instance.AddObject(hit.collider.gameObject);
              validQuest23.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;



        case "TakeBarQuestTwentyFour": // Gère la barre de la quête 24

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region TakeBarQuestTwentyFour
            if (validQuest23.GetComponent<QuestElement>().step.isComplete == false || validQuest24.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }

            HoverCrosshair("Récupérer la barre", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              barDeFer3.SetActive(false);
              validQuest24.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "UseBarQuestTwentyFive": // Gère l'utilisation de la barre de fer pour la quête 25

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region UseBarQuestTwentyFive
            if (validQuest24.GetComponent<QuestElement>().step.isComplete == false || validQuest25.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Utiliser la barre de fer", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              hit.collider.gameObject.transform.Rotate(turnLocket2);
              barFantome3.SetActive(true);
              StartCoroutine(GoToBeginIronBar(hit.collider.gameObject, barFantome3, barDeFer3, "leverBarDeFer", turnLocket2));
              hit.collider.gameObject.GetComponent<Collider>().enabled = false;
              Debug.Log("Objectif Réussi Quest Twenty Five");
              validQuest25.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "TabouretQuestTwentySix": // Gère la position du tabouret pour la quête 26

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region TabouretQuestTwentyOne
            if (validQuest25.GetComponent<QuestElement>().step.isComplete == false || validQuest26.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Récupérer le tabouret", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              tableFantome3.SetActive(false);
              tableFantome4.SetActive(true);
              Debug.Log("Objectif Réussi Quest Twenty Six");
              validQuest26.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;



        case "BarQuestTwentySeven": // Gère la barre de terre de la quête 27

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region BarQuestTwentySeven
            if (validQuest26.GetComponent<QuestElement>().step.isComplete == false || validQuest27.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Barre de Terre", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              if (barNoActive3 == true)
              {
                bar4.GetComponent<Animator>().SetBool("baisseBarTerre", true);
                barNoActive3 = false;
                validQuest27.GetComponent<QuestElement>().CompleteWithSucess();
              }
            }
            #endregion
          }

          break;

        case "KeyQuestTwentyHeight": // Gère la clé de la quête 28

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region KeyQuestTwentyHeight
            if (validQuest27.GetComponent<QuestElement>().step.isComplete == false || validQuest28.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }

            HoverCrosshair("Récupérer la clé GC2", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              InventoryManager.instance.AddObject(hit.collider.gameObject);
              validQuest28.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "TakeBarQuestTwentyNine": // Gère la barre de la quête 29

          if (CheckIfLampIsGrab() == false)
          {
            #region TakeBarQuestTwentySeven
            if (validQuest28.GetComponent<QuestElement>().step.isComplete == false || validQuest29.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }

            HoverCrosshair("Récupérer la barre", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              barDeFer4.SetActive(false);
              validQuest29.GetComponent<QuestElement>().CompleteWithSucess();
            }
            #endregion
          }

          break;

        case "UseBarQuestThirty": // Gère l'utilisation de la barre de fer pour la quête 30

          if (CheckIfLampIsGrab() == false)
          {
            #region UseBarQuestTwentyFive
            if (validQuest29.GetComponent<QuestElement>().step.isComplete == false || validQuest30.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Utiliser la barre de fer", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

              hit.collider.gameObject.transform.Rotate(turnLocket2);
              barFantome4.SetActive(true);
              StartCoroutine(GoToBeginIronBar(hit.collider.gameObject, barFantome4, barDeFer4, "leverBarDeFer", turnLocket2));
              hit.collider.gameObject.GetComponent<Collider>().enabled = false;
              Debug.Log("Objectif Réussi Quest Twenty Height");
              validQuest30.GetComponent<QuestElement>().CompleteWithSucess();

            }
            #endregion
          }

          break;


        case "UseKeyQuestThirtyOne": // Gère l'utilisation de la clé de la quête 31

          if (CheckIfLampIsGrab() == false)
          {
            #region UseKeyQuestThirtyOne
            if (validQuest30.GetComponent<QuestElement>().step.isComplete == false || validQuest31.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Utiliser clé GC1", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              keyQuestThirtyOne.SetActive(true);
              if (VisiereController.VisiereIsDown())
              {
                QuestManager.CompleteStep();
              } else { QuestManager.CompleteStepWithError(); }
            }
            #endregion
          }

          break;

        case "UseManivelleQuestThirtyTwo": // Gère l'utilisation de la manivelle de la quête 32

          if (CheckIfLampIsGrab() == false)
          {
            #region UseManivelleQuestThirtyTwo
            if (validQuest31.GetComponent<QuestElement>().step.isComplete == false || validQuest32.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Utiliser la manivelle", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              StartCoroutine(ManivelleAnim("turnManivelle", mani1, maniBase1));
              //validQuest32.GetComponent<QuestElement>().CompleteWithSucess();
              if (VisiereController.VisiereIsDown())
              {
                QuestManager.CompleteStep();
              } else { QuestManager.CompleteStepWithError(); }
            }
            #endregion
          }

          break;

        case "UseKeyQuestThirtyThree": // Gère l'utilisation de la clé de la quête 33

          if (CheckIfLampIsGrab() == false)
          {
            #region UseKeyQuestThirtyThree
            if (validQuest32.GetComponent<QuestElement>().step.isComplete == false || validQuest33.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Utiliser clé GC2", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              keyQuestThirtyThree.SetActive(true);
              //validQuest33.GetComponent<QuestElement>().CompleteWithSucess();
              if (VisiereController.VisiereIsDown())
              {
                QuestManager.CompleteStep();
              } else { QuestManager.CompleteStepWithError(); }
            }
            #endregion
          }

          break;

        case "UseManivelleQuestThirtyFour": // Gère l'utilisation de la manivelle de la quête 34

          if (CheckIfLampIsGrab() == false)
          {
            #region UseManivelleQuestThirtyFour
            if (validQuest33.GetComponent<QuestElement>().step.isComplete == false || validQuest34.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Utiliser la manivelle", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              StartCoroutine(ManivelleAnim("turnManivelle", mani2, maniBase2));
              //validQuest33.GetComponent<QuestElement>().CompleteWithSucess();
              if (VisiereController.VisiereIsDown())
              {
                QuestManager.CompleteStep();
              } else { QuestManager.CompleteStepWithError(); }
            }
            #endregion
          }

          break;


        case "SwitchQuestThirtyFive": // Gère l'utilisation des disjoncteurs de la quête 35

          if (CheckIfLampIsGrab() == false)
          {
            #region SwitchQuestThirtyFive
            if (validQuest34.GetComponent<QuestElement>().step.isComplete == false || validQuest35.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Réarmer le disjoncteur", hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              for (int i = 0; i < listSwitchs2.Length; i++)
              {
                if (listSwitchs2[i].switchQuestThirtyFive.gameObject == raycastedObj)
                {
                  if (listSwitchs2[i].up == false)
                  {
                    nbSwitchsDown2 += 1;
                    listSwitchs2[i].up = true;
                  }
                }
              }

              hit.collider.gameObject.transform.Rotate(turnDisjonc);
              //validQuest33.GetComponent<QuestElement>().CompleteWithSucess();

              if (VisiereController.VisiereIsDown())
              {QuestManager.CompleteStep();
              } else { QuestManager.CompleteStepWithError(); }
            }
            #endregion
          }

          break;
        #endregion

        case "ErrorTestQuestFifteen": // Gére les erreurs (test)

          if (CheckIfLampIsGrab())
          {

          } else
          {
            #region ErrorTestQuestFifteen
            if (validQuest14.GetComponent<QuestElement>().step.isComplete == false || validQuest15.GetComponent<QuestElement>().step.isComplete == true)
            {
              return;
            }
            HoverCrosshair("Baisser le levier", hit.collider.gameObject);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              Debug.Log("Objectif Loupé");
              barError.GetComponent<Animator>().SetBool("error", true);
              validQuest15.GetComponent<QuestElement>().CompleteWithError();

            }
            #endregion
          }

          break;

        default:

          break;
      }
    } else
    {
      CrosshairNormal();
      parentCommentary.SetActive(false);
    }
  }
  void CrosshairActive()
  {
    uiCrossHair.color = Color.red;
  }
  void CrosshairNormal()
  {
    uiCrossHair.color = Color.white;
  }

  private void HoverCrosshair(string text, GameObject hit)
  {
    raycastedObj = hit;
    CrosshairActive();
    parentCommentary.SetActive(true);
    commentary.text = text + " - Clique Gauche pour interagir";
  }

  IEnumerator ErrorGants()
  {
    parentPayAttention.SetActive(true);
    payAttention.text = "Gants troués inutilisables";
    yield return new WaitForSeconds(2f);
    parentPayAttention.SetActive(false);
  }

  IEnumerator GoToBeginIronBar(GameObject hit, GameObject fantome, GameObject real, string anim, Vector3 turn)
  {
    fantome.GetComponent<Animator>().SetBool(anim, true);
    yield return new WaitForSeconds(2f);
    fantome.SetActive(false);
    real.SetActive(true);
    hit.transform.Rotate(-turn);
  }

  IEnumerator LevierAnim(string anim, GameObject levier)
  {
    levier.SetActive(true);
    levier.GetComponent<Animator>().SetBool(anim, true);
    yield return new WaitForSeconds(2.5f);
    levier.SetActive(false);
  }

  IEnumerator ManivelleAnim(string anim, GameObject manivelle, GameObject manivelleBase)
  {
    manivelleBase.SetActive(false);
    manivelle.SetActive(true);
    manivelle.GetComponent<Animator>().SetBool(anim, true);
    yield return new WaitForSeconds(3f);
    manivelle.SetActive(false);
    manivelleBase.SetActive(true);
  }

  private bool CheckIfLampIsGrab() // Empêche d'intéragir avec les autres éléments si on tiens la lampe
  {
    if (grab == true)
    {
      return true;
    } else
    {
      return false;
    }
  }

  private void RemoveAndResetLamp() // Gère la réinitialisation de la lampe dans la scène
  {
    if (isMoving == true && Input.GetKeyDown(KeyCode.R))
    {
      lampeMoving.transform.position = lampe.transform.position;
      lampeMoving.transform.rotation = lampe.transform.rotation;
      isMoving = false;
    }
  }
}
