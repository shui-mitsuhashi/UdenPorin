//壁を上昇させるスイッチのスクリプトby片桐歩夢

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRisingSwitch : MonoBehaviour
{
    public bool switchPushing = false; // スイッチが押されているか
    public GameObject SwitchTrriger;
    public GameObject RisingGround;
    private Vector3 initialPosition; // 初期位置
    private float lowerLimit = -10f; // 下限のY位置
    private float speed = 5f; // 上下する速度

    // Start is called before the first frame update
    void Start()
    {
        // 初期位置を保存
        initialPosition = RisingGround.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchPushing)
        {
            // 下に下がり、下限まで達したら止まる
            if (RisingGround.transform.position.y > initialPosition.y + lowerLimit)
            {
                RisingGround.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            }
        }
        else
        {
            // 初期位置まで戻る
            if (RisingGround.transform.position.y < initialPosition.y)
            {
                RisingGround.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "MonotaCarryBox")
        {
            switchPushing = true;
        }
    }

    // トリガーから出た時
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "MonotaCarryBox")
        {
            switchPushing = false;
        }
    }

}
