using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    public GameObject player;
    bool exit = false;
    private string spawnPointName;
    // Start is called before the first frame update

    public void LoadSceneWithSpawnPoint(string sceneName, string spawnPoint)
    {
        spawnPointName = spawnPoint;

        SceneManager.sceneLoaded += onSceneLoaded;

        SceneManager.LoadScene(sceneName);
    }

    void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("Scene: " + scene.name + "is loaded");        
        SetPlayerToSpawn(spawnPointName);

    }

    public void SetPlayerToSpawn(string spawnPointName)
    {
        GameObject spawnPointObject = GameObject.Find(spawnPointName);
        if (spawnPointObject != null)
        {
            if (player != null)
            {
                // Set the player position to the spawn object
                Transform spawnPointTransform = spawnPointObject.transform;
                player.transform.position = spawnPointTransform.position;
            }
            else
            {
                Debug.LogError("Player not found in the scene!");
            }
        }
        else
        {
            Debug.LogError($"Spawn point with {spawnPointName} not found in the scene!");
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= onSceneLoaded;
    }
}
