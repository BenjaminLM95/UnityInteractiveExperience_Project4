using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Task> tasks = new List<Task>(); 

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        tasks.Add(new Task());

    }

    // Update is called once per frame
    void Update()
    {
        CheckForTask1();
        CheckForTask2();
        CheckForTask3();
        CheckForTask4();
        CheckForTask5(); 
        
    }

    public void CheckForTask1() 
    {

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
