using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadWallMove : MonoBehaviour
{
    public float speed = 5f; // 移動速度
    public float unSearchSpeed = 2;
    public bool PlayerSearch = false;

    public AudioClip WallSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlayerSearch)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * unSearchSpeed * Time.deltaTime);
        }

        if (WallSound != null)
        {
            audioSource.clip = WallSound;
            audioSource.loop = true; // ループ再生を有効にする
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("WallSound is not assigned!");
        }

    }
}
