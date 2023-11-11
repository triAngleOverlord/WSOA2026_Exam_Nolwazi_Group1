using UnityEngine;
using TMPro;

public class AnswerFeedback : MonoBehaviour
{
    public TMP_Text feedbackText;  // Reference to the TextMeshPro Text component
    public float displayTime = 3f;  // Time in seconds to display the feedback

    private void Start()
    {
        // Make sure the feedback text is initially hidden
        feedbackText.gameObject.SetActive(false);
    }

    // Call this method when the correct answer is clicked
    public void ShowCorrectFeedback()
    {
        // Display the feedback text
        feedbackText.text = "Well done! Move onto the next riddle";
        feedbackText.gameObject.SetActive(true);

        // Invoke a method to hide the feedback text after a certain time
        Invoke("HideFeedback", displayTime);
    }

    // Method to hide the feedback text
    private void HideFeedback()
    {
        feedbackText.gameObject.SetActive(false);
    }
}
