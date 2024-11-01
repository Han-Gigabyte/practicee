using UnityEngine;

public class FriendPointRandom : MonoBehaviour
{
    // 오브젝트가 활성화될 때 호출되는 메서드
    void Start()
    {
        SetRandomPosition();
    }

    private void SetRandomPosition()
    {
        // x, z 축의 랜덤 값과 y = 0 고정 값 설정
        float randomX = Random.Range(-300f, 300f);
        float randomZ = Random.Range(-300f, 300f);
        float fixedY = 0f;

        // 위치 설정
        transform.position = new Vector3(randomX, fixedY, randomZ);
    }
}
