using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    public bool isFliping;
    public bool isCardFaceFront; 
    public float timeCount;
    public float cardFlipSpeed;
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
                //Debug.Log(target.name);
            }
        }
        
        if (target != null)
        {
//            Debug.Log("shot");
            if (timeCount <= 1 )
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
        Debug.Log("index : " + _indexSpriteBePrinted);
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite 
            = card_Control.usingCardSprites[_indexSpriteBePrinted].Value;

        isFliping = false;
        isCardFaceFront = false;
        cardFlipSpeed = 6f;
        timeCount = 0.0f;
        target = null;
    }

    private void reset()
    {
        isFliping = false;
        isCardFaceFront = !isCardFaceFront;
        timeCount = 0;
        target = null;
        Debug.Log(gameObject.name+  "  isCardFaceFront = " + isCardFaceFront);
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

}
