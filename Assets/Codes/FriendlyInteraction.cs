using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FriendlyInteraction : MonoBehaviour
{
    public GameObject player;                  // �÷��̾� ������Ʈ
    public float interactionRange = 2f;        // ģ�� ������Ʈ���� ��ȣ�ۿ� �Ÿ�
    public GameObject FriendlyPanel;           // "ģ���� ������ϴ�!" UI �г�
    public GameObject friendListPanel;         // ģ�� ��� �г� (������ ȭ�鿡 ǥ��)
    public Button closeButton;                 // �г� �ݱ� ��ư
    public Button yesButton;                   // ģ�� �߰� ��ư
    public Button buttonPrefab;                 // ģ�� ��Ͽ� �߰��� ��ư ������
    public LobbyManager lobbyManager;           // LobbyManager ��ũ��Ʈ�� �ν��Ͻ�

    private List<string> friendNames = new List<string>(); // ģ�� �̸��� �����ϴ� ����Ʈ

    private void Awake()
    {
        closeButton.onClick.AddListener(ClosePanel);       // Close ��ư Ŭ�� �� ClosePanel ȣ��
        yesButton.onClick.AddListener(AddFriendToList);    // Yes ��ư Ŭ�� �� AddFriendToList ȣ��
    }

    private void Start()
    {
        FriendlyPanel.SetActive(false);        // �ʱ⿡�� �г��� ��Ȱ��ȭ
        friendListPanel.SetActive(true);       // ģ�� ��� �г� Ȱ��ȭ

        
    }

    private void Update()
    {
        // �÷��̾�� ģ�� ������Ʈ ������ �Ÿ� ���
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // Ư�� �Ÿ� �ȿ� �÷��̾ ������ ģ�� ������Ʈ ���� �� �г� ǥ��
        if (distance <= interactionRange)
        {
            FriendlyPanel.SetActive(true);    // UI �г� Ȱ��ȭ
            gameObject.SetActive(false);      // ģ�� ������Ʈ ����
        }
    }

    private void ClosePanel()
    {
        Debug.Log("ClosePanel ȣ���");       // ȣ�� Ȯ�� �޽���
        FriendlyPanel.SetActive(false);       // UI �г� ��Ȱ��ȭ
    }

    public void AddFriendToList()
    {
        Debug.Log("AddFriendToList ȣ���"); // ȣ�� Ȯ�� �޽���

        // ������Ʈ �̸��� ģ�� ��Ͽ� �߰�
        string friendName = gameObject.name;
        friendNames.Add(friendName);

        // friendListPanel�� ���ο� ��ư ����
        Button newButton = Instantiate(buttonPrefab, friendListPanel.transform);
        newButton.GetComponentInChildren<Text>().text = friendName;  // ��ư�� �ؽ�Ʈ�� ģ�� �̸����� ����

        // ��ư Ŭ�� �� OnFriendButtonClicked �Լ� ȣ��
        newButton.onClick.AddListener(() => OnFriendButtonClicked(friendName));

        // ģ�� �߰� �г� ��Ȱ��ȭ �� "ģ���� �߰��Ǿ����ϴ�!" �г� Ȱ��ȭ
        FriendlyPanel.SetActive(false);
    }

    private void OnFriendButtonClicked(string friendName)
    {
        Debug.Log($"{friendName} ��ư�� Ŭ���Ǿ����ϴ�.");

        // LobbyManager�� StartGame �Լ� ȣ��
        if (lobbyManager != null)
        {
            lobbyManager.StartGame(friendName);
        }
        else
        {
            Debug.LogError("LobbyManager�� null�Դϴ�. Ȯ���ϼ���.");
        }
    }
}
