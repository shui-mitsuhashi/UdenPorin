using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ArmStretc : MonoBehaviour
{
    public GameObject targetObject;  // 対象のオブジェクト
    public GameObject trampoline;
    private Collider trampolineCollider; // トランポリンのコライダー
    public float scaleSpeed = 2f;    // スケールの変化速度
    private Vector3 originalScale;   // 元のスケール
    private bool isScaling = false;  // スケールを大きくするフラグ

    void Start()
    {
        if (targetObject != null)
        {
            // 対象オブジェクトの元のスケールを記録
            originalScale = targetObject.transform.localScale;
        }

        if (trampoline != null)
        {
            // トランポリンのコライダーを取得
            trampolineCollider = trampoline.GetComponent<Collider>();

            // トランポリンのコライダーを初期状態で無効化
            if (trampolineCollider != null)
            {
                trampolineCollider.enabled = false;
            }
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

        // トランポリンのコライダーの有効化/無効化
        UpdateTrampolineCollider();
    }

    void UpdateScale()
    {
        Vector3 currentScale = targetObject.transform.localScale;

        if (isScaling)
        {
            // Xスケールを徐々に2倍まで拡大
            float targetXScale = originalScale.x * 7;
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

    void UpdateTrampolineCollider()
    {
        if (trampolineCollider == null) return;

        // targetObjectがoriginalScale以上のときにコライダーを有効化
        if (targetObject.transform.localScale.x > originalScale.x)
        {
            trampolineCollider.enabled = true;
        }
        else
        {
            trampolineCollider.enabled = false;
        }
    }
}
