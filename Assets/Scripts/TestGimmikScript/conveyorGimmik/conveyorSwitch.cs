//このスクリプトはトリガーにアタッチする事

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyorSwitch : MonoBehaviour
{
    public GameObject BeltConveyor; // 制御するベルトコンベアオブジェクト
    private Beltconveyor beltConveyorScript; // ベルトコンベアのスクリプト

    private void Start()
    {
        // BeltConveyor から Beltconveyor スクリプトを取得
        if (BeltConveyor != null)
        {
            beltConveyorScript = BeltConveyor.GetComponent<Beltconveyor>();
        }
        else
        {
            Debug.LogError("BeltConveyor が割り当てられていません！");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーがスイッチに触れた場合
        if (other.CompareTag("Player") && beltConveyorScript != null)
        {
            beltConveyorScript.conveyorMove = false; // コンベアを停止
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // プレイヤーがスイッチから離れた場合
        if (other.CompareTag("Player") && beltConveyorScript != null)
        {
            beltConveyorScript.conveyorMove = true; // コンベアを再開
        }
    }


}
