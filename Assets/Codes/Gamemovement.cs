using UnityEngine;

public class Gamemovement : MonoBehaviour
{
    public float moveSpeed = 30f;      // �÷��̾��� �̵� �ӵ�
    public float jumpForce = 7f;      // ���� ��
    private Rigidbody rb;              // Rigidbody ����
    private bool isGrounded;           // ���鿡 ��Ҵ��� Ȯ��

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ ��������
    }

    void Update()
    {
        // ���� üũ
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // �̵� ������ �Է����� �ޱ�
        float horizontal = Input.GetAxis("Horizontal"); // A/D �Ǵ� ��/�� ȭ��ǥ
        float vertical = Input.GetAxis("Vertical");     // W/S �Ǵ� ��/�Ʒ� ȭ��ǥ

        Vector3 move = new Vector3(horizontal, 0, vertical).normalized; // �̵� ���� ���� �� ����ȭ

        // ���� �̵�
        rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);

        // ���� ���
        if (isGrounded && Input.GetButtonDown("Jump")) // ���� ���� �� ����
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // ���� �� �߰�
        }
    }
}