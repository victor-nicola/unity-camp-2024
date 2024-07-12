using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] private Camera camP1;
    [SerializeField] private Camera camP2;
    [Header("UI")]
    [SerializeField] private GameObject divider;
    [SerializeField] private GameObject playerLabels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initializeCamera() {
        if (GameManager.Instance.playerNr == 1)
        {
            camP2.enabled = false;
            camP1.enabled = true;
            camP1.rect = new Rect(0, 0, 1f, 1f);
            divider.SetActive(false);
            playerLabels.SetActive(false);
        } else
        {
            camP2.enabled = true;
            camP1.enabled = true;
            camP1.rect = new Rect(0, 0, 0.5f, 1f);
            camP2.rect = new Rect(0.5f, 0, 0.5f, 1f);
            divider.SetActive(true);
            playerLabels.SetActive(true);
        }
    }
}
