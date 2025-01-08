using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZoneScript : MonoBehaviour
{
    public bool Player1Dead = false;
    public bool Player2Dead = false;
    public GameObject Player1;
    public GameObject Player2;
    public float respawnDelay = 1f; // リスポーンの遅延時間
    public GameObject Player1Start;
    public GameObject Player2Start;

    public string GameOverSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player1)
        {
            Player1Dead = true;
            // Player1が触れた場合、Player2の近くでリスポーン
            StartCoroutine(RespawnPlayer(Player1, Player2.transform.position));
        }
        else if (other.gameObject == Player2)
        {
            Player2Dead = true;
            // Player2が触れた場合、Player1の近くでリスポーン
            StartCoroutine(RespawnPlayer(Player2, Player1.transform.position));
        }
    }

    private IEnumerator RespawnPlayer(GameObject player, Vector3 targetPosition)
    {
        if(Player1Dead==true&&Player2Dead==true)//2人共同時に死んだら
        {
            GameOver();//ゲームオーバー時の処理を実行
        }

        // リスポーンの遅延
        yield return new WaitForSeconds(respawnDelay);

        // リスポーン位置の設定
        Vector3 respawnPosition = new Vector3(targetPosition.x, targetPosition.y+1, targetPosition.z);
        player.transform.position = respawnPosition;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero; // 速度をリセット
            rb.angularVelocity = Vector3.zero; // 回転速度もリセット
        }

        Player1Dead = false;
        Player2Dead = false;
    }

    private void GameOver()//ゲームオーバー時の処理をここに書く
    {
        SceneManager.LoadScene(GameOverSceneName);
    }
}
