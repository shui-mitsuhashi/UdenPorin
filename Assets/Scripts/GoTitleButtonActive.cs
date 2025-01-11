using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTitleButtonActive : MonoBehaviour
{
    public float delay = 12f; // 移動を開始するまでの遅延時間（秒）
    public float moveDistance = 200f; // 上に移動する距離
    public float moveDuration = 1f; // 移動にかかる時間（秒）

    private RectTransform rectTransform;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float elapsedTime = 0f;
    private bool isMoving = false;

    void Start()
    {
        // RectTransformを取得
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("このスクリプトはUIオブジェクトにアタッチしてください！");
            enabled = false;
            return;
        }

        // 初期位置を保存
        startPosition = rectTransform.anchoredPosition;

        // ターゲット位置を計算
        targetPosition = startPosition + new Vector2(0, moveDistance);

        // 遅延後に移動を開始
        Invoke(nameof(StartMoving), delay);
    }

    void StartMoving()
    {
        isMoving = true;
    }

    void Update()
    {
        if (!isMoving) return;

        // 移動を線形補間で実現
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / moveDuration);
        rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);

        // 移動が完了したら停止
        if (t >= 1f)
        {
            isMoving = false;
        }
    }
}
