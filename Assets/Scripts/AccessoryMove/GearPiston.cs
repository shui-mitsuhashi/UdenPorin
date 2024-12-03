using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearPiston : MonoBehaviour
{
    [Header("移動設定")]
    public float upperLimit = 5f;  // 上限位置
    public float lowerLimit = 0f;  // 下限位置
    public float speed = 2f;       // 移動速度
    public float interval = 1f;    // 最高点・最低点での停止時間

    private bool movingUp = true;  // 現在上方向に移動中か
    private bool isPaused = false; // 一時停止中かどうか

    void Update()
    {
        if (isPaused) return; // 一時停止中は動作しない

        // 現在の位置を取得
        Vector3 currentPosition = transform.position;

        // 上方向に移動中の場合
        if (movingUp)
        {
            currentPosition.y += speed * Time.deltaTime;
            if (currentPosition.y >= upperLimit)
            {
                currentPosition.y = upperLimit;
                StartCoroutine(PauseMovement(false)); // 下方向に変更
            }
        }
        else
        {
            // 下方向に移動
            currentPosition.y -= speed * Time.deltaTime;
            if (currentPosition.y <= lowerLimit)
            {
                currentPosition.y = lowerLimit;
                StartCoroutine(PauseMovement(true)); // 上方向に変更
            }
        }

        // オブジェクトの位置を更新
        transform.position = currentPosition;
    }

    // 一時停止を行うコルーチン
    private IEnumerator PauseMovement(bool newDirection)
    {
        isPaused = true; // 動作を停止
        yield return new WaitForSeconds(interval); // 指定時間待機
        movingUp = newDirection; // 移動方向を更新
        isPaused = false; // 動作を再開
    }
}
