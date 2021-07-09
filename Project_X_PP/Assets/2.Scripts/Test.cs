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
    // Player �̵� ���� (�ӽ÷� �����̽��ٸ� ������ �ڷ�ƾ ����)
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(TestMoveCorutine());
        }
    }

    // Ű���� ȭ��ǥ�� ���� ���� or ���������� ȸ��
    private void Turn()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && !isMove) //�������� ȸ��
        {
            transform.Rotate(0, -90f, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isMove) //�������� ȸ��
        {
            transform.Rotate(0, 90f, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall") // Player�� ��ĭ���� �˻��Ͽ� ���� ������ �������̰�
        {
            print("�ٷ� �տ� ��������");
            moveimpossible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall") // ���鿡 ���� �־��µ� �� ��Ȳ�� ���������� ������ �� �ְ�
        {
            print("�ٷ� �տ� ���̾���");
            moveimpossible = false;
        }
    }

    // �̵� ���� �ڷ�ƾ (�̵��� �����ϴٸ� ��� ��ĭ�� �̵�)
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
