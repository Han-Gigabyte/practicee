using UnityEngine;

public class FriendPointRandom : MonoBehaviour
{
    // 오브젝트가 활성화될 때 호출되는 메서드
    private void Awake()
    {
        SetRandomPosition();
    }

    private void SetRandomPosition()
    {
        float randomX;
        float randomZ;
        float fixedY = 0f;

        // -10에서 10 사이의 값이 아닐 때까지 랜덤 값을 생성
        do
        {
            randomX = Random.Range(-50f, 50f);
            randomZ = Random.Range(-50f, 50f);
        } while (randomX >= -10f && randomX <= 10f && randomZ >= -10f && randomZ <= 10f);

        // 위치 설정
        transform.position = new Vector3(randomX, fixedY, randomZ);
    }
}
