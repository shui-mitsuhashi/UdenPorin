using UnityEngine;
using UnityEngine.Video;

public class ClearSceneManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Video Playerの参照
    public GameObject clearText;    // Clearの文字
    public GameObject coinCountText; // コインカウントの表示

    void Start()
    {
        clearText.SetActive(false); // 初期状態で非表示
        coinCountText.SetActive(false);
        videoPlayer.loopPointReached += OnVideoEnded; // ムービー終了時のイベント登録
    }

    void OnVideoEnded(VideoPlayer vp)
    {
        clearText.SetActive(true);      // Clearの文字を表示
        coinCountText.SetActive(true); // コイン数を表示
    }
}
