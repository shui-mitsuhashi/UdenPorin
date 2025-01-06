using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCountUI : MonoBehaviour
{
    [Header("CoinManagerスクリプトがアタッチされたオブジェクト")]
    public CoinManager coinManager;

    [Header("表示させるTextMeshProオブジェクト")]
    public TextMeshProUGUI coinText;

    void Start()
    {
        // 必要に応じて CoinManager を自動取得
        if (coinManager == null)
        {
            coinManager = GameObject.FindObjectOfType<CoinManager>();
        }

        // 必要に応じて TextMeshPro オブジェクトを自動取得
        if (coinText == null)
        {
            coinText = GameObject.FindObjectOfType<TextMeshProUGUI>();
        }

        // 初期値を更新
        UpdateCoinDisplay();
    }

    void Update()
    {
        // 常に CoinManager のコイン数を反映
        UpdateCoinDisplay();
    }

    void UpdateCoinDisplay()
    {
        if (coinManager != null && coinText != null)
        {
            // コインの枚数を UI に表示
            coinText.text = "GetCoin:" + coinManager.PlayerHaveCoin.ToString("0");
        }
    }
}
