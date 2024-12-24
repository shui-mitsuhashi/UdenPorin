using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("Playerが所持しているコインの枚数")]
    public float PlayerHaveCoin;

    void Start()
    {
        //シーン開始時毎回0に初期化
        PlayerHaveCoin = 0;
    }

    void Update()
    {
        
    }
}
