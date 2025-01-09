using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Vector3 focusPoint;

    private Vector3 offset = new Vector3(0, 1.2f, -3f);
    public float moveSpeed = 5f; // カメラが移動する速度

    void LateUpdate()
    {
        // プレイヤー間のフォーカスポイントを計算
        focusPoint.x = (player1.position.x * 4 + player2.position.x * 3) / 7;
        focusPoint.z = (player1.position.z * 4 + player2.position.z * 3) / 7;

        // 目標位置を計算
        Vector3 targetPosition = focusPoint + offset;

        // カメラの位置を一定速度で目標位置に近づける
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}