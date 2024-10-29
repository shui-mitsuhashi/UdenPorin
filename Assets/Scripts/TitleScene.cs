using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleScene : MonoBehaviour
{
    public GameObject firstButton;
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleStage");
    }
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
