using UnityEngine;
using UnityEngine.UI;  // UIコンポーネントを使用
using UnityEngine.SceneManagement;

public class GoalCheck : MonoBehaviour
{
    public GameObject player1;  // プレイヤー1
    public GameObject player2;  // プレイヤー2
    //public GameObject clearScreen;  // クリア画面（例えばCanvasのUIパネル）

    private bool player1Reached = false;  // プレイヤー1がゴールに到達したか
    private bool player2Reached = false;  // プレイヤー2がゴールに到達したか

    public string sceneName;//移行したいシーン名をインスペクターに入力

    void Start()
    {
        // クリア画面を非表示にする
        //clearScreen.SetActive(false);
    }

    void Update()
    {
        // 両方のプレイヤーがゴールに到達したらクリア画面を表示
        if (player1Reached && player2Reached)
        {
            ShowClearScreen();
        }
    }

    // ゴールに接触したときに呼ばれるメソッド
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player1)
        {
            player1Reached = true;  // プレイヤー1がゴールに到達
        }
        else if (other.gameObject == player2)
        {
            player2Reached = true;  // プレイヤー2がゴールに到達
        }
    }

    // クリア画面を表示するメソッド
    void ShowClearScreen()
    {
        SceneManager.LoadScene(sceneName);
        //clearScreen.SetActive(true);
    }
}
