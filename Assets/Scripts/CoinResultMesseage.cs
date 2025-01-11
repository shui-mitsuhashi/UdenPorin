using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinResultMesseage : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Start()
    {
        // PlayerPrefsからコインの枚数を取得
        float playerCoins = PlayerPrefs.GetFloat("PlayerHaveCoin", 0);

        // コイン数に応じてメッセージを変更
        if (playerCoins < 50)
        {
            coinText.text = "nice!";
        }
        else if (playerCoins >= 50 && playerCoins < 150)
        {
            coinText.text = "great!!";
        }
        else
        {
            coinText.text = "excellent!!!";
        }
    }
}
