using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public GameObject bg;
    public Image bgimage;
    public Sprite[] bgspr;
    int count;
    // Start is called before the first frame update
    void Start() // 1ȸ 
    {
        Debug.Log("onStart");
    }
    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetBG()
    {
        if (count == 1)
        {
            count = 0;
        }
        else
        {
            count++;
        }
        bg.GetComponent<Image>().sprite = bgspr[count];
      //  bgimage.sprite = bgspr[count];
        Debug.Log("abc");

    }
    private void OnEnable()
    {
        Debug.Log("onEnable");
    }
    private void OnDisable()
    {
        
        Debug.Log("OnDisable");
    }
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
