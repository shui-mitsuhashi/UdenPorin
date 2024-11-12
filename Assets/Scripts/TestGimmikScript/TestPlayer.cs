using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [Header("??????x")]
    public float speed = 10.0f;
    [Header("?W?????v??")]
    public float jumpPower = 15f;

    public Rigidbody rb;
    public Camera playerCamera;
    private IsGroundScript childScript;


    //?r?L????@?\??g???e??
    public GameObject bulletPrefab; // ?e???v???n?u
    public Transform bulletSpawnPoint; // ?????u
    public float bulletSpeed = 10f; // ?e?????x
    private bool isBulletActive = false;



    // Start is called before the first frame update
    void Start()
    {
        GameObject childObject = transform.Find("MonotaisGroundTrigger").gameObject;//?????????g???????q?I?u?W?F?N?g?èÔ
        childScript = childObject.GetComponent<IsGroundScript>();//?t?B?[???h????

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        bool isGround = childScript.isGround;



        //AD?L?[?èÔ

        float horizontal = Input.GetAxis("Horizontal");
        //float horizontal = Input.GetAxis("JoystickHorizontal1");

        // Get the direction the camera is facing
        Vector3 right = playerCamera.transform.right;

        right.y = 0f;

        right.Normalize();

        // Calculate the direction based on the input
        Vector3 direction = right * horizontal;

        // Move the player
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        //?v???C???[??????]??
        if (Input.GetKeyDown(KeyCode.A))
        {
            // A?L?[?????????????????????iY????180?x??]?j
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))

        {
            // D?L?[?????????????E???????iY????0?x??]?j
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
        bulletScript.Monota = this.gameObject; // Monota?I?u?W?F?N?g??n??

        // ?e???????????????????????????
        isBulletActive = true;

        // ?e?????????^?C?~???O??t???O?????Z?b?g????
        bullet.GetComponent<MonotaBullet>().OnBulletDestroyed += ResetShootFlag;
    }

    void ResetShootFlag()
    {
        isBulletActive = false; // ?e????????????????\?????
    }
}
