using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public bool isPlayMode; // false인 상태에서는 마우스 입력 불가
    public bool freeze; // time freeze

    public int score;
    public int unitScore;
    public int combo;
    public int openCardNum;
    public int clickCount;
    public int cardNumberOfSingleline; // 한 줄의 카드 개수

    public float currentTime;
    public float limitTime;

    public GameObject addScorePrefab;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        Init();
    }
    public void Init()
    {
        isPlayMode = true;
        freeze = false;
        score = 0;
        unitScore = 10;
        openCardNum = 0;
        combo = 1;
        cardNumberOfSingleline = 4;
        clickCount = 0;
        limitTime = 60.0f;
        currentTime = limitTime;
    }

    
    void Update()
    {
        if (!freeze)
        {
            ReduceTime();
            UpdateUI();
            IsGameEnd();
        }
    }

    public void UpdateUI()
    {
        UIManager.Instance.UpdateScoreText(score);
        UIManager.Instance.UpdateTimeText(currentTime);
    }
    public void AddScore()
    {
        GameObject p_obj = GameObject.Find("Score");
        GameObject s = Instantiate(addScorePrefab, new Vector3(0,0, 0), Quaternion.identity, p_obj.transform);
        s.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,50);
        s.GetComponent<Animation>().init(unitScore * combo);

        score += unitScore * combo;
        combo += 1;
    }
    public void PlusOpenCardNum()
    {
        openCardNum += 2;
    }

    public void PlusClickCount()
    {
        clickCount += 1;
    }

    public void ReduceTime()
    {
        if(currentTime <= 0.0f)
        {
            currentTime = 0.0f;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    public void ResetCombo()
    {
        combo = 1;
    }

    public int GetCardNumberOfSingleline()
    {
        return cardNumberOfSingleline;
    }

    public void SetFreeze(bool value)
    {
        freeze = value;
    }

    public void IsGameEnd()
    {
        float acc;
        if (currentTime == 0.0f)
        {
            if (clickCount == 0)
            {
                acc = 0.0f;
            }
            else
            {
                acc = (openCardNum / 2) * 100 / (float)clickCount;
            }
            UIManager.Instance.ShowResultPage(clickCount, acc, limitTime - currentTime, score, "TIMEOUT");
            SetFreeze(true);
        } 
        else if (openCardNum == cardNumberOfSingleline * cardNumberOfSingleline)
        {
            if (clickCount == 0)
            {
                acc = 0.0f;
            }
            else
            {
                acc = (openCardNum / 2) * 100 / (float)clickCount;
            }
            UIManager.Instance.ShowResultPage(clickCount, acc, limitTime - currentTime, score, "SUCCESS");

            SetFreeze(true);
        }
    }

    public void SetisPlayMode(bool state)
    {
        isPlayMode = state;
    }

    public bool GetisPlayMode()
    {
        return isPlayMode;
    }

    public void ResetGame()
    {
        Init();
        Card_Control.Instance.Init();
    }


}
