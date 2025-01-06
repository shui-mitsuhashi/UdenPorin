using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAnimation : MonoBehaviour
{
    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����
    public bool isJump = true; // ������Ԃ�true�ɐݒ�
    private int frameCount = 0;  // �t���[���J�E���g�p�ϐ�
    public int JumpFrames = 60; // �ڕW�t���[����
    private bool isJumping = false;

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
        if (horizontal >= -0.5f && horizontal <= 0.5f)
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
            frameCount = 0; // �t���[���J�E���g�����Z�b�g
        }

        // �W�����v���̏���
        if (isJumping)
        {
            frameCount++;

            // �t���[�������ڕW�ɒB������W�����v�I��
            if (frameCount >= JumpFrames)
            {
                anim.SetBool("BoolJump", false);
                isJumping = false;
            }
        }
    }
}
