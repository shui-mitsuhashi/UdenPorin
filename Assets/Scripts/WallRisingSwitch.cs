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
    [Header("下がる下限位置を入れる")]
    public float lowerLimit = -10f; // 下限のY位置
    [Header("ある程度は早くした方が良い")]
    public float speed = -5f; // 上下する速度

    public AudioClip SwitchSE;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // 初期位置を保存
        initialPosition = RisingGround.transform.position;

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (switchPushing)
        {
            audioSource.PlayOneShot(SwitchSE);
            DownGround();
        }
        else
        {
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            switchPushing = true;
        }
    }

    // トリガーから出た時
    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switchPushing = false;
        }
    }*/

    void DownGround()
    {
        if (RisingGround.transform.position.y > initialPosition.y + lowerLimit)
        {
            RisingGround.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
    }

}
