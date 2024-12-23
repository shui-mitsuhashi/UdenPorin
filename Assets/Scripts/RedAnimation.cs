using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAnimation : MonoBehaviour
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

        //もし、スティックが倒されたら
        if (horizontal < -0.5f)
        {
            //Bool型のパラメーターであるBoolRunをTrueにする
            anim.SetBool("BoolRun", true);
        }
        else if (horizontal > -0.5f)
        {
            //Bool型のパラメーターであるBoolRunをfalseにする
            anim.SetBool("BoolRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Bool�^�̃p�����[�^�[�ł���blRot��True�ɂ���
            anim.SetBool("BoolJump", true);
        }


    }
}
