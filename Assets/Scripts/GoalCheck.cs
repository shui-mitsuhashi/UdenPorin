using UnityEngine;
using UnityEngine.UI;  // UI�R���|�[�l���g���g�p
using UnityEngine.SceneManagement;

public class GoalCheck : MonoBehaviour
{
    public GameObject player1;  // �v���C���[1
    public GameObject player2;  // �v���C���[2
    //public GameObject clearScreen;  // �N���A��ʁi�Ⴆ��Canvas��UI�p�l���j

    private bool player1Reached = false;  // �v���C���[1���S�[���ɓ��B������
    private bool player2Reached = false;  // �v���C���[2���S�[���ɓ��B������

    public string sceneName;//�ڍs�������V�[�������C���X�y�N�^�[�ɓ���

    void Start()
    {
        // �N���A��ʂ��\���ɂ���
        //clearScreen.SetActive(false);
    }

    void Update()
    {
        // �����̃v���C���[���S�[���ɓ��B������N���A��ʂ�\��
        if (player1Reached && player2Reached)
        {
            ShowClearScreen();
        }
    }

    // �S�[���ɐڐG�����Ƃ��ɌĂ΂�郁�\�b�h
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player1)
        {
            player1Reached = true;  // �v���C���[1���S�[���ɓ��B
        }
        else if (other.gameObject == player2)
        {
            player2Reached = true;  // �v���C���[2���S�[���ɓ��B
        }
    }

    // �N���A��ʂ�\�����郁�\�b�h
    void ShowClearScreen()
    {
        SceneManager.LoadScene(sceneName);
        //clearScreen.SetActive(true);
    }
}
