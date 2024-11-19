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


    //腕伸ばしに使う弾丸
    public GameObject bulletPrefab; // 弾丸のプレハブ
    public Transform bulletSpawnPoint; //発射地点
    public float bulletSpeed = 10f; //弾速
    private bool isBulletActive = false;

    

    // Start is called before the first frame update
    void Start()
    {
        GameObject childObject = transform.Find("MonotaisGroundTrigger").gameObject;//接地判定のトリガー
        childScript = childObject.GetComponent<IsGroundScript>();//トリガーに付いている判定用スクリプト取得

        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isGround = childScript.isGround;

        

        //ADキー取得
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

        //方向転換
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Aで左に向く
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))

        {
            // Dで右を向く
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
        bulletScript.Monota = this.gameObject;

        // 弾丸が存在する間は発射できないようにする
        isBulletActive = true;

        // 弾丸が消えるタイミングでフラグをリセットする
        bullet.GetComponent<MonotaBullet>().OnBulletDestroyed += ResetShootFlag;
    }

    void ResetShootFlag()
    {
        isBulletActive = false; // 弾丸が消えたら再発射可能にする
    }
}
