using UnityEngine;
using UnityEngine.EventSystems;

public class Mask : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;
    public Transform familyTree;

    public RectTransform maskRect;
    public CanvasGroup maskCanvasGp;

    public void Awake()
    {
        maskRect = GetComponent<RectTransform>();
        maskCanvasGp = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("PlayerScreen").GetComponent<Canvas>();
        familyTree = GameObject.Find("CongoPuzzle").transform;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.parent.transform.GetComponent<MaskPanel>() != null)
        {
            transform.parent.transform.GetComponent<MaskPanel>().occupying = null;
        }
        transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        transform.SetParent(canvas.transform, true);
        //Debug.Log(transform.name + " begun drag");
        maskCanvasGp.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        maskRect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent != canvas.transform)
        {
            Debug.Log(transform.parent.name + " is the new parent");
            maskCanvasGp.blocksRaycasts = true;

        }
        else
        {
            transform.SetParent(familyTree, true);
            transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            maskCanvasGp.blocksRaycasts = true;
        }
    }

    
}
