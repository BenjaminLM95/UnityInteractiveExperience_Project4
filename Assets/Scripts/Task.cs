using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Task 
{
    public Task() 
    {
        progress = TaskProgression.Unnasigned;
        assigned = false;
        completed = false; 
    }


    public enum TaskProgression 
    {
        Unnasigned,
        InProgress,
        Completed
    }

    public TaskProgression progress; 
    public bool assigned;
    public bool completed;
    public string instructions; 

    // Start is called before the first frame update
    void Start()
    {
        
    }  
       

    public void SetInstruction(string textInstruction) 
    {
        instructions = textInstruction; 
    }
}
