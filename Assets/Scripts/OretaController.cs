using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OretaController : MonoBehaviour
{
    [Header("移動速度")]
    public float speed = 1.2f;
    [Header("ジャンプ力")]
    public float jumpPower = 4.5f;

    public Rigidbody rb;
    public Camera playerCamera;
    private IsGroundScript childScript;

    public AudioClip EnterSE;
    private AudioSource audioSource;


    //腕伸ばし機能に使う弾丸
    public GameObject bulletPrefab; // 弾丸のプレハブ
    public Transform bulletSpawnPoint; // 発射位置
    public float bulletSpeed = 10f; // 弾丸の速度
    private bool isBulletActive = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject childObject = transform.Find("OretaisGroundTrigger").gameObject;//当たり判定に使っている子オブジェクト取得
        childScript = childObject.GetComponent<IsGroundScript>();//フィールドに代入

        rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGround = childScript.isGround;

        //ADキー取得
        //float horizontal1 = Input.GetAxis("Horizontal1");
        float horizontal = Input.GetAxis("JoystickHorizontal2");

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
        //プレイヤーの方向転換
        /*if (Input.GetKeyDown(KeyCode.O))
        {
            // Oキーを押したときに左を向く（Y軸で180度回転）
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            // Pキーを押したときに右を向く（Y軸で0度回転）
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }*/

        // 入力が一定のしきい値を超えた場合に方向を変える
        if (horizontal < -0.5f)
        {
            // 左スティックを左に倒したときに左を向く（Y軸で180度回転）
            transform.rotation = Quaternion.Euler(0, 235, 0);
        }
        else if (horizontal > 0.5f)
        {
            // 左スティックを右に倒したときに右を向く（Y軸で0度回転）
            transform.rotation = Quaternion.Euler(0, 55, 0);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround == true)
            {
                BlueJump();
            }
        }

        if (Input.GetButtonDown("BlueJump"))
        {
            if (isGround == true)
            {
                BlueJump();
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

        }

        /*if (Input.GetKeyDown(KeyCode.E) && !isBulletActive)
        {
            ShootBullet();
        }*/
    }

    void BlueJump()
    {
        audioSource.PlayOneShot(EnterSE);
        rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
    }


    /*void ShootBullet()//多分もう使わない（12/3時点)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawnPoint.forward * bulletSpeed;

        // 弾丸が存在する間は発射できないようにする
        isBulletActive = true;

        // 弾丸が消えるタイミングでフラグをリセットする
        bullet.GetComponent<MonotaBullet>().OnBulletDestroyed += ResetShootFlag;
    }

    void ResetShootFlag()
    {
        isBulletActive = false; // 弾丸が消えたら再発射可能にする
    }*/
}
