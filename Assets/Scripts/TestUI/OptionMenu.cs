using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionMenu : MonoBehaviour
{
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}