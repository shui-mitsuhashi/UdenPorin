using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ArmStretc : MonoBehaviour
{
    public GameObject targetObject;  // 対象のオブジェクト
    public float scaleSpeed = 8f;    // スケールの変化速度
    private Vector3 originalScale;   // 元のスケール
    private bool isScaling = false;  // スケールを大きくするフラグ

    void Start()
    {
        if (targetObject != null)
        {
            // 対象オブジェクトの元のスケールを記録
            originalScale = targetObject.transform.localScale;
        }
    }

    void Update()
    {
        if (targetObject == null) return;

        // 入力チェック（キーボードEキー or Xboxコントローラー右トリガー）
        if (Input.GetKey(KeyCode.E) || Input.GetAxis("MonotaRTrigger") > 0.1f)
        {
            isScaling = true;  // スケールを大きくする
        }
        else
        {
            isScaling = false; // スケールを元に戻す
        }

        // スケールの更新
        UpdateScale();
    }

    void UpdateScale()
    {
        Vector3 currentScale = targetObject.transform.localScale;

        if (isScaling)
        {
            // Xスケールを徐々に2倍まで拡大
            float targetXScale = originalScale.x * 3;
            currentScale.x = Mathf.MoveTowards(currentScale.x, targetXScale, scaleSpeed * Time.deltaTime);
        }
        else
        {
            // Xスケールを徐々に元のサイズへ戻す
            currentScale.x = Mathf.MoveTowards(currentScale.x, originalScale.x, scaleSpeed * Time.deltaTime);
        }

        // スケールを更新
        targetObject.transform.localScale = currentScale;
    }
}
