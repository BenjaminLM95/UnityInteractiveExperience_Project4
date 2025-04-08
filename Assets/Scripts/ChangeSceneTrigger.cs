using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneTrigger : MonoBehaviour
{
    public string sceneName;
    public string spawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance._levelManagement.LoadSceneWithSpawnPoint(sceneName, spawnPoint);
        }
    }
}
