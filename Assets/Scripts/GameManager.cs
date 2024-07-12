using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isSingleplayer = true;
    [DoNotSerialize] public int score;

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
}
