using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beltconveyor : MonoBehaviour
{
    [SerializeField] private float conveyorSpeed = 1.0f; // コンベアの速度
    [SerializeField] public bool conveyorMove = true;   // コンベアが動くかどうか

    private void OnCollisionStay(Collision collision)
    {
        if (conveyorMove && collision.rigidbody != null)
        {
            // コンベアのローカル座標 -X 方向に移動力を加える
            Vector3 conveyorDirection = -transform.right * conveyorSpeed;

            // 接触オブジェクトの速度にコンベアの速度を加算
            collision.rigidbody.velocity += conveyorDirection;
        }
    }
}
