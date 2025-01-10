using UnityEngine;
using TMPro;

public class ClearScreenDisplay : MonoBehaviour
{
    public TextMeshProUGUI coinText; // TextMeshProオブジェクトを割り当てる

    void Start()
    {
        // GameManagerからコイン数を取得して表示
        if (coinText != null)
        {
            coinText.text = "獲得コイン: " + GameManager.finalCoinCount.ToString("0");
        }
    }
}
