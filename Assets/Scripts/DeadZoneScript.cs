using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZoneScript : MonoBehaviour
{
    public bool Player1Dead = false;
    public bool Player2Dead = false;
    public GameObject Player1;
    public GameObject Player2;
    public float respawnDelay = 1f; // ���X�|�[���̒x������
    public GameObject Player1Start;
    public GameObject Player2Start;

    public string GameOverSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player1)
        {
            Player1Dead = true;
            // Player1���G�ꂽ�ꍇ�APlayer2�̋߂��Ń��X�|�[��
            StartCoroutine(RespawnPlayer(Player1, Player2.transform.position));
        }
        else if (other.gameObject == Player2)
        {
            Player2Dead = true;
            // Player2���G�ꂽ�ꍇ�APlayer1�̋߂��Ń��X�|�[��
            StartCoroutine(RespawnPlayer(Player2, Player1.transform.position));
        }
    }

    private IEnumerator RespawnPlayer(GameObject player, Vector3 targetPosition)
    {
        if(Player1Dead==true&&Player2Dead==true)//2�l�������Ɏ��񂾂�
        {
            GameOver();//�Q�[���I�[�o�[���̏��������s
        }

        // ���X�|�[���̒x��
        yield return new WaitForSeconds(respawnDelay);

        // ���X�|�[���ʒu�̐ݒ�
        Vector3 respawnPosition = new Vector3(targetPosition.x, targetPosition.y+1, targetPosition.z);
        player.transform.position = respawnPosition;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero; // ���x�����Z�b�g
            rb.angularVelocity = Vector3.zero; // ��]���x�����Z�b�g
        }

        Player1Dead = false;
        Player2Dead = false;
    }

    private void GameOver()//�Q�[���I�[�o�[���̏����������ɏ���
    {
        SceneManager.LoadScene(GameOverSceneName);
    }
}
