using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundScript : MonoBehaviour
{
    private string groundTag = "Ground";
    private string grabbableTag = "Grabbable";
    private string trampolineTag = "Trampoline"; // トランポリン用タグ
    public bool isGround = false;
    public bool isGroundEnter, isGroundStay, isGroundExit;
    public float bounceForce = 15f; // 跳ねる力
    public float bounceCoolDown = 0.1f;//トランポリンクールダウン
    public bool isBounceOk;//クールダウンが開けているならばtrue


    private Rigidbody playerRb;

    private void Start()
    {
        // 親オブジェクトの Rigidbody を取得
        playerRb = GetComponentInParent<Rigidbody>();

        isBounceOk = true;
    }

    // 接地判定を返すメソッド
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
        // 地面判定
        if (other.tag == groundTag||other.tag==grabbableTag)
        {
            isGroundEnter = true;
        }

        // トランポリン判定
        if (other.tag == trampolineTag)
        {
            if (playerRb != null)
            {
                if (isBounceOk)
                {
                    // 上方向に跳ねる力を加える
                    playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z); // 縦方向の速度をリセット
                    playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
                    isBounceOk = false;
                }             
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // 地面に触れている場合の処理
        if (other.tag == groundTag || other.tag == grabbableTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 地面から離れた場合の処理
        if (other.tag == groundTag || other.tag == grabbableTag)
        {
            isGroundExit = true;
        }
    }

    void Update()
    {
        // 毎フレーム接地状態を更新
        Ground();

        if(!isBounceOk)
        {
            // クールダウンタイマーをカウント
            bounceCoolDown -= Time.deltaTime;

            // クールダウンが完了したら isBounceOk を true に戻す
            if (bounceCoolDown <= 0f)
            {
                isBounceOk = true;
                bounceCoolDown = 0.1f; // クールダウンタイマーをリセット
            }
        }
    }
}