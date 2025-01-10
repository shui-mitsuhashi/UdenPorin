using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearToTitle : MonoBehaviour
{
    void Update()
    {
        // コントローラーの❌ボタン（PSの場合は「Circle」）で遷移
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("TitleScene");  // タイトルシーンの名前を指定
        }
    }
}
