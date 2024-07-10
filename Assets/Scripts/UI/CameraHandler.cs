using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Camera camP1, camP2;
    [SerializeField] private GameObject divider, playerLabels;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.isSingleplayer)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
