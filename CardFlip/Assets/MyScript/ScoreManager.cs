using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public class Score
    {
        public int _score = 100;
        public int _min = 0;
        public int _max = 10000;
        public int _scoreMax = 9999999;
        public int _scoreMin = 0;

        // 점수 더하기.
        public void Add(int score)
        {
            Assert(score);
            _score += score;
            Clamp();
        }
        // 점수 빼기
        public void Sub(int score)
        {
            Assert(score);
            _score -= score;
            Clamp();
        }
        // 스코어 초기화.
        public void Clear()
        {
            _score = 100;
        }

        // 점수의 상하한 보정.
        private void Clamp()
        {
            _score = Mathf.Min(_score, _scoreMax);
            _score = Mathf.Max(_score, _scoreMin);
        }

        // 추가 스코어 데이터 유효성 검사.
        private bool Assert(int score)
        {
            if (_min <= score && score <= _max)
                return true;
            else
            {
                Debug.LogWarning("추가 스코어 데이터가 잘못되었습니다.");
                return false;
            }
        }
        
    }

    public Score score;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        score = new Score();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "score\n" + score._score;
    }

    public void AddScore(int plusScore)
    {
        score.Add(plusScore);
    }

    public void SubstractScore(int minusScore)
    {
        score.Sub(minusScore);
    }

    public int getScore()
    {
        return score._score;
    }


}
