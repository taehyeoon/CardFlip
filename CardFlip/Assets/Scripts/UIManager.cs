using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    // IngameCanvas
    public Text nowTimeText;
    public Text nowScoreText;

    // ResultCanvas
    public Text totalClickText;
    public Text accuracyText;
    public Text playTimeText;
    public Text totalScoreText;

    public GameObject inGameCanvas;
    public GameObject pauseCanvas;
    public GameObject resultCanvas;

    public Button btnMenu;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        inGameCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        resultCanvas.SetActive(false);
    }


    void Update()
    {   
    }

    public void UpdateTimeText(float time)
    {
        nowTimeText.text = "limit\n" + string.Format("{0:0.0}",time);
    }
    public void UpdateScoreText(int score)
    {
        nowScoreText.text = "Score\n" + score;
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
    public void ShowResultPage(int click, float accuracy, float playingTime, int score)
    {
        totalClickText.text = click.ToString();
        accuracyText.text = string.Format("{0:0.00}", accuracy) + " %";
        playTimeText.text = string.Format("{0:0.0}", playingTime) + " s";
        totalScoreText.text = score.ToString();

        inGameCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        resultCanvas.SetActive(true);

        GameManager.Instance.SetFreeze(true);
    }


}
