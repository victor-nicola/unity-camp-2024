using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField] private GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        // Fullscreen the background image
        background.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSingleplayer()
    {
        GameManager.Instance.isSingleplayer = true;
        GameManager.Instance.changeSceneToLvl(1);
    }

    public void playCoop()
    {
        GameManager.Instance.isSingleplayer = false;
        GameManager.Instance.changeSceneToLvl(1);
    }
}
