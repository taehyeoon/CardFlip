using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    public bool isFliping; // 카드가 회전하고 있을 때 true
    public bool isCardFaceFront; // 카드가 앞면일 때 true
    public bool isFirstOpen; // 선택된 카드가 첫번째 open일 때 true
    public bool letItSpin; // ture가 되는 순간부터 180도 회전 시작
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
            GameObject tempTarget;
            // 클릭한 곳이 빈곳이 아님 && 선택한 객체가 gameObject && 회전중이 아닐 때
            if ((tempTarget = GetClickedObject()) != null && tempTarget.Equals(gameObject) && !isFliping)
            {
                target = tempTarget;
                initialAngle = target.transform.rotation.eulerAngles;
                card_Control.report(spriteIndex, gameObject);
            }
        }
        
        if (letItSpin)
        {
            if (timeCount <= 1)
            {
                target.transform.rotation = Quaternion.Lerp(Quaternion.Euler(new Vector3(initialAngle.x, initialAngle.y, initialAngle.z)), 
                    Quaternion.Euler(new Vector3(initialAngle.x, initialAngle.y + 180, initialAngle.z)), timeCount* cardFlipSpeed);
                timeCount += Time.deltaTime;
                isFliping = true;
            }
            else
            {
                reset();
            }
        }
        
    }
    public void init(int _indexSpriteBePrinted)
    {
        //Debug.Log("start called");
        card_Control = GameObject.Find("DrawCards").GetComponent<Card_Control>();
        //Debug.Log("index : " + _indexSpriteBePrinted);
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite 
            = card_Control.usingCardSprites[_indexSpriteBePrinted].Value;

        spriteIndex = card_Control.usingCardSprites[_indexSpriteBePrinted].Key;
        isFliping = false;
        isCardFaceFront = false;
        isFirstOpen = true;
        letItSpin = false;
        cardFlipSpeed = 6f;
        timeCount = 0.0f;
        target = null;
    }

    private void reset()
    {
        isFliping = false;
        letItSpin = false;
        isCardFaceFront = !isCardFaceFront;
        timeCount = 0;
        target = null;
        //Debug.Log(gameObject.name+  "  isCardFaceFront = " + isCardFaceFront);
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
    public void flipCard()
    {
        letItSpin = true;
    }
}
