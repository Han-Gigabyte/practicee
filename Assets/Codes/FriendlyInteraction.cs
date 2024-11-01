using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FriendlyInteraction : MonoBehaviour
{
    public GameObject player;       // �÷��̾� ������Ʈ
    public float interactionRange = 2f; // ģ�� �谡 ������� �Ÿ�
    public GameObject FriendlyPanel; // "ģ���� ������ϴ�!" UI �г�
    public Button closeButton;      // �г� �ݱ� ��ư

    private void Start()
    {
        FriendlyPanel.SetActive(false); // �ʱ⿡�� �г��� ��Ȱ��ȭ
        closeButton.onClick.AddListener(ClosePanel); // ��ư Ŭ�� �� ClosePanel ȣ��
    }

    private void Update()
    {
        // �÷��̾�� ĸ�� ������ �Ÿ� ���
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // Ư�� �Ÿ� �ȿ� �÷��̾ ������ ĸ�� ���� �� �г� ǥ��
        if (distance <= interactionRange)
        {
            FriendlyPanel.SetActive(true); // UI �г� Ȱ��ȭ
            Destroy(gameObject); // ĸ�� ������Ʈ ����
        }
    }

    private void ClosePanel()
    {
        Debug.Log("ClosePanel ȣ���"); // ȣ�� Ȯ�� �޽���
        FriendlyPanel.SetActive(false); // UI �г� ��Ȱ��ȭ
    }
}
