using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultSceneCoinAcquisition : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Start()
    {
        // PlayerPrefs����R�C���̖������擾
        float playerCoins = PlayerPrefs.GetFloat("PlayerHaveCoin", 0);

        // �R�C���̖�����UI�ɕ\��
        coinText.text = "Coins: " + playerCoins.ToString();
    }
}
