using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneTransition : MonoBehaviour
{
    public VideoPlayer videoPlayer; // 映像再生用のVideoPlayerをInspectorで設定

    void Start()
    {
        // 映像再生終了時のイベントを登録
        if (videoPlayer != null)
        {
            videoPlayer.Play(); // 映像の自動再生を有効化
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    void Update()
    {
        // PSコントローラーの✖️ボタン (joystick button 0) またはキーボードのエンターキー
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("進むボタンが押されました！");
            SceneManager.LoadScene("TitleScene"); // タイトルシーンへ遷移
        }
    }

    // 映像再生が終了した場合に呼ばれるメソッド
    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("映像が終了しました。タイトルシーンに遷移します。");
        SceneManager.LoadScene("TitleScene");
    }
}
