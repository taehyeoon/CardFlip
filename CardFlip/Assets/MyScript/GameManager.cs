using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreManager scoremanager;
    void Start()
    {
        //scoremanager = GameObject.Find("SocreManager").GetComponent<ScoreManager>();
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
    }


}
