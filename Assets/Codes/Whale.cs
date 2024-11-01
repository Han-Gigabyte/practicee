using UnityEngine;
using UnityEngine.UI;

public class Whale : MonoBehaviour // Ŭ���� �̸��� ���ʿ� ���� �빮�ڷ� �����ؾ� �մϴ�.
{
    public GameObject panel_whale; // �� UI �г�
    public GameObject player; // �÷��̾� ������Ʈ
    public Camera mainCamera; // ���� ī�޶�
    public float interactionRange = 5f; // ��ȣ�ۿ� ����
    public Button yesButton; // �� ��ư
    public Button noButton; // �ƴϿ� ��ư
    public float ballSpeed = 10f; // ���� �̵��ϴ� �ӵ�

    public GameObject currentBall; // ���� ������ ���� ����
    private bool isBallMoving = false; // ���� �̵� ������ ����

    private void Awake()
    {
        yesButton.onClick.AddListener(YesButtonClicked);  // �� ��ư Ŭ�� �� ȣ��
        noButton.onClick.AddListener(ClosePanel);         // �ƴϿ� ��ư Ŭ�� �� ȣ��
    }

    private void Update()
    {
        // �÷��̾�� �� ������ �Ÿ� ���
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // �÷��̾ ��ȣ�ۿ� ���� �ȿ� ������ �г� ǥ��
        if (distance <= interactionRange)
        {
            panel_whale.SetActive(true); // UI �г� Ȱ��ȭ
        }

        // U Ű�� ������ �� ���� ������ �̵�
        if (Input.GetKeyDown(KeyCode.U))
        {
            MoveBallForward();
        }
    }

    private void YesButtonClicked()
    {
        panel_whale.SetActive(false); // �� �г� ��Ȱ��ȭ
        SpawnBallAtPlayer(); // �÷��̾� ��ġ�� �� ����
    }

    private void SpawnBallAtPlayer()
    {
        // �⺻ ��ü ������Ʈ�� �����ϰ� �÷��̾� ���ʿ� ��ġ
        currentBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        // �÷��̾� ��ġ���� 3��ŭ �������� �̵�
        Vector3 spawnPosition = player.transform.position + player.transform.forward * 1f;
        currentBall.transform.position = spawnPosition;

        currentBall.transform.localScale = Vector3.one; // ���� ũ�⸦ ������ �� �ֽ��ϴ�.

        // ���� �÷��̾��� �ڽ����� ����
        currentBall.transform.SetParent(player.transform);

        // ���� Rigidbody �߰�
        Rigidbody ballRigidbody = currentBall.AddComponent<Rigidbody>();
        ballRigidbody.useGravity = false; // �߷��� ������� �������� false�� ����
    }

    private void MoveBallForward()
    {
        if (currentBall != null && !isBallMoving)
        {
            isBallMoving = true; // ���� �̵� ������ ǥ��
            StartCoroutine(MoveBall());
        }
    }

    private System.Collections.IEnumerator MoveBall()
    {
        Vector3 forwardDirection = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z).normalized; // Y���� 0���� ����

        while (currentBall != null)
        {
            // ���� ������ �̵�
            currentBall.transform.position += forwardDirection * ballSpeed * Time.deltaTime;

            yield return null; // ���� ������ ���
        }
        isBallMoving = false; // �� �̵��� �������� ǥ��
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���� ���� �浹�� ���
        if (collision.gameObject == currentBall)
        {
            Destroy(currentBall); // �� ����
            Destroy(gameObject);  // �� ����
        }
    }

    private void ClosePanel()
    {
        Debug.Log("ClosePanel ȣ���"); // ȣ�� Ȯ�� �޽���
        panel_whale.SetActive(false); // UI �г� ��Ȱ��ȭ
    }
}
