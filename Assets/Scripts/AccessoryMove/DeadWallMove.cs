using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadWallMove : MonoBehaviour
{
    public float speed = 5f; // ˆÚ“®‘¬“x
    public float unSearchSpeed = 2;
    public bool PlayerSearch = false;

    void Update()
    {
        if (PlayerSearch)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * unSearchSpeed * Time.deltaTime);
        }
        
    }
}
