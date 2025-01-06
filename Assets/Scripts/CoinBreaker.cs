using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBreaker : MonoBehaviour
{
    [Header("小コインは１、大コインは５みたいにコインごとに個別に設定できる")]
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
