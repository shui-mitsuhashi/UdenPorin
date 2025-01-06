//ステージで流れ続けるBGMのスクリプトby片桐歩夢
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBGMScript : MonoBehaviour
{
    public AudioClip StageBGM;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSourceがアタッチされていない場合は自動で追加
            //audioSource = gameObject.AddComponent<AudioSource>();

            PlayBGM();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayBGM()
    {
        if (StageBGM != null)
        {
            audioSource.clip = StageBGM;
            audioSource.loop = true; // ループ再生を有効にする
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("StageBGM is not assigned!");
        }
    }
}
