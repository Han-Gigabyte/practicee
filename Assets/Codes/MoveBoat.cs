using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float speed = 5f; // �̵� �ӵ�

    void Update()
    {
        // Ű���� �Է� ó��
        float moveHorizontal = Input.GetAxis("Horizontal"); // �¿� �̵�
        float moveVertical = Input.GetAxis("Vertical"); // �յ� �̵�

        // �̵� ���� ���
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // �� �̵�
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}