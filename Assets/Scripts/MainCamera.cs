using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransformをここにアタッチ

    // カメラとプレイヤーのオフセット
    private Vector3 offset = new Vector3(0, 0.15f, -0.8f);

    void LateUpdate()
    {
        // プレイヤーの座標にオフセットを加えてカメラを追従させる
        transform.position = player.position + offset;
    }
}
