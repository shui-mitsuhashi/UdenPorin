using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f; // 回転速度
    public float gravity = -9.81f; // 重力
    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector3 verticalVelocity; // 垂直速度

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // WASDキーによる移動入力
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 移動方向を計算（高さはゼロに設定）
        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // キャラクターを移動させる
        if (moveDirection.magnitude >= 0.1f)
        {
            // 向きを移動方向に合わせる
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // 重力の適用
        if (controller.isGrounded)
        {
            verticalVelocity.y = 0f; // 地面にいる場合、垂直速度をリセット
        }
        else
        {
            verticalVelocity.y += gravity * Time.deltaTime; // 空中では重力を適用
        }

        // 移動処理（重力含む）
        Vector3 move = moveDirection * moveSpeed * Time.deltaTime + verticalVelocity * Time.deltaTime;
        controller.Move(move);
    }

    // 物体に向かう際の移動
    public void MoveTowards(Vector3 direction)
    {
        // 高さはゼロに設定
        direction.y = 0;

        if (direction.magnitude >= 0.1f)
        {
            // 向きを調整
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // 移動処理（水平移動のみ）
            Vector3 move = direction * moveSpeed * Time.deltaTime;
            controller.Move(move);
        }
    }
}