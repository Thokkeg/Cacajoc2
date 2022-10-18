using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public bool canClick = true;

    private void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
        }

    }
}
