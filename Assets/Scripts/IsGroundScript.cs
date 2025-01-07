using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundScript : MonoBehaviour
{
    private string groundTag = "Ground";
    private string grabbableTag = "Grabbable";
    private string trampolineTag = "Trampoline"; // �g�����|�����p�^�O
    public bool isGround = false;
    public bool isGroundEnter, isGroundStay, isGroundExit;
    public float bounceForce = 15f; // ���˂��
    public float bounceCoolDown = 0.1f;//�g�����|�����N�[���_�E��
    public bool isBounceOk;//�N�[���_�E�����J���Ă���Ȃ��true


    private Rigidbody playerRb;

    private void Start()
    {
        // �e�I�u�W�F�N�g�� Rigidbody ���擾
        playerRb = GetComponentInParent<Rigidbody>();

        isBounceOk = true;
    }

    // �ڒn�����Ԃ����\�b�h
    public bool Ground()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter(Collider other)
    {
        // �n�ʔ���
        if (other.tag == groundTag||other.tag==grabbableTag)
        {
            isGroundEnter = true;
        }

        // �g�����|��������
        if (other.tag == trampolineTag)
        {
            if (playerRb != null)
            {
                if (isBounceOk)
                {
                    // ������ɒ��˂�͂�������
                    playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z); // �c�����̑��x�����Z�b�g
                    playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
                    isBounceOk = false;
                }             
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // �n�ʂɐG��Ă���ꍇ�̏���
        if (other.tag == groundTag || other.tag == grabbableTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �n�ʂ��痣�ꂽ�ꍇ�̏���
        if (other.tag == groundTag || other.tag == grabbableTag)
        {
            isGroundExit = true;
        }
    }

    void Update()
    {
        // ���t���[���ڒn��Ԃ��X�V
        Ground();

        if(!isBounceOk)
        {
            // �N�[���_�E���^�C�}�[���J�E���g
            bounceCoolDown -= Time.deltaTime;

            // �N�[���_�E�������������� isBounceOk �� true �ɖ߂�
            if (bounceCoolDown <= 0f)
            {
                isBounceOk = true;
                bounceCoolDown = 0.1f; // �N�[���_�E���^�C�}�[�����Z�b�g
            }
        }
    }
}