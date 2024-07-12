using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class Player : MonoBehaviour
{
    [DoNotSerialize] public int playerID = 0;
    
    private PlayerInteraction interactionScript;
    private HandScript handScript;
    private GameObject agent;
    private QuestHandler questHandler;
    private GameObject uiP, cameraP;
    private Warning warningP;
    private CameraHandler cameraHandler;

    private RigidbodyConstraints rbc;
    private Rigidbody rb;

    [SerializeField] private Vector3 startPos, playerDiff;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.players[GameManager.Instance.playerNr] = gameObject;
        playerID = GameManager.Instance.addPlayer();
        gameObject.name = "Player" + playerID;
        Debug.Log("Player has id: " + playerID);

        transform.position = startPos + (playerID - 1) * playerDiff;

        interactionScript = gameObject.GetComponent<PlayerInteraction>();
        handScript = gameObject.GetComponentInChildren<HandScript>();
        questHandler = GameObject.Find("QuestHandler").GetComponent<QuestHandler>();
        cameraHandler = GameObject.Find("CameraHandler").GetComponent<CameraHandler>();

        agent = GameObject.Find("Agent");
        cameraP = GameObject.Find("Camera" + playerID);

        uiP = GameObject.Find("UIPlayer" + playerID);
        warningP = uiP.GetComponent<Warning>();

        // Camera Follow
        cameraP.GetComponent<CameraFollow>().objectToFollow = transform;
        // Player Interaction Script
        interactionScript.warning = warningP;
        // Hand Script
        handScript.enemy = agent.GetComponent<FollowTarget>();
        handScript.questHandler = questHandler;
        // Initialize Cameras
        cameraHandler.initializeCamera();
        // Initialize Agent
        if (playerID == 1)
        {
            agent.GetComponent<FollowTarget>().player1 = transform;
            agent.GetComponent<FollowTarget>().m_TargetToFollow = transform;
        }
        else
        {
            agent.GetComponent<FollowTarget>().player2 = transform;
        }

        rb = gameObject.GetComponent<Rigidbody>();
        rbc = rb.constraints;
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unFreeze() {
        rb.constraints = rbc;
    }
}
