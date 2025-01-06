using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrayButton : MonoBehaviour
{
    // 遷移先のシーン名を指定
    public string sceneName;

    // ボタンが押されたときに呼び出す関数
    public void ChangeScene()
    {
        // シーンをロード
        SceneManager.LoadScene(sceneName);
    }
}
