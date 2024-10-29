using UnityEngine;

public class BehindCameraFollow : MonoBehaviour
{
    public Transform character; // 追尾するキャラクター
    public Vector3 offset = new Vector3(0f, 2f, -5f); // 後ろ位置を調整するオフセット
    public float smoothSpeed = 0.125f; // カメラ移動のスムーズさを調整

    void LateUpdate()
    {
        Vector3 desiredPosition = character.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // キャラクターの後ろから見るためにキャラクターの方向を向く
        transform.LookAt(character.position + Vector3.up * 1.5f); // 高さを調整
    }
}