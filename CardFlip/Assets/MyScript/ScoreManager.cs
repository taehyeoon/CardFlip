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

        // ���� ���ϱ�.
        public void Add(int score)
        {
            Assert(score);
            _score += score;
            Clamp();
        }
        // ���� ����
        public void Sub(int score)
        {
            Assert(score);
            _score -= score;
            Clamp();
        }
        // ���ھ� �ʱ�ȭ.
        public void Clear()
        {
            _score = 100;
        }

        // ������ ������ ����.
        private void Clamp()
        {
            _score = Mathf.Min(_score, _scoreMax);
            _score = Mathf.Max(_score, _scoreMin);
        }

        // �߰� ���ھ� ������ ��ȿ�� �˻�.
        private bool Assert(int score)
        {
            if (_min <= score && score <= _max)
                return true;
            else
            {
                Debug.LogWarning("�߰� ���ھ� �����Ͱ� �߸��Ǿ����ϴ�.");
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
