using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayMode; // false인 상태에서는 마우스 입력 불가
    public ScoreManager scoremanager;
    void Start()
    {
        isPlayMode = true;
    }

    
    void Update()
    {
        
    }

    public void reportFlipResult(bool iscorrect)
    {
        if (iscorrect)
        {
            scoremanager.AddScore(10);
        }
        else
        {
            scoremanager.SubstractScore(10);
        }
        // score가 0에 도달하면 마우스 클릭 차단, 타이머 정지, 종료화면 출력
        
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
