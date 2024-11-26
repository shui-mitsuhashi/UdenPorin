using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndRelease : MonoBehaviour
{
    public Vector3 positionOffset; // 追従時の位置オフセット
    public Vector3 rotationOffset; // 追従時の回転オフセット

    private GameObject grabbedObject = null; // 現在触れているGrabbableオブジェクト
    private bool isFollowing = false;       // 追従状態フラグ

    void Update()
    {
        // RキーまたはBボタンが押されたとき
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("BButton"))
        {
            if (isFollowing)
            {
                // 追従を解除
                ReleaseObject();
            }
            else if (grabbedObject != null)
            {
                // 追従を開始
                StartFollowing(grabbedObject);
            }
        }

        // 追従中ならば、位置と回転を更新
        if (isFollowing && grabbedObject != null)
        {
            grabbedObject.transform.position = transform.position + transform.rotation * positionOffset;
            grabbedObject.transform.rotation = transform.rotation * Quaternion.Euler(rotationOffset);
        }
    }

    private void StartFollowing(GameObject obj)
    {
        // 追従開始
        isFollowing = true;
    }

    private void ReleaseObject()
    {
        // 追従解除
        isFollowing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Grabbableタグのオブジェクトに触れたとき
        if (other.CompareTag("Grabbable"))
        {
            grabbedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Grabbableタグのオブジェクトから離れたとき
        if (other.gameObject == grabbedObject)
        {
            grabbedObject = null;
        }
    }
}
