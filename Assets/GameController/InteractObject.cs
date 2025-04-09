using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public enum InterType
    {
        Nothing,
        Info,
        PickUp,
        Dialogue
    }

    public enum TypePickUp 
    {
        None,
        Apple,
        Cheese,
        Fish,
        Potato,
        Gem
    }

    public DialogueManagement dialogueManager = null ;
    public QuestManager questManager = null;

    [Header("Type of Interaction")]
    public InterType type;

    [Header("Type of PickUp")]
    public TypePickUp _typePickUp;

    [Header("Info Message")]
    public string infoMessage;

    [Header("Dialogue")]
    [TextArea] public string[] sentences;
   

    public TextMeshProUGUI infoText = null;

    public bool isTextDisplayed;

    public Inventory playerInventory;

    public string npcName;

    public AllDialogues _allDialogues; 
   

    // Start is called before the first frame update
    void Awake()
    {
        GameObject textObject = GameObject.Find("Info Display");
        if (textObject != null)
        {
            infoText = textObject.GetComponent<TextMeshProUGUI>();            
        }       
        isTextDisplayed = false;

        dialogueManager = GameObject.FindObjectOfType<DialogueManagement>();

        playerInventory = GameObject.FindObjectOfType<Inventory>();

        questManager = GameObject.FindObjectOfType<QuestManager>();

        _allDialogues = GameObject.FindObjectOfType<AllDialogues>(); 

        if(_typePickUp == null)
            _typePickUp = TypePickUp.None;

        npcName = this.gameObject.name; 
    }
    

    public void Interact() 
    {
        Debug.Log("Interacting with " + this.gameObject.name);

        switch (this.type.ToString()) 
        {
            case "Nothing":
                Nothing();
                break;
            case "Info":
                Info();
                break;
            case "PickUp":
                PickUp();
                break;
            case "Dialogue":
                Dialogue();
                break;
            default:
                Nothing();
                break; 
        }

    }

    public void Nothing() 
    {
        Debug.Log("Interaction type not defined");
       
    }

    public void PickUp() 
    {
        Debug.Log("Picking up object" + gameObject.name);

        if (_typePickUp != TypePickUp.Fish)
        {
            playerInventory.AddToInventory(_typePickUp.ToString());
            this.gameObject.SetActive(false);
        }
        else 
        {
            if (playerInventory.fishingRod) 
            {
                playerInventory.AddToInventory(_typePickUp.ToString());
                this.gameObject.SetActive(false);
            }
        }
    }

    public void Info()
    {
        Debug.Log("Display info message on Object" + gameObject.name);
        infoText.text = "Info Message: " + infoMessage;       
        isTextDisplayed = true;
        StopAllCoroutines();
        StartCoroutine(ClearText(5f));
    }

    public void Dialogue() 
    { 
        if(npcName == "SickOldMan_357") 
        {
            if (!questManager._task01.assigned) 
            {
                dialogueManager.StartDialogue(sentences);
                questManager._task01.assigned = true; 
            }
            else if (questManager._task01.assigned && !dialogueManager.thePlayer.isOnDialogue) 
            {
                dialogueManager.StartDialogue(_allDialogues.SickOldManDialogueTask01InProgress); 
            }
        }
        else if (npcName == "Chef_78") 
        {
            if (questManager._task01.assigned && !questManager._task02.assigned)
            {
                dialogueManager.StartDialogue(_allDialogues.TheChefDialogueTask01InProgress);
                questManager._task02.assigned = true;
            }
            else if (questManager._task02.assigned && !dialogueManager.thePlayer.isOnDialogue && !questManager._task02.completed)
            {
                dialogueManager.StartDialogue(_allDialogues.TheChefDialogueTask02InProgress);
            }
            else if (questManager._task02.completed) 
            {
                dialogueManager.StartDialogue(_allDialogues.TheChefDialogueTask02Completed);
                questManager._task03.assigned = true; 
            }
            else
                dialogueManager.StartDialogue(sentences); 
        }
        else if(npcName == "Fisherman_17") 
        {
            if (questManager._task03.assigned && !questManager.talkFisherman)
            {
                dialogueManager.StartDialogue(_allDialogues.FishermanDialogueTask02Completed);
                questManager.talkFisherman = true;
                playerInventory.fishingRod = true; 
            }
            else if (questManager._task03.assigned && questManager.talkFisherman && !dialogueManager.thePlayer.isOnDialogue)
            {
                dialogueManager.StartDialogue(_allDialogues.FishermanDialogueTask03Assigned);
            }
            else
                dialogueManager.StartDialogue(sentences); 
        }
        else 
        {
            dialogueManager.StartDialogue(sentences);
        }
                 
    }
    

    IEnumerator ClearText(float waitTime)
    {        
        yield return new WaitForSeconds(waitTime);
        infoText.text = "";
        isTextDisplayed = false;
    }

    public void AddToInventory(TypePickUp typePickUp) 
    {
        switch (typePickUp) 
        {
            case TypePickUp.Apple:                
                //Add Apple
                break;
            case TypePickUp.Cheese:
                //Add Cheese
                break;
            case TypePickUp.Fish:
                //Add Fish
                break;
            case TypePickUp.Gem:
                //Add Gem;
                Debug.Log("Gem"); 
                break; 
        }
    }

}
