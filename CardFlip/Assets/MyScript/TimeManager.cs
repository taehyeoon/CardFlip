using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for Text


public class TimeManager : MonoBehaviour
{
    public float LimitTime;
    public Text text_Timer;
    
    void Start()
    {
        LimitTime = 10.0f;
    }

    
    void Update()
    {
        if(LimitTime >= 0.0f)
        {
            // �Ҽ����� ���ܽ�Ű�� ǥ��
            text_Timer.text = "�ð� : " + Mathf.Round(LimitTime);
            LimitTime -= Time.deltaTime;
        }
        else
        {
            text_Timer.text = "�ð� : 0";
            LimitTime = 0;
        }
        

    }

    public float getTime()
    {
        return LimitTime;
    }
}
