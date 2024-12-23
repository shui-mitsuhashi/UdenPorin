using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAnimation : MonoBehaviour
{
    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����

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
        if (horizontal < -0.5f)
        {
            //Bool�^�̃p�����[�^�[�ł���BuulRun��True�ɂ���
            anim.SetBool("BoolRun", true);
        }
        else if (horizontal > -0.5f)
        {
            //Bool�^�̃p�����[�^�[�ł���BoolRun��false�ɂ���
            anim.SetBool("BoolRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Bool?^??p?????[?^?[?????blRot??True?????
            anim.SetBool("BoolJump", true);
        }
    }
}
