using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("Player���������Ă���R�C���̖���")]
    public float PlayerHaveCoin;

    [Header("�R�C�����擾�����Ƃ��̌��ʉ�")]
    public AudioClip coinSound;

    private float previousCoinCount;
    private AudioSource audioSource;

    void Start()
    {
        // �V�[���J�n������0�ɏ�����
        PlayerHaveCoin = 0;
        previousCoinCount = PlayerHaveCoin;

        // AudioSource�R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSource���A�^�b�`����Ă��Ȃ��ꍇ�͎����Œǉ�
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // �R�C���̖������������ꍇ�Ɍ��ʉ����Đ�
        if (PlayerHaveCoin > previousCoinCount)
        {
            PlayCoinSound();
            previousCoinCount = PlayerHaveCoin;
        }
    }

    void PlayCoinSound()
    {
        if (coinSound != null)
        {
            audioSource.PlayOneShot(coinSound);
        }
        else
        {
            Debug.LogWarning("Coin sound is not assigned!");
        }
    }

    void CoinDrop()
    {
        if(PlayerHaveCoin<10)
        {
            PlayerHaveCoin = 0;
        }
        else
        {
            PlayerHaveCoin = PlayerHaveCoin - 10;
        }

        previousCoinCount = PlayerHaveCoin;
    }
}
