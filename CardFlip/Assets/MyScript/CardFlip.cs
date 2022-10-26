using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    public bool isFliping; // 카드가 회전하고 있을 때 true
    public bool isCardFaceFront; // 카드가 앞면일 때 tru
    public bool isLastCheck = false;
    public int spriteIndex; // 오브젝트에 적용된 스프라이트의 인덱스
    public float timeCount; // 회전되는 시간 카운트
    public float cardFlipSpeed; // 카드 회전 속도
    public Vector3 initialAngle;
    public GameObject target;
    public Card_Control card_Control;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (card_Control.GetisPlayMode())
            {
                if (gameObject.Equals(GetClickedObject()))
                {
                    card_Control.report(spriteIndex, gameObject);
                }
            }
        }

        if (isFliping)
        {
            if (timeCount <= 1)
            {
                target.transform.rotation = Quaternion.Lerp(Quaternion.Euler(new Vector3(initialAngle.x, initialAngle.y, initialAngle.z)), 
                    Quaternion.Euler(new Vector3(initialAngle.x, initialAngle.y + 180, initialAngle.z)), timeCount* cardFlipSpeed);
                timeCount += Time.deltaTime;
                //isFliping = true;
            }
            else
            {
                if (isLastCheck) card_Control.SetPlayMode(true);
                reset();
            }
        }
        
    }
    public void init(int indexSpriteBePrinted)
    {
        card_Control = GameObject.Find("DrawCards").GetComponent<Card_Control>();

        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite 
            = card_Control.usingCardSprites[indexSpriteBePrinted].Value;
        spriteIndex = card_Control.usingCardSprites[indexSpriteBePrinted].Key;

        isFliping = false;
        isCardFaceFront = false;
        cardFlipSpeed = 6f;
        timeCount = 0.0f;
        target = gameObject;
    }

    private void reset()
    {
        isFliping = false;
        isCardFaceFront = !isCardFaceFront;
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
    
    // control에서 이 함수를 호출 시 카드를 180도 회전
    public void flipCard(bool last)
    {
        initialAngle = target.transform.rotation.eulerAngles;
        isLastCheck = last;
        isFliping = true;
    }
}
