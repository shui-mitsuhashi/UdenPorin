using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform�������ɃA�^�b�`

    // �J�����ƃv���C���[�̃I�t�Z�b�g
    private Vector3 offset = new Vector3(0, 4.2f, -16f);

    void LateUpdate()
    {
        // �v���C���[�̍��W�ɃI�t�Z�b�g�������ăJ������Ǐ]������
        transform.position = player.position + offset;
    }
}