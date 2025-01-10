using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 静的変数でコイン数を保存する
    public static int finalCoinCount = 0;

    void Awake()
    {
        // シーン間でGameManagerが破棄されないようにする
        DontDestroyOnLoad(gameObject);
    }

    // コイン数を保存する関数
    public static void SetFinalCoinCount(int coinCount)
    {
        finalCoinCount = coinCount;
    }
}
