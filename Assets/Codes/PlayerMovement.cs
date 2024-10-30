using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // �̵� ���� ����
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical).normalized * moveSpeed;

        // Ű �Է¿� ���� �ӵ� ����
        if (move != Vector3.zero)
        {
            rb.linearVelocity = move;
        }
        else
        {
            rb.linearVelocity = Vector3.zero; // Ű�� ���� ��� ���߱�
        }
    }
}
