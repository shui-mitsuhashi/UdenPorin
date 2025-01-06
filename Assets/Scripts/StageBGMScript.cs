//�X�e�[�W�ŗ��ꑱ����BGM�̃X�N���v�gby�Ћ˕���
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
            // AudioSource���A�^�b�`����Ă��Ȃ��ꍇ�͎����Œǉ�
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
            audioSource.loop = true; // ���[�v�Đ���L���ɂ���
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("StageBGM is not assigned!");
        }
    }
}
