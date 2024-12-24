using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAnimation : MonoBehaviour
{
    private Animator anim;  //Animatorをanimという変数で定義する

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
            //Bool型のパラメーターであるBuulRunをTrueにする
            anim.SetBool("BoolRun", true);
        }
        else if (horizontal > -0.5f)
        {
            //Bool型のパラメーターであるBoolRunをfalseにする
            anim.SetBool("BoolRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Bool?^??p?????[?^?[?????blRot??True?????
            anim.SetBool("BoolJump", true);
        }
    }
}
