using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneFloor : MonoBehaviour
{
    [Header("移動設定")]
    [Header("往復したい２点に空のオブジェクトを設置してここにアタッチ")]
    public Transform pointA; // 移動の始点
    public Transform pointB; // 移動の終点
    public float speed = 2f; // 移動速度

    private Vector3 targetPosition; // 現在の移動目標位置

    private void Start()
    {
        // 初期の目標位置を設定（PointBに向かう）
        targetPosition = pointB.position;
    }

    private void Update()
    {
        // 現在の位置から目標位置へ移動
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // 目標位置に到達したら反転
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Playerタグが付いたオブジェクトが触れたときにそのオブジェクトを子オブジェクトにする
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("CarryBox"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Playerタグが付いたオブジェクトが離れたときに親子関係を解除する
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("CarryBox"))
        {
            collision.transform.SetParent(null);
        }
    }

    // デバッグ用にギズモを描画（始点と終点を視覚化）
    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(pointA.position, pointB.position);
            Gizmos.DrawSphere(pointA.position, 0.2f);
            Gizmos.DrawSphere(pointB.position, 0.2f);
        }
    }
}
