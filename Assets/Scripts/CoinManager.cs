using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("Playerが所持しているコインの枚数")]
    public float PlayerHaveCoin;

    [Header("コインを取得したときの効果音")]
    public AudioClip coinSound;

    private float previousCoinCount;
    private AudioSource audioSource;

    void Start()
    {
        // シーンが読み込まれるたびにコインの数を0に初期化
        PlayerPrefs.SetFloat("PlayerHaveCoin", 0);

        // 初期化されたコイン数を取得
        PlayerHaveCoin = PlayerPrefs.GetFloat("PlayerHaveCoin", 0);
        previousCoinCount = PlayerHaveCoin;

        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSourceがアタッチされていない場合は自動で追加
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // コインの枚数が増えた場合に効果音を再生
        if (PlayerHaveCoin > previousCoinCount)
        {
            PlayCoinSound();
            previousCoinCount = PlayerHaveCoin;

            // コインを取得した際にPlayerPrefsに保存
            PlayerPrefs.SetFloat("PlayerHaveCoin", PlayerHaveCoin);
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
        if (PlayerHaveCoin < 10)
        {
            PlayerHaveCoin = 0;
        }
        else
        {
            PlayerHaveCoin = PlayerHaveCoin - 10;
        }

        previousCoinCount = PlayerHaveCoin;

        // コインの数をPlayerPrefsに保存
        PlayerPrefs.SetFloat("PlayerHaveCoin", PlayerHaveCoin);
    }
}