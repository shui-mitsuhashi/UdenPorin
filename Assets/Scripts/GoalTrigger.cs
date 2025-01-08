using UnityEngine;
using UnityEngine.SceneManagement; // シーン遷移に必要

public class GoalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーが触れた場合
        if (other.CompareTag("Player"))
        {
            // クリア画面のシーンに遷移
            SceneManager.LoadScene("ClearScene");
        }
    }
}
