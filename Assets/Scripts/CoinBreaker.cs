using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBreaker : MonoBehaviour
{
    [Header("���R�C���͂P�A��R�C���͂T�݂����ɃR�C�����ƂɌʂɐݒ�ł���")]
    public float AddCoinCount = 1;

    CoinManager managerScript;


    // Start is called before the first frame update
    void Start()
    {
        managerScript = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player���ڐG");
            managerScript.PlayerHaveCoin += AddCoinCount;
            Destroy(gameObject);
        }
    }
}
