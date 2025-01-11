using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAnimation : MonoBehaviour
{
    private Animator anim;  //Animatorをanimという変数で定義する
    private int JumpframeCount = 0;  // フレームカウント用変数
    private int StretchframeCount = 0;
    public int JumpFrames = 32; // 目標フレーム数
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
        float horizontal = Input.GetAxis("JoystickHorizontal1");

        //もし、スティックが倒されたら
        if (horizontal >= -0.2f && horizontal <= 0.2f)
        {
            //Bool型のパラメーターであるBuulRunをTrueにする
            anim.SetBool("BoolRun", false);
        }
        else
        {
            //Bool型のパラメーターであるBoolRunをfalseにする
            anim.SetBool("BoolRun", true);
        }

        if (!isJumping && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("RedJump")))
        {
            anim.SetBool("BoolJump", true);
            isJumping = true;
            JumpframeCount = 0; // フレームカウントをリセット
        }

        // ジャンプ中の処理
        if (isJumping)
        {
            JumpframeCount++;

            // フレーム数が目標に達したらジャンプ終了
            if (JumpframeCount >= JumpFrames)
            {
                anim.SetBool("BoolJump", false);
                isJumping = false;
            }
        }

        //腕伸ばし
        if (!isStretch && (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("MonotaRTrigger") > 0.1f))
        {
            anim.SetBool("BoolStretch", true);
            isStretch = true;
            StretchframeCount = 0; // フレームカウントをリセット
        }

        // ジャンプ中の処理
        if (isStretch)
        {
            StretchframeCount++;

            // フレーム数が目標に達したらジャンプ終了
            if (StretchframeCount >= StretchFrames)
            {
                anim.SetBool("BoolStretch", false);
                isStretch = false;
            }
        }
    }
}
