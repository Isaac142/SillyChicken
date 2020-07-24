using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public float timer;

    public PlayerCameraMovement PCMX, PCMY;

    public bool isPaused = false;

    public UIManager UI;

    public Text timerText;
    public Text seedText;
    public Text eggText;

    public SeedPickup SP;

    public bool wonGame;

    public bool controlPanelCheck;

    public static GameManager instance = null;

    public GrenadeThrow GT;

    public GameObject player;

    public bool isLost;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }
        // Start is called before the first frame update
        void Start()
    {
        Cursor.visible = true;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        controlPanelCheck = true;
        isLost = false;

    }

    // Update is called once per frame
    void Update()
    {
        int seconds = (int)(timer % 60);
        int minutes = (int)(timer / 60) % 60;

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = timerString;

        if (timer <= 30)
        {
            timerText.text = "Time Left: " + timer.ToString("F2");
        }
        else
        {
            timerText.text = "Time Left: " + timerString;
        }

        if (timer <= 0)
        {
            timer = 0f;
            Time.timeScale = 0f;
            PCMX.canMove = false;
            PCMY.canMove = false;
            GT.canThrow = false;
            UI.lostPanel.SetActive(true);
            UI.inGamePanel.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if(UI.controlsPanelStart.activeSelf == false)
        {
            controlPanelCheck = false;
        }

        if(UI.lostPanel.activeSelf == true)
        {
            isLost = true;
        }
        if(!isPaused && !wonGame && !controlPanelCheck && !isLost)
        {
            Debug.Log("Not Paused");
            timer -= Time.deltaTime;
            Time.timeScale = 1f;
            PCMX.canMove = true;
            PCMY.canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            UI.Pause(isPaused);
            if (isPaused)
            {
                Time.timeScale = 0f;
                PCMX.canMove = false;
                PCMY.canMove = false;
                GT.canThrow = false;
                Cursor.lockState = CursorLockMode.None;
            }

            if (!isPaused)
            {
                UI.pausePanel.SetActive(false);
                UI.winPanel.SetActive(false);
                UI.lostPanel.SetActive(false);
                UI.controlsPanel.SetActive(false);
                GT.canThrow = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
