using UnityEngine;

public class CapsuleMovement : MonoBehaviour
{
    public GameObject player;  // �÷��̾� ������Ʈ�� ����
    public float spawnDistance = 10f; // �÷��̾� �þ� �ڿ��� ĸ���� ������ �Ÿ�
    public float moveSpeed = 2f; // ĸ�� �̵� �ӵ�

    private void Start()
    {
        // �÷��̾ �ִ� ������ �ݴ��� ��ġ ���
        Vector3 spawnPosition = player.transform.position - player.transform.forward * spawnDistance;
        transform.position = spawnPosition;
    }

    private void Update()
    {
        // �÷��̾� �������� �̵�
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
    }
}
