using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using Unity.VisualScripting;

public enum QuestTypes 
{
    laptop = 0,
    sticla = 1,
    cartela = 2,
    sabie = 3,
}

public class QuestHandler : MonoBehaviour
{
    [SerializeField] private GameObject questPrefab;
    [SerializeField] private Transform parentTransform;

    private GameObject[] quests = new GameObject[10];
    private int questsSize = 0;
    private int[,] typeInterval = {{1, 6}, // laptop
                                   {1, 6}, // sticla
                                   {1, 1}, // cartela
                                   {1, 3}}; // sabie
    private int questTypeNr = 4;
    public int[] itemCompletion = new int[4];

    // Start is called before the first frame update
    void Start()
    {
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
}
