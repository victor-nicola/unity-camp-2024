using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public enum QuestTypes 
{
    laptop = 0,
    sticla = 1,
    cartela = 2,
}

public class QuestHandler : MonoBehaviour
{
    [SerializeField] private GameObject questPrefab;
    [SerializeField] private Transform parentTransform;

    private GameObject[] quests = new GameObject[10];
    private int questsSize = 0;
    private int[,] typeInterval = {{1, 6}, // laptop
                                   {1, 6}, // sticla
                                   {1, 1}}; // cartela
    private int questTypeNr = 3, questDoneNr;
    public int[] itemCompletion = new int[10];
    [SerializeField] private TMP_Text scoreText;
    [DoNotSerialize] public int score;
    private int[] questPoints = {100, 200, 500};

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        questDoneNr = 0;

        for (int t = 0; t < questTypeNr; t++) 
        {
            int nr = Random.Range(typeInterval[t, 0], typeInterval[t, 1]);
            createQuest(t, nr);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int t = 0; t < questTypeNr; t++) 
        {
            if (quests[t] != null) 
            {
                Quest quest = quests[t].GetComponent<Quest>();
                if (!quest.isDone && quest.questNr <= itemCompletion[t])
                {
                    quest.completeQuest();
                    updateScore();
                    questDoneNr++;
                }
            }
        }
    }

    public void createQuest(int type, int nr)
    {
        // Instantiate the UI prefab
        quests[questsSize] = Instantiate(questPrefab, parentTransform);
        quests[questsSize].GetComponent<Quest>().setQuest(type, nr);
        questsSize++;
    }

    private void updateScore() {
        scoreText.text = "Score: " + score;
    }

    public void depositItem(int type) {
        itemCompletion[type]++;
        Debug.Log("items now at: " + itemCompletion[type]);
        score += questPoints[type];
        updateScore();
    }

    public bool questsDone() {
        return questDoneNr == questTypeNr;
    }
}
