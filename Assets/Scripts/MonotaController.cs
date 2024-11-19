using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonotaController : MonoBehaviour
{
    [Header("移動速度")]
    public float speed = 10.0f;
    [Header("ジャンプ力")]
    public float jumpPower = 15f;

    public Rigidbody rb;
    public Camera playerCamera;
    private IsGroundScript childScript;


    //旧腕伸ばしに使う予定だった物
    public GameObject bulletPrefab; //弾丸のプレハブ
    public Transform bulletSpawnPoint; //弾丸発射地点
    public float bulletSpeed = 10f; // 弾丸の速度
    private bool isBulletActive = false;

    

    // Start is called before the first frame update
    void Start()
    {
        GameObject childObject = transform.Find("MonotaisGroundTrigger").gameObject;//子オブジェクトの接地判定取得
        childScript = childObject.GetComponent<IsGroundScript>();//接地トリガーの接地判定スクリプトを取得

        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isGround = childScript.isGround;

        

        //多分基本操作に関する部分

        //float horizontal = Input.GetAxis("Horizontal");
        float horizontal = Input.GetAxis("JoystickHorizontal1");

        // Get the direction the camera is facing
        Vector3 right = playerCamera.transform.right;

        right.y = 0f;

        right.Normalize();

        // Calculate the direction based on the input
        Vector3 direction = right * horizontal;

        // Move the player
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        //左右の方向転換処理
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Aで左に向く
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))

        {
            // Dで右に向く
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround == true)
            {
                rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (isGround == true)
            {
                rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            }
        }


        if (Input.GetKeyDown(KeyCode.S))
        {

        }

        if (Input.GetKeyDown(KeyCode.Q) && !isBulletActive)
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawnPoint.forward * bulletSpeed;

        MonotaBullet bulletScript = bullet.GetComponent<MonotaBullet>();
        bulletScript.Monota = this.gameObject;//

        // 弾丸が存在しているのか
        isBulletActive = true;

        //弾丸が消えたら再び発射可能になる
        bullet.GetComponent<MonotaBullet>().OnBulletDestroyed += ResetShootFlag;
    }

    void ResetShootFlag()
    {
        isBulletActive = false;//
    }
}
