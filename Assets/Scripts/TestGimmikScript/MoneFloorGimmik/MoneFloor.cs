using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneFloor : MonoBehaviour
{
    [Header("�ړ��ݒ�")]
    [Header("�����������Q�_�ɋ�̃I�u�W�F�N�g��ݒu���Ă����ɃA�^�b�`")]
    public Transform pointA; // �ړ��̎n�_
    public Transform pointB; // �ړ��̏I�_
    public float speed = 2f; // �ړ����x

    private Vector3 targetPosition; // ���݂̈ړ��ڕW�ʒu

    private void Start()
    {
        // �����̖ڕW�ʒu��ݒ�iPointB�Ɍ������j
        targetPosition = pointB.position;
    }

    private void Update()
    {
        // ���݂̈ʒu����ڕW�ʒu�ֈړ�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // �ڕW�ʒu�ɓ��B�����甽�]
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Player�^�O���t�����I�u�W�F�N�g���G�ꂽ�Ƃ��ɂ��̃I�u�W�F�N�g���q�I�u�W�F�N�g�ɂ���
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("CarryBox"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Player�^�O���t�����I�u�W�F�N�g�����ꂽ�Ƃ��ɐe�q�֌W����������
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("CarryBox"))
        {
            collision.transform.SetParent(null);
        }
    }

    // �f�o�b�O�p�ɃM�Y����`��i�n�_�ƏI�_�����o���j
    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(pointA.position, pointB.position);
            Gizmos.DrawSphere(pointA.position, 0.2f);
            Gizmos.DrawSphere(pointB.position, 0.2f);
        }
    }
}
