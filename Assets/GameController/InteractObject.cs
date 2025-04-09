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

    [Header("Dialogue2")]
    [TextArea] public string[] sentences2; 

    public TextMeshProUGUI infoText = null;

    public bool isTextDisplayed;

    public Inventory playerInventory; 
   

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

        if(_typePickUp == null)
            _typePickUp = TypePickUp.None;
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
        playerInventory.AddToInventory(_typePickUp.ToString()); 
        this.gameObject.SetActive(false); 
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
        if(questManager.task1)
        dialogueManager.StartDialogue(sentences2);
        else
            dialogueManager.StartDialogue(sentences);
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
