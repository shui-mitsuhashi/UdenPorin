//�ǂ��㏸������X�C�b�`�̃X�N���v�gby�Ћ˕���

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRisingSwitch : MonoBehaviour
{
    public bool switchPushing = false; // �X�C�b�`��������Ă��邩
    public GameObject SwitchTrriger;
    public GameObject RisingGround;
    private Vector3 initialPosition; // �����ʒu
    [Header("�����鉺���ʒu������")]
    public float lowerLimit = -10f; // ������Y�ʒu
    [Header("������x�͑������������ǂ�")]
    public float speed = -5f; // �㉺���鑬�x

    // Start is called before the first frame update
    void Start()
    {
        // �����ʒu��ۑ�
        initialPosition = RisingGround.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchPushing)
        {
            // ���ɉ�����A�����܂ŒB������~�܂�
            if (RisingGround.transform.position.y > initialPosition.y + lowerLimit)
            {
                RisingGround.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            }
        }
        else
        {
            // �����ʒu�܂Ŗ߂�
            if (RisingGround.transform.position.y < initialPosition.y)
            {
                RisingGround.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            switchPushing = true;
        }
    }

    // �g���K�[����o����
    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switchPushing = false;
        }
    }*/

}
