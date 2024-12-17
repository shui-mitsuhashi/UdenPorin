using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeedX = 0.5f; // X方向のスクロール速度
    public float scrollSpeedY = 0.0f; // Y方向のスクロール速度
    private Material backgroundMaterial;
    private Vector2 offset;

    void Start()
    {
        // 背景のマテリアルを取得
        backgroundMaterial = GetComponent<Renderer>().material;
        offset = backgroundMaterial.mainTextureOffset;
    }

    void Update()
    {
        // キャラクターの速度や時間に応じてオフセットを変更
        offset.x += scrollSpeedX * Time.deltaTime;
        offset.y += scrollSpeedY * Time.deltaTime;

        // オフセットをマテリアルに適用
        backgroundMaterial.mainTextureOffset = offset;
    }
}
