using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Inventory : MonoBehaviour
{

    public int nGem;
    public int currentNGem;
    public int nCheese;
    public int currentNCheese;
    public int nApple;
    public int currentNApple;
    public int nFish;
    public int currentNFish;
    public int nPotato;
    public int currentPotato;
    public bool fishingRod = false;
    public bool Soup = false;
    public bool Information = false;

    public TextMeshProUGUI gemTxt;
    public TextMeshProUGUI cheeseTxt;
    public TextMeshProUGUI appleTxt;
    public TextMeshProUGUI fishTxt;
    public TextMeshProUGUI potatoTxt;

    public GameObject objNotSoup;
    public GameObject objSoup;
    public GameObject objFishingRod;

    public TextMeshProUGUI pickUpNotice;
    public bool isTextDisplayed = false;


    // Start is called before the first frame update
    void Start()
    {
        nGem = 0;
        nCheese = 0;
        nApple = 0;
        nFish = 0;
        gemTxt.text = "Gem: " + nGem;
        cheeseTxt.text = "Cheese: " + nCheese;
        appleTxt.text = "Apple" + nApple;
        fishTxt.text = "Fish: " + nFish;
        potatoTxt.text = "Potato: " + nPotato; 

       
    }

    // Update is called once per frame
    void Update()
    {
        if(nGem!=currentNGem || nCheese!=currentNCheese || nApple!=currentNApple || nFish != currentNFish || nPotato!=currentPotato) 
        {
            nGem = currentNGem;
            nCheese = currentNCheese;
            nApple = currentNApple;
            nFish = currentNFish; 
            nPotato = currentPotato;

            gemTxt.text = "Gem: " + nGem;
            cheeseTxt.text = "Cheese: " + nCheese;
            appleTxt.text = "Apple: " + nApple;
            fishTxt.text = "Fish: " + nFish;
            potatoTxt.text = "Potato: " + nPotato;

            
        }

        if (!Soup)
        {
            objNotSoup.SetActive(true);
            objSoup.SetActive(false);
        }
        else 
        {
            objNotSoup.SetActive(false);
            objSoup.SetActive(true);
        }

        if (fishingRod)
            objFishingRod.SetActive(true);
        else
        { objFishingRod.SetActive(false); }

    }

    public void AddToInventory(string typeItem) 
    {
        switch (typeItem)
        {
            case "Apple":
                currentNApple++;
                DisplayNewItem("Apple");
                break;
            case "Cheese":
                currentNCheese++;
                DisplayNewItem("Cheese");
                break;
            case "Fish":
                currentNFish++;
                DisplayNewItem("Fish");
                break;
            case "Gem":
                currentNGem++;
                DisplayNewItem("Gem");
                break;
            case "Potato":
                currentPotato++;
                DisplayNewItem("Potato"); 
                break; 
        }
    }

    IEnumerator ClearText(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        pickUpNotice.text = "";
        isTextDisplayed = false;
    }

    public void DisplayNewItem(string itemName) 
    {
        pickUpNotice.text = "You added a/an " + itemName + " in you inventory";
        isTextDisplayed = true;
        StopAllCoroutines();
        StartCoroutine(ClearText(2.5f));
    }
}
