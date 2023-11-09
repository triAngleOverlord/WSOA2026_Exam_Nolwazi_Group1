using TMPro;
using UnityEngine;

public class nigerianPuzzle : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inputField;
    // Start is called before the first frame update
    
    public void checkNumber()
    {
        if (inputField.text == "16")
            Debug.Log("You are correct!");
        else
            Debug.Log("You are incorrect!");

    }
}
