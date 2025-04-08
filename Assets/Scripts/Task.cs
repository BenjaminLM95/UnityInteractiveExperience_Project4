using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
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
    private string instructions; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInstruction(string textInstruction) 
    {
        instructions = textInstruction; 
    }
}
