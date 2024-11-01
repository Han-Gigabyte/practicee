using UnityEngine;

public class DeadlineTrigger : MonoBehaviour
{
    public Transform targetposition;  // 이동할 목표 위치

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 "player" 태그를 가진 경우
        if (other.CompareTag("Player"))
        {
            // 플레이어의 위치를 targetPosition의 위치로 이동
            other.transform.position = targetposition.position;
        }
    }
}
