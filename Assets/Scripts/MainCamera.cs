using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Vector3 focusPoint;

    // カメラとプレイヤーのオフセット
    private Vector3 offset = new Vector3(0, 1.2f, -3f);

    void LateUpdate()
    {
        //focusPoint = (player1.position*4 + player2.position*3) / 7;
        float focusX = (player1.position.x * 4 + player2.position.x * 3) / 7;

        //focusPoint.y = Mathf.Clamp(focusPoint.y, 0f, 1f);
        focusPoint = new Vector3(focusX, 0f, 0f);

        transform.position = focusPoint + offset;
    }
}
