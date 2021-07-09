using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    bool moveimpossible;
    bool isMove;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Turn();
    }
    // Player 이동 관련 (임시로 스페이스바를 누르면 코루틴 실행)
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(TestMoveCorutine());
        }
    }

    // 키보드 화살표에 따라서 왼쪽 or 오른쪽으로 회전
    private void Turn()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && !isMove) //왼쪽으로 회전
        {
            transform.Rotate(0, -90f, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isMove) //왼쪽으로 회전
        {
            transform.Rotate(0, 90f, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall") // Player의 한칸앞을 검사하여 벽이 있으면 못움직이게
        {
            print("바로 앞에 벽이있음");
            moveimpossible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall") // 정면에 벽이 있었는데 그 상황을 빠져나오면 움직일 수 있게
        {
            print("바로 앞에 벽이없음");
            moveimpossible = false;
        }
    }

    // 이동 관련 코루틴 (이동이 가능하다면 계속 한칸씩 이동)
    IEnumerator TestMoveCorutine()
    {
        while(true)
        {
            if (!moveimpossible)
            {
                transform.Translate(0, 0, 1);
                isMove = true;
            } 
            else
            {
                isMove = false;
                break;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
