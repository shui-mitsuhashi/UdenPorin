using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//腕が伸びるスクリプト
public class ArmStretch : MonoBehaviour
{
    public Transform leftArm;  // 左腕のTransform
    //public Transform rightArm; // 右腕のTransform
    public float stretchSpeed = 1.0f; // 腕が伸びる速度
    public float maxStretch = 2.0f; // 腕の最大の長さ
    public float originalScaleX = 1.0f; // 腕の元の長さ（X軸方向）

    void Update()
    {
        // 両腕が押されている間に伸び、離すと戻る (Eキーで制御)
        if (Input.GetKey(KeyCode.E))
        {
            // 左腕が最大の長さに達するまで伸ばす
            if (leftArm.localScale.x < maxStretch)
            {
                leftArm.localScale += new Vector3(stretchSpeed * Time.deltaTime, 0, 0);
            }

            // 右腕が最大の長さに達するまで伸ばす
            /*if (rightArm.localScale.x < maxStretch)
            {
                rightArm.localScale += new Vector3(stretchSpeed * Time.deltaTime, 0, 0);
            }*/
        }
        else if (Input.GetKeyUp(KeyCode.E)) // Eキーを離したら元に戻る
        {
            // 左腕の長さを元に戻す
            leftArm.localScale = new Vector3(originalScaleX, leftArm.localScale.y, leftArm.localScale.z);

            // 右腕の長さを元に戻す
            //rightArm.localScale = new Vector3(originalScaleX, rightArm.localScale.y, rightArm.localScale.z);
        }
    }
}
