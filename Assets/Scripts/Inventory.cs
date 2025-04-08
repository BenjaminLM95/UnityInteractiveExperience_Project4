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

    public TextMeshProUGUI inventoryDisplay = new TextMeshProUGUI(); 
    // Start is called before the first frame update
    void Start()
    {
        nGem = 0;
        nCheese = 0;
        nApple = 0;
        nFish = 0;
        inventoryDisplay.text = "Gem: " + nGem + "Cheese: " + nCheese + "Apple: " + nApple + "Fish: " + nFish;
    }

    // Update is called once per frame
    void Update()
    {
        if(nGem!=currentNGem || nCheese!=currentNCheese || nApple!=currentNApple || nFish != currentNFish) 
        {
            nGem = currentNGem;
            nCheese = currentNCheese;
            nApple = currentNApple;
            nFish = currentNFish; 

            inventoryDisplay.text = "Gem: " + nGem + "Cheese: " + nCheese + "Apple: " + nApple + "Fish: " + nFish; 
        }
    }
}
