using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public LevelManagement _levelManagement;

    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log($"Game Manager hitting awake. Current instance is {Instance}");
        if (Instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
}
