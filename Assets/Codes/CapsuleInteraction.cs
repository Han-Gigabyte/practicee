using UnityEngine;
using UnityEngine.UI;

public class CapsuleInteraction : MonoBehaviour
{
    public GameObject player;          // �÷��̾� ������Ʈ
    public float interactionRange = 5f; // ĸ���� ������� �Ÿ�
    public GameObject capsulePanel;    // "ĸ���� ������ϴ�!" UI �г�
    public Button yesButton;           // Yes ��ư
    public Button noButton;            // No ��ư
    public GameObject panel1;          // �������� Ȱ��ȭ�� �г� 1
    public GameObject panel2;          // �������� Ȱ��ȭ�� �г� 2
    public GameObject panel3;          // �������� Ȱ��ȭ�� �г� 3
    public GameObject panel4;          // �������� Ȱ��ȭ�� �г� 4

    private FriendPointRandom friendPointRandom;

    public GameObject pointPanel;      // ������ ǥ���� �г�
    public Text scoreText;             // ���� �ؽ�Ʈ
    private int score = 0;             // ���� ��

    // �� �гο� �ִ� �Ϸ� ��ư
    public Button completeButton1;
    public Button completeButton2;
    public Button completeButton3;
    public Button completeButton4;

    private void Awake()
    {
        yesButton.onClick.AddListener(YesButtonClicked);  // Yes ��ư Ŭ�� �� YesButtonClicked ȣ��
        noButton.onClick.AddListener(ClosePanel);         // No ��ư Ŭ�� �� ClosePanel ȣ��

        // �� �Ϸ� ��ư�� CompleteButtonClicked ����
        completeButton1.onClick.AddListener(CompleteButtonClicked);
        completeButton2.onClick.AddListener(CompleteButtonClicked);
        completeButton3.onClick.AddListener(CompleteButtonClicked);
        completeButton4.onClick.AddListener(CompleteButtonClicked);
    }

    private void Start()
    {
        capsulePanel.SetActive(false); // �ʱ⿡�� ĸ�� �г� ��Ȱ��ȭ

        // ��� ���� �г� ��Ȱ��ȭ
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);

        pointPanel.SetActive(false);   // �ʱ⿡�� ���� �г� ��Ȱ��ȭ
    }

    private void Update()
    {
        // �÷��̾�� ĸ�� ������ �Ÿ� ���
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // Ư�� �Ÿ� �ȿ� �÷��̾ ������ ĸ�� ���� �� �г� ǥ��
        if (distance <= interactionRange)
        {
            capsulePanel.SetActive(true); // UI �г� Ȱ��ȭ
            gameObject.SetActive(false);  // ĸ�� ������Ʈ ��Ȱ��ȭ
            
        }
    }

    private void YesButtonClicked()
    {
        capsulePanel.SetActive(false); // ĸ�� �г� ��Ȱ��ȭ
        pointPanel.SetActive(false);   // ���� �г� �ʱ�ȭ (�����)

        // �������� �г� ���� �� Ȱ��ȭ
        int randomPanel = Random.Range(1, 5);
        switch (randomPanel)
        {
            case 1:
                panel1.SetActive(true);
                break;
            case 2:
                panel2.SetActive(true);
                break;
            case 3:
                panel3.SetActive(true);
                break;
            case 4:
                panel4.SetActive(true);
                break;
        }

        FriendPointRandom friendPointRandom = GetComponent<FriendPointRandom>();
        if (friendPointRandom != null)
        {
            friendPointRandom.SetRandomPosition();
            gameObject.SetActive(true);
        }
    }

    private void ClosePanel()
    {
        Debug.Log("ClosePanel ȣ���"); // ȣ�� Ȯ�� �޽���
        capsulePanel.SetActive(false); // UI �г� ��Ȱ��ȭ
    }

    private void CompleteButtonClicked()
    {
        // ������ ������Ű�� �ؽ�Ʈ ������Ʈ
        score += 1;
        scoreText.text = "����: " + score;

        // ���� �г� Ȱ��ȭ
        pointPanel.SetActive(true);

        // Ȱ��ȭ�� �г��� ��� ��Ȱ��ȭ
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);
    }
}
