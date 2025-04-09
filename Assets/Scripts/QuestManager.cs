using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();
    

    public Inventory _playerInventory;
    public bool task1 = false; 
    public bool Quest01 = false;
    public int Num; 

    // Start is called before the first frame update
    void Start()
    {
        // Task1
        Num = 0;
            



    }

    // Update is called once per frame
    void Update()
    {
        if(Num != _playerInventory.nPotato)
            Num = _playerInventory.nPotato;

        CheckForTask1();
        //CheckForTask2();
        //CheckForTask3();
        //CheckForTask4();
        //CheckForTask5(); 
        
    }

    public void CheckForTask1() 
    {
        if (!task1 && _playerInventory.nPotato >= 4)
        {
            task1 = true; 
        }

    }

    public void CheckForTask2()
    {

    }

    public void CheckForTask3()
    {

    }

    public void CheckForTask4()
    {

    }

    public void CheckForTask5()
    {

    }
}
