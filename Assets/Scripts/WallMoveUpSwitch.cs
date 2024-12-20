//箱を置いたら壁が上がるスクリプト
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveUpSwitch : MonoBehaviour
{
    public bool switchPushing = false; // スイッチが押されているか
    public GameObject UpGround;
    private Vector3 initialPosition; // 初期位置
    [Header("下がる下限位置を入れる")]
    public float lowerLimit = -10f; // 下限のY位置
    [Header("ある程度は早くした方が良い")]
    public float speed = -5f; // 上下する速度

    // Start is called before the first frame update
    void Start()
    {
        // 初期位置を保存
        initialPosition = UpGround.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchPushing)
        {
            // 下に下がり、下限まで達したら止まる
            if (UpGround.transform.position.y > initialPosition.y + lowerLimit)
            {
                UpGround.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            }
        }
        else
        {
            // 初期位置まで戻る
            if (UpGround.transform.position.y < initialPosition.y)
            {
                UpGround.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarryBox")
        {
            switchPushing = true;
        }
    }

    
}
