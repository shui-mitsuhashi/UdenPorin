using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneScript : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public float respawnDelay = 1f; // リスポーンの遅延時間

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player1)
        {
            // Player1が触れた場合、Player2の近くでリスポーン
            StartCoroutine(RespawnPlayer(Player1, Player2.transform.position));
        }
        else if (other.gameObject == Player2)
        {
            // Player2が触れた場合、Player1の近くでリスポーン
            StartCoroutine(RespawnPlayer(Player2, Player1.transform.position));
        }
    }

    private IEnumerator RespawnPlayer(GameObject player, Vector3 targetPosition)
    {
        // リスポーンの遅延
        yield return new WaitForSeconds(respawnDelay);

        // リスポーン位置の設定
        Vector3 respawnPosition = new Vector3(targetPosition.x, targetPosition.y+2, targetPosition.z);
        player.transform.position = respawnPosition;
    }
}
