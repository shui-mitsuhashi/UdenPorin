using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadWallPlayerSearch : MonoBehaviour
{
    private DeadWallMove parentScript; // 親のスクリプトを参照
    private bool isTouchingPlayer = false; // Playerに触れているかどうかのフラグ

    void Start()
    {
        // 親オブジェクトの DeadWallMove スクリプトを取得
        parentScript = GetComponentInParent<DeadWallMove>();

        if (parentScript == null)
        {
            Debug.LogError("親オブジェクトに DeadWallMove スクリプトがアタッチされていません！");
        }
    }

    void Update()
    {
        if (parentScript != null)
        {
            // Playerに触れていない場合、PlayerSearchをfalseに設定
            if (!isTouchingPlayer)
            {
                parentScript.PlayerSearch = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Playerタグのオブジェクトに触れた場合
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = true;
            if (parentScript != null)
            {
                parentScript.PlayerSearch = true; // 親の PlayerSearch を true に設定
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Playerタグのオブジェクトから離れた場合
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }
}
