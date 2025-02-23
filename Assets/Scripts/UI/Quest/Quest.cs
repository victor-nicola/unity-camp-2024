using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject textObj, check, ongoing;
    [HideInInspector] public bool isDone = false;
    [HideInInspector] public int questType, questNr;
    private string[,] questNames = {{"laptop","laptopuri"}, 
                        {"sticla", "sticle"}, 
                        {"cartela", "cartele"}};

    public float duration = 2f;    // The duration of the animation
    private float endX;       // The ending x position
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        check.SetActive(false);
        ongoing.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setQuest(int type, int nr)
    {
        QuestHandler questHandler = GameObject.Find("QuestHandler").GetComponent<QuestHandler>();
        int no = questHandler.itemCompletion[type];
        questType = type;
        questNr = nr;
        textObj.GetComponent<TMP_Text>().text = "Recupereaza " + no + "/" + nr + " " + questNames[type, nr > 1? 1 : 0];
        rectTransform = GetComponent<RectTransform>();
        endX = transform.position.x + rectTransform.sizeDelta.x * type;
        StartCoroutine(LerpPosition());
    }

    public void updateQuest() {
        QuestHandler questHandler = GameObject.Find("QuestHandler").GetComponent<QuestHandler>();
        int no = questHandler.itemCompletion[questType];
        textObj.GetComponent<TMP_Text>().text = "Recupereaza " + no + "/" + questNr + " " + questNames[questType, questNr > 1? 1 : 0];
    }

    private IEnumerator LerpPosition()
    {
        Vector3 startPosition = rectTransform.anchoredPosition;
        Vector3 endPosition = new Vector3(endX, startPosition.y, startPosition.z);
        
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            rectTransform.anchoredPosition = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is set to the end position
        rectTransform.anchoredPosition = endPosition;
    }

    public void completeQuest() {
        isDone = true;
        check.SetActive(true);
        ongoing.SetActive(false);
    }
}
