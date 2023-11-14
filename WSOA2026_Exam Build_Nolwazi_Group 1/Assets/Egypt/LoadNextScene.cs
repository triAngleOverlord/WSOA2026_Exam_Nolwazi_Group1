using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    // Attach this script to a button GameObject

    public void LoadNext()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene (you may want to add a check to ensure it's not the last scene)
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}

