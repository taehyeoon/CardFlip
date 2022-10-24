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

            // Ŭ���� ���� ����� �ƴ� && ������ ��ü�� gameObject && ȸ������ �ƴ� ��
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
        //�浹�� ������ ����
        RaycastHit hit;
        GameObject target = null;

        //���콺 ����Ʈ ��ó ��ǥ�� �����.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //���콺 ��ó�� ������Ʈ�� �ִ��� Ȯ��
        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }

}
