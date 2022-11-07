using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public GameObject inGameCanvas;
    public GameObject pauseCanvas;
    public GameObject resultCanvas;
    
    public Button btnMenu;
    // Start is called before the first frame update
    void Start()
    {
        
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
    public void EventOnclickExit()
    {
        Application.Quit();
    }


}
