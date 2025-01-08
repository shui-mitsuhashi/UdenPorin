using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAnimation : MonoBehaviour
{
    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����
    private int JumpframeCount = 0;  // �t���[���J�E���g�p�ϐ�
    private int StretchframeCount = 0;
    public int JumpFrames = 32; // �ڕW�t���[����
    public int StretchFrames = 180;
    private bool isJumping = false;
    private bool isStretch = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("JoystickHorizontal2");

        //�����A�X�e�B�b�N���|���ꂽ��
        if (horizontal >= -0.2f && horizontal <= 0.2f)
        {
            //Bool�^�̃p�����[�^�[�ł���BuulRun��True�ɂ���
            anim.SetBool("BoolRun", false);
        }
        else
        {
            //Bool�^�̃p�����[�^�[�ł���BoolRun��false�ɂ���
            anim.SetBool("BoolRun", true);
        }

        if (!isJumping && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("BlueJump")))
        {
            anim.SetBool("BoolJump", true);
            isJumping = true;
            JumpframeCount = 0; // �t���[���J�E���g�����Z�b�g
        }

        // �W�����v���̏���
        if (isJumping)
        {
            JumpframeCount++;

            // �t���[�������ڕW�ɒB������W�����v�I��
            if (JumpframeCount >= JumpFrames)
            {
                anim.SetBool("BoolJump", false);
                isJumping = false;
            }
        }

        //�r�L�΂�
        if (!isStretch && (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("OretaRTrigger") > 0.1f))
        {
            anim.SetBool("BoolStretch", true);
            isStretch = true;
            StretchframeCount = 0; // �t���[���J�E���g�����Z�b�g
        }

        // �W�����v���̏���
        if (isStretch)
        {
            StretchframeCount++;

            // �t���[�������ڕW�ɒB������W�����v�I��
            if (StretchframeCount >= JumpFrames)
            {
                anim.SetBool("BoolStretch", false);
                isStretch = false;
            }
        }
    }
}