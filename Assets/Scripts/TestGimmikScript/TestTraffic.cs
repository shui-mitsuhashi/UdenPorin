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

            // 指定した間隔だけ待つ
            yield return new WaitForSeconds(switchInterval);
        }
    }

    // トリガーに入ったときの処理
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player1 || other.gameObject == Player2)
        {
            UpdatePlayerMovement();
        }
    }

    // トリガーから出たときの処理
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player1 || other.gameObject == Player2)
        {
            // プレイヤーがトリガーから出たら動けるようにする
            EnablePlayerMovement(Player1, true);
            EnablePlayerMovement(Player2, true);
        }
    }

    // プレイヤーの動きを更新する
    private void UpdatePlayerMovement()
    {
        if (IsRed)
        {
            EnablePlayerMovement(Player1, true);  // Player1は動ける
            EnablePlayerMovement(Player2, false); // Player2は動けない
        }
        else
        {
            EnablePlayerMovement(Player1, false); // Player1は動けない
            EnablePlayerMovement(Player2, true);  // Player2は動ける
        }
    }

    // プレイヤーのMovementScriptを有効または無効にする
    private void EnablePlayerMovement(GameObject player, bool enable)
    {
        var movementScript = player.GetComponent<SampleStagePlayer>(); // MovementScriptは各プレイヤーの移動を制御するスクリプト名
        if (movementScript != null)
        {
            movementScript.enabled = enable;
        }
    }

}
