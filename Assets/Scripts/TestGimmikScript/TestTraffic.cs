using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTraffic : MonoBehaviour
{
    public Material RedTraffic;
    public Material BlueTraffic;

    public GameObject Player1;
    public GameObject Player2;

    public float switchInterval = 2.0f;
    private Renderer objRenderer;

    public bool IsRed = true;

    // トリガー内にいるプレイヤーを管理するリスト
    private HashSet<GameObject> playersInTrigger = new HashSet<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        StartCoroutine(SwitchColor());
    }

    IEnumerator SwitchColor()
    {
        while (true)
        {
            if (IsRed)
            {
                objRenderer.material = RedTraffic;
            }
            else
            {
                objRenderer.material = BlueTraffic;
            }

            // 色を反転
            IsRed = !IsRed;

            // トリガー内のプレイヤーの動きを更新
            UpdatePlayerMovement();

            // 指定した間隔だけ待つ
            yield return new WaitForSeconds(switchInterval);
        }
    }

    // トリガーに入ったときの処理
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player1 || other.gameObject == Player2)
        {
            playersInTrigger.Add(other.gameObject);
            UpdatePlayerMovement();
        }
    }

    // トリガーから出たときの処理
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player1 || other.gameObject == Player2)
        {
            playersInTrigger.Remove(other.gameObject);

            // トリガーから出たプレイヤーは常に動けるようにする
            EnablePlayerMovement(other.gameObject, true);
        }
    }

    // トリガー内のプレイヤーの動きを更新する
    private void UpdatePlayerMovement()
    {
        // トリガー内のPlayer1とPlayer2の動きを制御
        if (playersInTrigger.Contains(Player1))
        {
            EnablePlayerMovement(Player1, IsRed); // IsRedがtrueならPlayer1が動ける
        }
        else
        {
            EnablePlayerMovement(Player1, true); // トリガー外なら常に動ける
        }

        if (playersInTrigger.Contains(Player2))
        {
            EnablePlayerMovement(Player2, !IsRed); // IsRedがfalseならPlayer2が動ける
        }
        else
        {
            EnablePlayerMovement(Player2, true); // トリガー外なら常に動ける
        }
    }

    // プレイヤーのMovementScriptを有効または無効にし、位置を固定または解除する
    private void EnablePlayerMovement(GameObject player, bool enable)
    {
        var movementScript = player.GetComponent<SampleStagePlayer>(); // MovementScriptは各プレイヤーの移動を制御するスクリプト名
        var rigidbody = player.GetComponent<Rigidbody>();

        if (movementScript != null)
        {
            movementScript.enabled = enable;
        }

        if (rigidbody != null)
        {
            rigidbody.isKinematic = !enable; // 動けない間は物理挙動を停止
        }
    }
}