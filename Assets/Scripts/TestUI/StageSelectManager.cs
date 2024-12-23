using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    public void OnGoButtonClicked()
    {
        //ステージ（ゲーム画面に移動する）
        SceneManager.LoadScene("GameScene");
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void OnOptionButtoenClicked()
    {
        SceneManager.LoadScene("OptionScene");
    }
}
