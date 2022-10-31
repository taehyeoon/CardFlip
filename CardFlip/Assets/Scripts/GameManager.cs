using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public bool isPlayMode; // false인 상태에서는 마우스 입력 불가
    public bool freeze;
    public int score;
    public int unitScore;
    public int combo;
    public int openCardNum;
    public int clickCount;
    public int cardNumberOfSingleline; // 한 줄의 카드 개수
    public float time;

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
        time = 60.0f;
    }

    
    void Update()
    {
        if (!freeze)
        {
            ReduceTime();
            UpdateUI();
            if (isGameEnd())
            {
                //
            }
        }

    }

    public void UpdateUI()
    {
        UIManager.Instance.UpdateScoreText(score);
        UIManager.Instance.UpdateTimeText(time);
    }
    public void AddScore()
    {
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
        if(time <= 0.0f)
        {
            time = 0.0f;
        }
        else
        {
            time -= Time.deltaTime;
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
    public bool isGameEnd()
    {
        if(time == 0.0f)
        {
            return true;
        }

        if (openCardNum == cardNumberOfSingleline * cardNumberOfSingleline)
        {
            return true;
        }

        return false;
    }

    public void SetPlayMode(bool state)
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
