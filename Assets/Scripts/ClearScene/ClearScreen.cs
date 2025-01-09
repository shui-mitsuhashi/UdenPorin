using UnityEngine;
using UnityEngine.UI;

public class ClearScreen : MonoBehaviour
{
    public Text clearText;  // クリア用のテキスト（インスペクターで設定）
    public int coinCount;  // コインの数

    void Start()
    {
        // クリアテキストを更新
        clearText.text = "ゲームクリア!\nコイン: " + coinCount.ToString();
    }
}
