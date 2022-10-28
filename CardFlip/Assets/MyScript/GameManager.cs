using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayMode; // false�� ���¿����� ���콺 �Է� �Ұ�
    public ScoreManager scoreManager;
    public TimeManager timeManager;
    void Start()
    {
        isPlayMode = true;
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }

    
    void Update()
    {
        isGameEnd();
    }

    public void reportFlipResult(bool iscorrect)
    {
        if (iscorrect)
        {
            scoreManager.AddScore(10);
        }
        else
        {
            scoreManager.SubstractScore(10);
        }


        // score�� 0�� �����ϸ� ���콺 Ŭ�� ����, Ÿ�̸� ����, ����ȭ�� ���
        
    }

    public bool isGameEnd()
    {
        if(scoreManager.getScore() == 0)
        {
            Debug.Log("end");
            return true;
        }

        if(timeManager.getTime() == 0.0)
        {
            Debug.Log("end");
            return true;
        }

        //if(Card_Control.)
        // ��� ī�带 �� ã�Ҵٸ� ����
        // if()

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
}
