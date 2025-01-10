using UnityEngine;
using TMPro; // TextMeshPro用の名前空間

public class TextFadeIn : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // フェードインさせるTextMeshProオブジェクト
    public float delay = 2f;           // 映像再生後の遅延時間（秒）
    public float fadeDuration = 2f;   // フェードインにかかる時間（秒）

    private float elapsedTime = 0f;   // 経過時間
    private bool startFade = false;   // フェード開始フラグ

    void Start()
    {
        // 最初に文字を完全に透明にする
        Color color = textMeshPro.color;
        color.a = 0f;
        textMeshPro.color = color;

        // 遅延後にフェードを開始するようにコルーチンを実行
        Invoke(nameof(StartFade), delay);
    }

    void Update()
    {
        if (startFade)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime <= fadeDuration)
            {
                // アルファ値を徐々に増加させる
                float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
                Color color = textMeshPro.color;
                color.a = alpha;
                textMeshPro.color = color;
            }
        }
    }

    void StartFade()
    {
        startFade = true; // フェードを開始
    }
}
