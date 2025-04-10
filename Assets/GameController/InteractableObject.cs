using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject interactableObj = null;
    public GameObject E_Letter;
   
  
 
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E) && interactableObj != null) 
        {
            interactableObj.GetComponent<InteractObject>().Interact(); 
        }

        if (interactableObj != null)
            E_Letter.SetActive(true);
        else
            E_Letter.SetActive(false);

       
    }

    void OnTriggerStay2D(Collider2D col) 
    {
        if (col.gameObject.CompareTag("InteractObject")) 
        {
            interactableObj = col.gameObject; 
        }
    }

    void OnTriggerExit2D(Collider2D col) 
    {
        if (col.gameObject.CompareTag("InteractObject"))
        {
            interactableObj = null;
        }
    }

}
