using UnityEngine;

//腕を上げるスクリプト
public class ArmController : MonoBehaviour
{
    public Transform leftArm;
    public Transform rightArm;

    public float raiseSpeed = 30f; // 腕を上げる速度
    private Quaternion targetRotationLeft;
    private Quaternion targetRotationRight;
    private bool raisingArms = false;

    void Start()
    {
        // 最初の目標は腕を下ろしている位置（腕が前に下りている状態）
        targetRotationLeft = Quaternion.Euler(100, 0, 0); // 左腕を前に下ろす角度
        targetRotationRight = Quaternion.Euler(100, 0, 0); // 右腕を前に下ろす角度
    }

    void Update()
    {
        // シフトキーが押されている間だけ raisingArms を true にする
        if (Input.GetKey(KeyCode.LeftShift))
        {
            raisingArms = true;
        }
        else
        {
            raisingArms = false;
        }

        // raisingArms が true の場合、腕を上げる。そうでなければ腕を下げる
        if (raisingArms)
        {
            // 腕を上げる目標角度
            targetRotationLeft = Quaternion.Euler(-120, 80, 0); // 左腕がまっすぐ上に上がる位置
            targetRotationRight = Quaternion.Euler(-120,80, 0); // 右腕がまっすぐ上に上がる位置
        }
        else
        {
            // 腕を下げる目標角度（前に腕を下ろす位置）
            targetRotationLeft = Quaternion.Euler(0, 0, 100); // 左腕が前に下がる位置
            targetRotationRight = Quaternion.Euler(0, 0, 100); // 右腕が前に下がる位置
        }

        // 腕を徐々に目標角度に近づける
        leftArm.localRotation = Quaternion.RotateTowards(leftArm.localRotation, targetRotationLeft, raiseSpeed * Time.deltaTime);
        rightArm.localRotation = Quaternion.RotateTowards(rightArm.localRotation, targetRotationRight, raiseSpeed * Time.deltaTime);
    }
}
