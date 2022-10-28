using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayMode; // false인 상태에서는 마우스 입력 불가
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


        // score가 0에 도달하면 마우스 클릭 차단, 타이머 정지, 종료화면 출력
        
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
        // 모든 카드를 다 찾았다면 종료
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
