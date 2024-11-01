using UnityEngine;

public class BoatController : MonoBehaviour
{
    public Transform cameraTransform; // 카메라의 Transform
    public float moveSpeed = 10f; // 배 이동 속도

    void Update()
    {
        // W/S로 좌우 이동, A/D로 앞뒤 이동
        float horizontalInput = Input.GetAxis("Horizontal"); // A(왼쪽), D(오른쪽)
        float verticalInput = -Input.GetAxis("Vertical"); // W(앞), S(뒤)

        // 카메라의 Y축 회전을 기준으로 방향을 계산
        Vector3 forward = cameraTransform.forward; // 카메라의 전방 방향
        Vector3 right = cameraTransform.right; // 카메라의 오른쪽 방향

        // 수평 평면에서의 방향 설정
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // 입력을 카메라 기준 방향에 맞추기
        Vector3 moveDirection = right * verticalInput + forward * horizontalInput;

        // 배 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 배의 회전 설정
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
