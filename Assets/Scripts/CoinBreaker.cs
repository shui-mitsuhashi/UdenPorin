using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBreaker : MonoBehaviour
{
    [Header("小コインは１、大コインは５みたいにコインごとに個別に設定できる")]
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
            Debug.Log("Playerが接触");
            managerScript.PlayerHaveCoin += AddCoinCount;
            Destroy(gameObject);
        }
    }
}
