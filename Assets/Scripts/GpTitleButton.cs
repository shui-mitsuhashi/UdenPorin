using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GpTitleButton : MonoBehaviour
{
    public string sceneName; // �J�ڐ�̃V�[����
    
    // �{�^���������ꂽ�Ƃ��ɌĂяo���֐�
    public void ChangeScene()
    {
        // �V�[�������[�h
        SceneManager.LoadScene(sceneName);
    }
}
