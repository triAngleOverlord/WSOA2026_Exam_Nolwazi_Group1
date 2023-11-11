using UnityEngine;
using TMPro;

public class AnswerFeedback1 : MonoBehaviour
{
    public TMP_Text feedback2Text;  // Reference to the TextMeshPro Text component
    public float displayTime2 = 3f;  // Time in seconds to display the feedback

    private void Start()
    {
        // Make sure the feedback text is initially hidden
        feedback2Text.gameObject.SetActive(false);
    }

    // Call this method when the correct answer is clicked
    public void ShowCorrectFeedback2()
    {
        // Display the feedback text
        feedback2Text.text = "You've completed the maze!Find your way out :)";
        feedback2Text.gameObject.SetActive(true);

        // Invoke a method to hide the feedback text after a certain time
        Invoke("HideFeedback", displayTime2);
    }

    // Method to hide the feedback text
    private void HideFeedback()
    {
        feedback2Text.gameObject.SetActive(false);
    }
}
