using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;
    public static EventManager Instance { get { return instance; } }

    public GameObject inGameCanvas;
    public GameObject pauseCanvas;
    public GameObject resultCanvas;
    public GameObject startCanvas;
    
    public Button btnMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EventOnclickMenu()
    {
        btnMenu.interactable = false;

        inGameCanvas.SetActive(true);
        resultCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        
        GameManager.Instance.SetisPlayMode(false);
        GameManager.Instance.SetFreeze(true);
    }
    public void EventOnclickContinue()
    {
        btnMenu.interactable = true;


        inGameCanvas.SetActive(true);
        resultCanvas.SetActive(false);
        pauseCanvas.SetActive(false);

        GameManager.Instance.SetisPlayMode(true);
        GameManager.Instance.SetFreeze(false);
    }
    public void EventOnclickRestart()
    {
        btnMenu.interactable = true;

        inGameCanvas.SetActive(true);
        resultCanvas.SetActive(false);
        pauseCanvas.SetActive(false);

        GameManager.Instance.ResetGame();
    }

    public void EventOnclickGameStart()
    {
        startCanvas.SetActive(false);
        inGameCanvas.SetActive(true);

        Card_Control.Instance.ShowCards();
        // 카드 활성화 하는 부분 필요
        GameManager.Instance.ResetGame();
    }

    public void EventOnclickExit()
    {
        Application.Quit();
    }

    public void showOnlyStartCanvas()
    {
        inGameCanvas.SetActive(false);    
        pauseCanvas.SetActive(false);
        resultCanvas.SetActive(false);
        startCanvas.SetActive(true);
    }                    

}
