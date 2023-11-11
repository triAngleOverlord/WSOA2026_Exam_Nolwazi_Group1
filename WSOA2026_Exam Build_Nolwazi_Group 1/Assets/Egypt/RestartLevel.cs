using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public GameObject losePanel;

    public void Restart()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Restart the current scene
        SceneManager.LoadScene(currentSceneIndex);

        // Close the lose panel if it's assigned
        if (losePanel != null)
        {
            losePanel.SetActive(false);
        }
    }
}
