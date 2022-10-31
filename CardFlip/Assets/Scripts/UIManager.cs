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
        inGameCanvas.SetActive(false);
        resultCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        GameManager.Instance.SetFreeze(true);
    }
    public void EventOnclickContinue()
    {
        inGameCanvas.SetActive(true);
        resultCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        GameManager.Instance.SetFreeze(false);
    }
    public void EventOnclickRestart()
    {
        pauseCanvas.SetActive(false);
        inGameCanvas.SetActive(true);
        GameManager.Instance.ResetGame();
    }
    public void EventOnclickExit()
    {
        Application.Quit();
    }
    public void ShowResultPage(int click, float accuracy, float playingTime, int score)
    {
        totalClickText.text = "전체 클릭 횟수 : " + click;
        accuracyText.text = "정확도 : " + string.Format("{0:0.00}", accuracy) + " %";
        playTimeText.text = "플레이 타임 : " + string.Format("{0:0.0}", playingTime) + " s";
        totalScoreText.text = "점수 : " + score;

        inGameCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        resultCanvas.SetActive(true);
    }


}
