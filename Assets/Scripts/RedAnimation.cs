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
        if (horizontal >= -0.5f && horizontal <= 0.5f)
        {
            //Bool型のパラメーターであるBuulRunをTrueにする
            anim.SetBool("BoolRun", false);
        }
        else
        {
            //Bool型のパラメーターであるBoolRunをfalseにする
            anim.SetBool("BoolRun", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Bool�^�̃p�����[�^�[�ł���blRot��True�ɂ���
            anim.SetBool("BoolJump", true);
        }


    }
}
