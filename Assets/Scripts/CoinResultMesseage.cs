using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinResultMesseage : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Start()
    {
        // PlayerPrefs����R�C���̖������擾
        float playerCoins = PlayerPrefs.GetFloat("PlayerHaveCoin", 0);

        // �R�C�����ɉ����ă��b�Z�[�W��ύX
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
