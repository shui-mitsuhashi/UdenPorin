using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StageSelectButton : MonoBehaviour
{
    public GameObject firstButton;
    public void Satge1Load()
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
