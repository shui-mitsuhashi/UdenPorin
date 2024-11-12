using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndPull : MonoBehaviour
{
    public Transform leftArm;  // 左腕のTransform
    public Transform rightArm; // 右腕のTransform
    public float pullSpeed = 2.0f; // キャラクターが引き寄せられる速度
    public float minDistance = 1.0f; // キャラクターと物体の最小距離
    private Transform targetObject; // 掴んでいる物体のTransform
    private bool isGrabbing = false; // 掴んでいるかどうかのフラグ

    void Update()
    {
        // Rキーを押して物体を掴む
        if (Input.GetKeyDown(KeyCode.R))
        {
            // 掴む物体を探す (コライダーを利用)
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance: 5.0f))
            {
                // 掴める物体にヒットした場合
                if (hit.collider.CompareTag("Grabbable"))
                {
                    targetObject = hit.collider.transform;
                    isGrabbing = true;
                }
            }
        }

        // 掴んだ後、キャラクターを物体に引き寄せる処理
        if (isGrabbing && targetObject != null)
        {
            float distance = Vector3.Distance(transform.position, targetObject.position);

            // 最小距離に達するまでキャラクターを引き寄せる
            if (distance > minDistance)
            {
                Vector3 pullDirection = (targetObject.position - transform.position).normalized;
                transform.position += pullDirection * pullSpeed * Time.deltaTime;
            }
            else
            {
                // 最小距離に達したら掴みを解除
                isGrabbing = false;
            }
        }
    }
}
