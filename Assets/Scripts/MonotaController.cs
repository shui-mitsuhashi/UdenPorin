using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonotaController : MonoBehaviour
{
    [Header("移動速度")]
    public float speed = 1.2f;
    [Header("ジャンプ力")]
    public float jumpPower = 4.5f;

    public Rigidbody rb;
    public Camera playerCamera;
    private IsGroundScript childScript;

    public AudioClip JanpSE;
    private AudioSource audioSource;


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

        audioSource = GetComponent<AudioSource>();

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
        if (isGround == true)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
        else if (isGround == false)
        {
            transform.Translate(direction * speed * 0.7f * Time.deltaTime, Space.World);
        }

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

        // 入力が一定のしきい値を超えた場合に方向を変える
        if (horizontal < -0.5f)
        {
            // 左スティックを左に倒したときに左を向く（Y軸で180度回転）
            transform.rotation = Quaternion.Euler(0, 280, 0);
        }
        else if (horizontal > 0.5f)
        {
            // 左スティックを右に倒したときに右を向く（Y軸で0度回転）
            transform.rotation = Quaternion.Euler(0, 100, 0);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround == true)
            {
                RedJump();
            }
        }

        if (Input.GetButtonDown("RedJump"))
        {
            if (isGround == true)
            {
                RedJump();
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

    void RedJump()
    {
        audioSource.PlayOneShot(JanpSE);
        rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
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
