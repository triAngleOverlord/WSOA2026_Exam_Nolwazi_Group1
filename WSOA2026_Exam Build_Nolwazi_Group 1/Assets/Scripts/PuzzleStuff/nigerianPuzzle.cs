using TMPro;
using UnityEngine;

public class nigerianPuzzle : MonoBehaviour
{
    [SerializeField] TMP_InputField[] inputField;
    // Start is called before the first frame update
    
    public void checkNumber()
    {
        
        if (inputField[0].text == "210" && inputField[1].text == "350" && inputField[2].text == "230" && inputField[3].text == "510")
            Debug.Log("You are correct!");
        else
            Debug.Log("You are incorrect!");

    }
}
