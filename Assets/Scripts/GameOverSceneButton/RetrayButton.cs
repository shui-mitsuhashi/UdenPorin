using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrayButton : MonoBehaviour
{
    public AudioClip EnterSE;
    private AudioSource audioSource;

    // �J�ڐ�̃V�[�������w��
    public string sceneName;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // �{�^���������ꂽ�Ƃ��ɌĂяo���֐�
    public void ChangeScene()
    {
        audioSource.PlayOneShot(EnterSE);
        // �V�[�������[�h
        SceneManager.LoadScene(sceneName);
    }
}
