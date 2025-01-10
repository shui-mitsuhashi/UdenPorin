using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    public CoinManager coinManager; // CoinManagerを参照
    public string clearSceneName = "ClearScene"; // クリア画面のシーン名

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーがゴールに触れた場合
        if (other.CompareTag("Player")) // プレイヤーのタグが"Player"である場合
        {
            // CoinManagerから現在のコイン数を保存
            if (coinManager != null)
            {
                // floatをintに変換して保存
                GameManager.SetFinalCoinCount(Mathf.FloorToInt(coinManager.PlayerHaveCoin));
            }

            // クリア画面に遷移
            SceneManager.LoadScene(clearSceneName);
        }
    }
}
