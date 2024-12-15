using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ArmStretc : MonoBehaviour
{
    public GameObject targetObject;  // �Ώۂ̃I�u�W�F�N�g
    public GameObject trampoline;
    private Collider trampolineCollider; // �g�����|�����̃R���C�_�[
    public float scaleSpeed = 2f;    // �X�P�[���̕ω����x
    private Vector3 originalScale;   // ���̃X�P�[��
    private bool isScaling = false;  // �X�P�[����傫������t���O

    void Start()
    {
        if (targetObject != null)
        {
            // �ΏۃI�u�W�F�N�g�̌��̃X�P�[�����L�^
            originalScale = targetObject.transform.localScale;
        }

        if (trampoline != null)
        {
            // �g�����|�����̃R���C�_�[���擾
            trampolineCollider = trampoline.GetComponent<Collider>();

            // �g�����|�����̃R���C�_�[��������ԂŖ�����
            if (trampolineCollider != null)
            {
                trampolineCollider.enabled = false;
            }
        }
    }

    void Update()
    {
        if (targetObject == null) return;

        // ���̓`�F�b�N�i�L�[�{�[�hE�L�[ or Xbox�R���g���[���[�E�g���K�[�j
        if (Input.GetKey(KeyCode.E) || Input.GetAxis("MonotaRTrigger") > 0.1f)
        {
            isScaling = true;  // �X�P�[����傫������
        }
        else
        {
            isScaling = false; // �X�P�[�������ɖ߂�
        }

        // �X�P�[���̍X�V
        UpdateScale();

        // �g�����|�����̃R���C�_�[�̗L����/������
        UpdateTrampolineCollider();
    }

    void UpdateScale()
    {
        Vector3 currentScale = targetObject.transform.localScale;

        if (isScaling)
        {
            // X�X�P�[�������X��2�{�܂Ŋg��
            float targetXScale = originalScale.x * 10;
            currentScale.x = Mathf.MoveTowards(currentScale.x, targetXScale, scaleSpeed * Time.deltaTime);
        }
        else
        {
            // X�X�P�[�������X�Ɍ��̃T�C�Y�֖߂�
            currentScale.x = Mathf.MoveTowards(currentScale.x, originalScale.x, scaleSpeed * Time.deltaTime);
        }

        // �X�P�[�����X�V
        targetObject.transform.localScale = currentScale;
    }

    void UpdateTrampolineCollider()
    {
        if (trampolineCollider == null) return;

        // targetObject��originalScale�ȏ�̂Ƃ��ɃR���C�_�[��L����
        if (targetObject.transform.localScale.x > originalScale.x)
        {
            trampolineCollider.enabled = true;
        }
        else
        {
            trampolineCollider.enabled = false;
        }
    }
}
