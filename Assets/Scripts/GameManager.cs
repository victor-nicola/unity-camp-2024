using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isSingleplayer = true;
    [DoNotSerialize] public int score;
    [DoNotSerialize] public int playerNr;

    [SerializeField] private float agentSpeed = 5f;

    [Header("Freeze entities")]
    [SerializeField] private GameObject agent;
    [DoNotSerialize] public GameObject[] players = new GameObject[4];
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject p1Joined, p2Joined;

    private AudioSource gameTheme;
    private bool gameStarted;

    void Awake()
    {
        gameStarted = false;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerNr = 0;
        gameTheme = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void changeSceneToLvl(int lvl)
    {
        Debug.Log("Level" + lvl);
        SceneManager.LoadScene("Level" + lvl);
    }

    public void finishGame() {
        Debug.Log("Finished game!");
        SceneManager.LoadScene("victoryscreen");
    }

    public void dieInGame() {
        Debug.Log("You died!");
        SceneManager.LoadScene("LoseMenu");
    }

    public void unFreeze() {
        gameTheme.Play();
        agent.GetComponent<FollowTarget>().unFreeze(agentSpeed);
        for(int i = 0; i < playerNr; i++) {
            players[i].GetComponent<Player>().unFreeze();
        }
    }

    public void startGame() {
        if (!gameStarted)
        {
            Debug.Log("Game started!");
            unFreeze();
            startUI.SetActive(false);
            gameStarted = true;
        }
    }

    public int addPlayer() {
        if (playerNr == 0)
            p1Joined.SetActive(true);
        if (playerNr == 1)
            p2Joined.SetActive(true);
            
        return ++playerNr;
    }
}
