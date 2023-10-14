using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public GameObject player;
    public GameObject playerScreen;
    public GameObject playerCamera;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(playerScreen);
        DontDestroyOnLoad(playerCamera);

    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();

        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.sortingOrder = (int)(renderer.transform.position.y * -100) +10;
        }
        
    }
}
