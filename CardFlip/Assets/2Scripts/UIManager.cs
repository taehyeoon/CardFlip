using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    // IngameCanvas
    public Text nowTimeText;
    public Text nowScoreText;
    
    // ResultCanvas
    public Text resultText;
    public Text totalClickText;
    public Text accuracyText;
    public Text playTimeText;
    public Text totalScoreText;

    public GameObject inGameCanvas;
    public GameObject pauseCanvas;
    public GameObject resultCanvas;

    //public Button btnMenu;

    public Color ColorTime;

    string ColorTime_code;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        ColorTime_code = "#db2b1f";
/*        inGameCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        resultCanvas.SetActive(false);*/
    }


    void Update()
    {
       
    }

    public void UpdateTimeText(float time)
    {
        if(time < 10.0f)
        {
            nowTimeText.text = "limit\n" + "<color=" + ColorTime_code + ">" + string.Format("{0:0.0}",time) + "</color>";
        }
        else
        {
            nowTimeText.text = "limit\n" + string.Format("{0:0.0}",time);
        }
    }
    public void UpdateScoreText(int score)
    {
        nowScoreText.text = "Score\n" + score;
    }
    public void ShowResultPage(int click, float accuracy, float playingTime, int score, string result)
    {
        if (result.Equals("TIMEOUT"))
        {
            resultText.text = "시간초과..";
        }else if (result.Equals("SUCCESS"))
        {
            resultText.text = "성공!!";
        }
        else
        {
            resultText.text = "Err:ShowResultPage result is wrong";
        }
        totalClickText.text = click.ToString();
        accuracyText.text = string.Format("{0:0.00}", accuracy) + " %";
        playTimeText.text = string.Format("{0:0.0}", playingTime) + " s";
        totalScoreText.text = score.ToString();

        inGameCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        resultCanvas.SetActive(true);
    }

}
