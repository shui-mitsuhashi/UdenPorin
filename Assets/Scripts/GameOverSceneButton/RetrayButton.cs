using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrayButton : MonoBehaviour
{
    public AudioClip EnterSE;
    private AudioSource audioSource;

    // 遷移先のシーン名を指定
    public string sceneName;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // ボタンが押されたときに呼び出す関数
    public void ChangeScene()
    {
        audioSource.PlayOneShot(EnterSE);
        // シーンをロード
        SceneManager.LoadScene(sceneName);
    }
}
