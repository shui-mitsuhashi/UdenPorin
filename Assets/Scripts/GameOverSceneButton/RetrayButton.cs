using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrayButton : MonoBehaviour
{
    // �J�ڐ�̃V�[�������w��
    public string sceneName;

    // �{�^���������ꂽ�Ƃ��ɌĂяo���֐�
    public void ChangeScene()
    {
        // �V�[�������[�h
        SceneManager.LoadScene(sceneName);
    }
}
