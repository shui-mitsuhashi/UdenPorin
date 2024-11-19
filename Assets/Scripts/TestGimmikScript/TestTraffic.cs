using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTraffic : MonoBehaviour
{
    public Material RedTraffic;
    public Material BlueTraffic;

    public GameObject Player1;
    public GameObject Player2;

    public float switchInterval = 2.0f;
    private Renderer objRenderer;

    public bool IsRed = true;

    // �g���K�[���ɂ���v���C���[���Ǘ����郊�X�g
    private HashSet<GameObject> playersInTrigger = new HashSet<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        StartCoroutine(SwitchColor());
    }

    IEnumerator SwitchColor()
    {
        while (true)
        {
            if (IsRed)
            {
                objRenderer.material = RedTraffic;
            }
            else
            {
                objRenderer.material = BlueTraffic;
            }

            // �F�𔽓]
            IsRed = !IsRed;

            // �g���K�[���̃v���C���[�̓������X�V
            UpdatePlayerMovement();

            // �w�肵���Ԋu�����҂�
            yield return new WaitForSeconds(switchInterval);
        }
    }

    // �g���K�[�ɓ������Ƃ��̏���
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player1 || other.gameObject == Player2)
        {
            playersInTrigger.Add(other.gameObject);
            UpdatePlayerMovement();
        }
    }

    // �g���K�[����o���Ƃ��̏���
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player1 || other.gameObject == Player2)
        {
            playersInTrigger.Remove(other.gameObject);

            // �g���K�[����o���v���C���[�͏�ɓ�����悤�ɂ���
            EnablePlayerMovement(other.gameObject, true);
        }
    }

    // �g���K�[���̃v���C���[�̓������X�V����
    private void UpdatePlayerMovement()
    {
        // �g���K�[����Player1��Player2�̓����𐧌�
        if (playersInTrigger.Contains(Player1))
        {
            EnablePlayerMovement(Player1, IsRed); // IsRed��true�Ȃ�Player1��������
        }
        else
        {
            EnablePlayerMovement(Player1, true); // �g���K�[�O�Ȃ��ɓ�����
        }

        if (playersInTrigger.Contains(Player2))
        {
            EnablePlayerMovement(Player2, !IsRed); // IsRed��false�Ȃ�Player2��������
        }
        else
        {
            EnablePlayerMovement(Player2, true); // �g���K�[�O�Ȃ��ɓ�����
        }
    }

    // �v���C���[��MovementScript��L���܂��͖����ɂ��A�ʒu���Œ�܂��͉�������
    private void EnablePlayerMovement(GameObject player, bool enable)
    {
        var movementScript = player.GetComponent<SampleStagePlayer>(); // MovementScript�͊e�v���C���[�̈ړ��𐧌䂷��X�N���v�g��
        var rigidbody = player.GetComponent<Rigidbody>();

        if (movementScript != null)
        {
            movementScript.enabled = enable;
        }

        if (rigidbody != null)
        {
            rigidbody.isKinematic = !enable; // �����Ȃ��Ԃ͕����������~
        }
    }
}