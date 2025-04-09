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

    public TextMeshProUGUI inventoryDisplay = new TextMeshProUGUI(); 
    // Start is called before the first frame update
    void Start()
    {
        nGem = 0;
        nCheese = 0;
        nApple = 0;
        nFish = 0;
        inventoryDisplay.text = "Gem: " + nGem + "Cheese: " + nCheese + "Apple: " + nApple + "Potato" + nPotato + "Fish: " + nFish;
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

            inventoryDisplay.text = "Gem: " + nGem + "Cheese: " + nCheese + "Apple: " + nApple + "Potato" + nPotato + "Fish: " + nFish; 
        }
    }

    public void AddToInventory(string typeItem) 
    {
        switch (typeItem)
        {
            case "Apple":
                currentNApple++; 
                break;
            case "Cheese":
                currentNCheese++;
                break;
            case "Fish":
                currentNFish++;
                break;
            case "Gem":
                currentNGem++;                
                break;
            case "Potato":
                currentPotato++;
                break; 
        }
    }
}
