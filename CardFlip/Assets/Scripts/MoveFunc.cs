using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFunc : MonoBehaviour
{
    Vector3 rotKeyT;

    // Start is called before the first frame update
    void Start()
    {
        rotKeyT = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position = this.transform.position + new Vector3(0, 0, 1) * Time.deltaTime;
            Debug.Log("push W : " + transform.position.ToString());
        }else if (Input.GetKey(KeyCode.S)){
            this.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
            Debug.Log("push s : " + transform.position.ToString());
        }else if (Input.GetKey(KeyCode.R))
        {
            // 현재 tranform 값을 이용하면 경계값에서 실제 값과 내부적인 값이 달라진다
            // 객체가 경계값에서 더이상 회전하지 않는 문제 발생
            this.transform.eulerAngles = transform.eulerAngles + new Vector3(90, 0, 0) * Time.deltaTime;
            Debug.Log(transform.eulerAngles);
        }else if (Input.GetKey(KeyCode.T))
        {
            // rotKeyT 변수를 설졍하여 변수값을 조절 후 tranform에 대입
            /*rotKeyT = rotKeyT + new Vector3(90, 0, 0) * Time.deltaTime;
            this.transform.eulerAngles = rotKeyT;*/
            this.transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime);
            Debug.Log(transform.eulerAngles);
        }else if (Input.GetKey(KeyCode.Y))
        {
            // Quaternion 이용

        }
    }
}
