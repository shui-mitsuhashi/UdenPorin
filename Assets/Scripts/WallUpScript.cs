using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUpScript : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public GameObject UpWall;
    public bool IsRaise = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsRaise)
        {
            UpWall.transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarryBox"))
        {
            Debug.Log("CarryBoxÇ™ÉgÉäÉKÅ[Ç…êGÇÍÇ‹ÇµÇΩÅI");

            OnTrigger();
        }
    }

    private void OnTrigger()
    {
        IsRaise = true;
    }
}
