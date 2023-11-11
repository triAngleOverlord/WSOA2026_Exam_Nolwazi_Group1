using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelTrigger : MonoBehaviour
{
    // Specify the name of the scene you want to restart
    public string sceneToRestart = "Maze";

    // This method is called when a GameObject enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RestartScene();
            Debug.Log("Player entered the trigger.");
        }
    }

    // Restart the scene
    private void RestartScene()
    {
        SceneManager.LoadScene(3);

    }
}
