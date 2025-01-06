using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBreaker : MonoBehaviour
{
    [Header("���R�C���͂P�A��R�C���͂T�݂����ɃR�C�����ƂɌʂɐݒ�ł���")]
    public float AddCoinCount = 1;

    CoinManager managerScript;

    //private AudioSource audioSource;
    //public AudioClip maou_se_system46;

    void Start()
    {
        
        managerScript = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GetComponent<AudioSource>().Play();
            managerScript.PlayerHaveCoin += AddCoinCount;
            Destroy(gameObject);
        }
    }
}
