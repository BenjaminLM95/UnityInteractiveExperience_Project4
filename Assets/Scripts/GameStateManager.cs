using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public UIManagement _uiManager = new UIManagement();
    public PlayerMovement playerM = new PlayerMovement();

    public enum GameState
    {
        MainMenu_State,   // The game is at the main menu
        Gameplay_State,   // The game is actively being played
        Paused_State,      // The game is paused
        Options_State      // The options UI activates 


    }

    // Property to store the current game state, accessible publicly but modifiable only within this class
    public GameState currentState { get; private set; }

    // Debugging variables to store the current and last game state as strings for easier debugging in the Inspector
    [SerializeField] private string currentStateDebug;
    [SerializeField] private string lastStateDebug;

    public bool gameActive;

    public GameObject player;

    private void Start()
    {
        // Set the initial state of the game to Main Menu when the game starts
        ChangeState(GameState.MainMenu_State);
        gameActive = false;
    }

    // Method to change the current game state
    public void ChangeState(GameState newState)
    {
        // Store the current state as the last state before changing it
        lastStateDebug = currentState.ToString();

        // Assign the new state to currentState
        currentState = newState;

        // Call a function to handle any specific actions triggered by the state change
        HandleStateChange(newState);

        // Store the new state in a string variable for debugging purposes
        currentStateDebug = currentState.ToString();
    }
            

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Gameplay_State)
                ChangeState(GameState.Paused_State);

        }
    }


    private void HandleStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu_State:
                Debug.Log("Switched to MainMenu State");
                // TODO: Add logic for when the game enters the Main Menu (e.g., show UI)
                _uiManager.EnableMainMenuUI();
                Time.timeScale = 0f;
                gameActive = false;
                break;

            case GameState.Gameplay_State:
                Debug.Log("Switched to Gameplay State");
                // TODO: Add logic for starting/resuming the game (e.g., enable player movement)
                gameActive = true;
                _uiManager.EnableGamePlay();
                Time.timeScale = 1f;
                break;

            case GameState.Paused_State:
                Debug.Log("Switched to Paused State");
                // TODO: Add logic for pausing the game (e.g., stop player movement, show pause menu)
                Time.timeScale = 0f;
                _uiManager.EnablePause();
                break;

            case GameState.Options_State:
                Debug.Log("Switch to Options State");
                Time.timeScale = 0;
                _uiManager.EnableOptions();
                break;


        }
    }

    public void SwitchToGamePlay()
    {
        ChangeState(GameState.Gameplay_State);
    }

    public void ResumeGamePlay()
    {
        if (gameActive)
        {
            ChangeState(GameState.Gameplay_State);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Overworld");
        setPlayerPosition();
        ChangeState(GameState.Gameplay_State);


    }

    public void SwitchToMainMenu()
    {
        SceneManager.LoadScene("Menu");
        ChangeState(GameState.MainMenu_State);
    }

    public void SwitchToOptions()
    {
        ChangeState(GameState.Options_State);
    }

    public void setPlayerPosition()
    {
        player.gameObject.transform.position = new Vector2(0f, 0f);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
