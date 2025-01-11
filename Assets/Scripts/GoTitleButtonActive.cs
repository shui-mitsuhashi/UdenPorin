using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTitleButtonActive : MonoBehaviour
{
    public float delay = 12f; // �ړ����J�n����܂ł̒x�����ԁi�b�j
    public float moveDistance = 200f; // ��Ɉړ����鋗��
    public float moveDuration = 1f; // �ړ��ɂ����鎞�ԁi�b�j

    private RectTransform rectTransform;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float elapsedTime = 0f;
    private bool isMoving = false;

    void Start()
    {
        // RectTransform���擾
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("���̃X�N���v�g��UI�I�u�W�F�N�g�ɃA�^�b�`���Ă��������I");
            enabled = false;
            return;
        }

        // �����ʒu��ۑ�
        startPosition = rectTransform.anchoredPosition;

        // �^�[�Q�b�g�ʒu���v�Z
        targetPosition = startPosition + new Vector2(0, moveDistance);

        // �x����Ɉړ����J�n
        Invoke(nameof(StartMoving), delay);
    }

    void StartMoving()
    {
        isMoving = true;
    }

    void Update()
    {
        if (!isMoving) return;

        // �ړ�����`��ԂŎ���
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / moveDuration);
        rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);

        // �ړ��������������~
        if (t >= 1f)
        {
            isMoving = false;
        }
    }
}
