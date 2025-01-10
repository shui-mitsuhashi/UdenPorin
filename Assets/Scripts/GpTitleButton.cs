using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GpTitleButton : MonoBehaviour
{
    public string sceneName; // 遷移先のシーン名
    
    // ボタンが押されたときに呼び出す関数
    public void ChangeScene()
    {
        // シーンをロード
        SceneManager.LoadScene(sceneName);
    }
}
