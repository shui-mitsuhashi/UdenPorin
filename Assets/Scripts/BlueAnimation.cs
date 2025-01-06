using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAnimation : MonoBehaviour
{
    private Animator anim;  //Animatorをanimという変数で定義する
    public bool isJump = true; // 初期状態をtrueに設定
    private int frameCount = 0;  // フレームカウント用変数
    public int JumpFrames = 60; // 目標フレーム数
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

        if (!isJumping && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("BlueJump")))
        {
            anim.SetBool("BoolJump", true);
            isJumping = true;
            frameCount = 0; // フレームカウントをリセット
        }

        // ジャンプ中の処理
        if (isJumping)
        {
            frameCount++;

            // フレーム数が目標に達したらジャンプ終了
            if (frameCount >= JumpFrames)
            {
                anim.SetBool("BoolJump", false);
                isJumping = false;
            }
        }
    }
}
