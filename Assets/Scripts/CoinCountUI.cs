using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCountUI : MonoBehaviour
{
    [Header("CoinManager�X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g")]
    public CoinManager coinManager;

    [Header("�\��������TextMeshPro�I�u�W�F�N�g")]
    public TextMeshProUGUI coinText;

    void Start()
    {
        // �K�v�ɉ����� CoinManager �������擾
        if (coinManager == null)
        {
            coinManager = GameObject.FindObjectOfType<CoinManager>();
        }

        // �K�v�ɉ����� TextMeshPro �I�u�W�F�N�g�������擾
        if (coinText == null)
        {
            coinText = GameObject.FindObjectOfType<TextMeshProUGUI>();
        }

        // �����l���X�V
        UpdateCoinDisplay();
    }

    void Update()
    {
        // ��� CoinManager �̃R�C�����𔽉f
        UpdateCoinDisplay();
    }

    void UpdateCoinDisplay()
    {
        if (coinManager != null && coinText != null)
        {
            // �R�C���̖����� UI �ɕ\��
            coinText.text = "GetCoin:" + coinManager.PlayerHaveCoin.ToString("0");
        }
    }
}
