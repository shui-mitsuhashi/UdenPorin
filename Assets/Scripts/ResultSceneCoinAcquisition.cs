using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultSceneCoinAcquisition : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Start()
    {
        // PlayerPrefsからコインの枚数を取得
        float playerCoins = PlayerPrefs.GetFloat("PlayerHaveCoin", 0);

        // コインの枚数をUIに表示
        coinText.text = "Coins: " + playerCoins.ToString();
    }
}
