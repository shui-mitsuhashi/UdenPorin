using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Update()
    {
        // PSコントローラーの✖️ボタン（Crossボタン）またはエンターキーが押されたらシーンを切り替える
        if (Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.Return))
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("TestClearScene");
    }
}
