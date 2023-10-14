using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject currentPage;
    public Transform[] pages;
    public int currentPage;
    void Start()
    {
        var pageList = new List<Transform>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Pages"))
            {
                pageList.Add(child);
                child.gameObject.SetActive(false);
            }
        }
            
        pages = pageList.ToArray();
        pages[0].gameObject.SetActive(true);
        currentPage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backApage()
    {
        if (currentPage-1 <0)
            Debug.Log("This is the first page");
        else
        {
            pages[currentPage].gameObject.SetActive(false);
            currentPage -= 1;
            pages[currentPage].gameObject.SetActive(true);
        }
    }

    public void nextApage()
    {
        if (currentPage + 1 > pages.Length-1)
            Debug.Log("This is the last page");
        else
        {
            pages[currentPage].gameObject.SetActive(false);
            currentPage += 1;
            pages[currentPage].gameObject.SetActive(true);
        }
    }

    public void egyptTab()
    {   pages[currentPage].gameObject.SetActive(false);
        currentPage = 2;
        pages[currentPage].gameObject.SetActive(true);
        
    }
}
