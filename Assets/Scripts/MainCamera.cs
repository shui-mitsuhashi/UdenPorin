using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Vector3 focusPoint;

    // カメラとプレイヤーのオフセット
    private Vector3 offset = new Vector3(0, 0.15f, -2f);

    void LateUpdate()
    {
        focusPoint = (player1.position*4 + player2.position*3) / 7;

        transform.position = focusPoint + offset;
    }
}
