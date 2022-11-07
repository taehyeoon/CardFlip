using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    float time;
    public float _fadeTime = 1.5f;
    Vector3 dir;
    void Start()
    {
        
    }
    public void init(int score)
    {
        time = 0.0f;
        dir = new Vector3(0, Random.Range(0, 1f), 0).normalized;
        GetComponent<Text>().text = "+" + score;
    }
    void Update()
    {
        // Move
        transform.Translate(dir * Time.deltaTime);

/*        // Bigger
        transform.localScale = Vector3.one * (1 + time);
        if (time > 1f)
        {
            gameObject.SetActive(false);
        }*/

        // Fadeout
        if (time < _fadeTime)
        {
            //GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f - time / _fadeTime);
            GetComponent<Text>().color = new Color(0, 0, 0, 1f - time / _fadeTime);
        }
        else
        {
            time = 0;
            this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        time += Time.deltaTime;
    }
    public void resetAnim()
    {
        transform.position = new Vector3(0, 4.85f, 0);
        dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -1).normalized;
    }

}
