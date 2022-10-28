using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayMode; // false�� ���¿����� ���콺 �Է� �Ұ�
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
        // score�� 0�� �����ϸ� ���콺 Ŭ�� ����, Ÿ�̸� ����, ����ȭ�� ���
        
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
