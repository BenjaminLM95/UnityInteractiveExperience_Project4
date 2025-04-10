using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Task;

public class QuestManager : MonoBehaviour
{
    public Task _task01 = new Task();
    public Task _task02 = new Task();
    public Task _task03 = new Task();
    public Task _task04 = new Task();
    public Task _task05 = new Task();

    public string taskProgression;
    public bool taskAssigned;
    public bool taskCompleted;


    public Inventory _playerInventory;

    public bool talkFisherman = false;
    public bool chefMakingSoup = false;
    public bool SoupReady = false;
    public bool GemReceived = false; 
    

    // Start is called before the first frame update
    void Start()
    {      
        

        taskProgression = _task01.progress.ToString();
        taskAssigned = _task01.assigned;
        taskCompleted = _task01.completed; 



    }

    // Update is called once per frame
    void Update()
    {
        CheckForTask1();
       

        if (taskProgression != _task01.progress.ToString())
            taskProgression = _task01.progress.ToString();

        if (taskAssigned != _task01.assigned)
            taskAssigned = _task01.assigned;

        if (taskCompleted != _task01.completed)
            taskCompleted = _task01.completed;

        CheckForTask1();


        CheckForTask2();

        CheckForTask3(); 

        CheckForTask4();

        CheckForTask5();
    }




    public void CheckForTask1() 
    {
        if (_task01.progress == TaskProgression.Unnasigned && _task01.assigned)
        {
            _task01.progress = TaskProgression.InProgress;
        }

        if (_task01.progress == TaskProgression.InProgress && _task01.completed)
            _task01.progress = TaskProgression.Completed;


    }

    public void CheckForTask2()
    {
        if (_task02.progress == TaskProgression.Unnasigned && _task02.assigned)
        {
            _task02.progress = TaskProgression.InProgress;
        }

        if (_task02.progress == TaskProgression.InProgress && _task02.completed)
            _task02.progress = TaskProgression.Completed;

        if (_playerInventory.nCheese >= 4 && _playerInventory.nApple >= 3 && _playerInventory.nPotato >= 3 && _task02.progress == TaskProgression.InProgress)
            _task02.completed = true; 
    }

    public void CheckForTask3()
    {
        if (_task03.progress == TaskProgression.Unnasigned && _task03.assigned)
        {
            _task03.progress = TaskProgression.InProgress;
        }

        if (_task03.progress == TaskProgression.InProgress && _task03.completed)
            _task03.progress = TaskProgression.Completed;

        if (_playerInventory.nFish > 0 && _task03.progress == TaskProgression.InProgress)
            _task03.completed = true; 
    }

    public void CheckForTask4()
    {
        if (_task04.progress == TaskProgression.Unnasigned && _task04.assigned)
        {
            _task04.progress = TaskProgression.InProgress;
        }

        if (_task04.progress == TaskProgression.InProgress && _task04.completed)
            _task04.progress = TaskProgression.Completed;
    }

    public void CheckForTask5()
    {
        if (_task05.progress == TaskProgression.Unnasigned && _task05.assigned)
        {
            _task05.progress = TaskProgression.InProgress;
        }

        if (_task05.progress == TaskProgression.InProgress && _task05.completed)
            _task05.progress = TaskProgression.Completed;

        if (_playerInventory.nGem >= 10 && _task05.progress == TaskProgression.InProgress)
            _task05.completed = true; 
    }

    public string[] setTheDialogue(string[] dialogue) 
    {
        return dialogue; 
    }
}
