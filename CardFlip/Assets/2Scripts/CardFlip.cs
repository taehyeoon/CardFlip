using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    private static CardFlip instance;
    public static CardFlip Instance { get { return instance; } }

    public bool isStart;
    public bool isFliping; // 카드가 회전하고 있을 때 true
    public bool isCardFaceFront; // 카드가 앞면일 때 true
    public bool isLastCheck;

    public int spriteIndex; // 오브젝트에 적용된 스프라이트의 인덱스
    public float timeCount; // 회전되는 시간 카운트
    public float cardFlipSpeed; // 카드 회전 속도
    
    public Vector3 initialAngle;
    public GameObject target;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (GameManager.Instance.GetisPlayMode())
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (gameObject.Equals(GetClickedObject()))
                {
                    Card_Control.Instance.report(spriteIndex, gameObject);
                }
            }
        }

        if (isFliping)
        {
            if (timeCount * cardFlipSpeed <= 1)
            {
                target.transform.rotation = Quaternion.Lerp(Quaternion.Euler(new Vector3(initialAngle.x, initialAngle.y, initialAngle.z)),
                    Quaternion.Euler(new Vector3(initialAngle.x, initialAngle.y + 180, initialAngle.z)), timeCount * cardFlipSpeed);
                timeCount += Time.deltaTime;
            }
            else
            {
                // Accept mouse click
                if (isLastCheck && !isCardFaceFront)
                {
                    GameManager.Instance.SetisPlayMode(true);
                }
                reset();
            }
        }  
    }


    public void init(int indexSpriteBePrinted)
    {
        // Get Sprite and index of Sprite
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite 
            = Card_Control.Instance.usingCardSprites[indexSpriteBePrinted].Value;
        spriteIndex = Card_Control.Instance.usingCardSprites[indexSpriteBePrinted].Key;

        isFliping = false;
        isCardFaceFront = false;
        isLastCheck = false;
        cardFlipSpeed = 6f;
        timeCount = 0.0f;
        target = gameObject;
    }

    private void reset()
    {
        isFliping = false;
        timeCount = 0;
        isLastCheck = false;
    }

    private GameObject GetClickedObject()
    {
        //충돌이 감지된 영역
        RaycastHit hit;
        GameObject target = null;

        //마우스 포인트 근처 좌표를 만든다.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //마우스 근처에 오브젝트가 있는지 확인
        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            target = hit.collider.gameObject;
        }
        
        return target;
    }
    
    // Flip card 180 degree
    public void flipCard(bool last, bool isState)
    {
        initialAngle = target.transform.rotation.eulerAngles;
        isLastCheck = last;
        isFliping = true;
        isCardFaceFront = isState;
    }

    public IEnumerator FlipOnce(/*bool[,] state, */GameObject card, int i, int j, float _start_time)
    {
        float time = 0f;
        float speed = 6f;
        float start_time = _start_time;
        bool isDone = false;

        Vector3 pos = gameObject.transform.rotation.eulerAngles;
        //Debug.Log(gameObject);
        while (!isDone)
        { 
            if (start_time < 0)
            {
                card.transform.rotation = Quaternion.Lerp(Quaternion.Euler(new Vector3(pos.x, pos.y, pos.z)),
                    Quaternion.Euler(new Vector3(pos.x, pos.y + 180, pos.z)), time * speed);

                if (time * speed > 1) isDone = true;
                else time += Time.deltaTime;
            }
            else
            {
                start_time -= Time.deltaTime;
            }
            yield return null;

        }
        // state[i, j] = true;
    }


}
