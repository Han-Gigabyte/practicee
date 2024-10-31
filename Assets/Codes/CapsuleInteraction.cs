using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CapsuleInteraction : MonoBehaviour
{
    public GameObject player;       // �÷��̾� ������Ʈ
    public float interactionRange = 10f; // ĸ���� ������� �Ÿ�
    public GameObject capsulePanel; // "ĸ���� ������ϴ�!" UI �г�
    public Button closeButton;      // �г� �ݱ� ��ư

    private void Start()
    {
        capsulePanel.SetActive(false); // �ʱ⿡�� �г��� ��Ȱ��ȭ
        closeButton.onClick.AddListener(ClosePanel); // ��ư Ŭ�� �� ClosePanel ȣ��
    }

    private void Update()
    {
        // �÷��̾�� ĸ�� ������ �Ÿ� ���
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // Ư�� �Ÿ� �ȿ� �÷��̾ ������ ĸ�� ���� �� �г� ǥ��
        if (distance <= interactionRange)
        {
            capsulePanel.SetActive(true); // UI �г� Ȱ��ȭ
            Destroy(gameObject); // ĸ�� ������Ʈ ����
        }
    }

    private void ClosePanel()
    {
        Debug.Log("ClosePanel ȣ���"); // ȣ�� Ȯ�� �޽���
        capsulePanel.SetActive(false); // UI �г� ��Ȱ��ȭ
    }
}
