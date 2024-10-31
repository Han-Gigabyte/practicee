using UnityEngine;

public class CapsuleMovement : MonoBehaviour
{
    public GameObject player;  // 플레이어 오브젝트를 참조
    public float spawnDistance = 10f; // 플레이어 시야 뒤에서 캡슐이 생성될 거리
    public float moveSpeed = 2f; // 캡슐 이동 속도

    private void Start()
    {
        // 플레이어가 있는 방향의 반대쪽 위치 계산
        Vector3 spawnPosition = player.transform.position - player.transform.forward * spawnDistance;
        transform.position = spawnPosition;
    }

    private void Update()
    {
        // 플레이어 방향으로 이동
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
    }
}
