using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddToJournal : MonoBehaviour
{
    // Start is called before the first frame update
    public string materialName;

    // Update is called once per frame
    void Update()
    {
        if (materialName != null)
        {
            findInJournal(materialName);
        }
        
    }

    public void findInJournal(string material)
    {
        GameObject journalSource = GameObject.Find(material);
        if (journalSource != null)
        {
            Image imageSource = journalSource.transform.GetComponent<Image>();
            if (imageSource != null)
            {
                imageSource.color = new Color(1f, 1f, 1f, 1f);
            }
            else
                journalSource.transform.GetComponent<TextMeshProUGUI>().color = new Color(1f, 1f, 1f, 1f);

            Destroy(this);
        }
    }
}
