using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float speed = 5f; // 이동 속도

    void Update()
    {
        // 키보드 입력 처리
        float moveHorizontal = Input.GetAxis("Horizontal"); // 좌우 이동
        float moveVertical = Input.GetAxis("Vertical"); // 앞뒤 이동

        // 이동 방향 계산
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // 배 이동
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}