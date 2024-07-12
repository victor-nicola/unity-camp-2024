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

    void Awake()
    {
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
        SceneManager.LoadScene("FinishScreen");
    }

    public void dieInGame() {
        Debug.Log("You died!");
        SceneManager.LoadScene("DeathScreen");
    }

    public void unFreeze() {
        agent.GetComponent<NavMeshAgent>().speed = agentSpeed;
        for(int i = 0; i < playerNr; i++) {
            players[i].GetComponent<Player>().unFreeze();
        }
    }

    public void startGame() {
        Debug.Log("Game started!");
        unFreeze();
        startUI.SetActive(false);
    }

    public int addPlayer() {
        if (playerNr == 0)
            p1Joined.SetActive(true);
        if (playerNr == 1)
            p2Joined.SetActive(true);
            
        return ++playerNr;
    }
}
