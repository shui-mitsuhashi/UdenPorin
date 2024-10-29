using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public GameObject Player1;  // オブジェクト1
    public GameObject Player2;  // オブジェクト2
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1 != null && Player2 != null)
        {
            // オブジェクト1とオブジェクト2の位置を取得
            Vector3 position1 = Player1.transform.position;
            Vector3 position2 = Player2.transform.position;

            // 中間地点を計算
            Vector3 midpoint = (position1 + position2) / 2;

            // このスクリプトがアタッチされたGamePlayerを中間地点に移動
            transform.position = midpoint;
        }
    }
}
