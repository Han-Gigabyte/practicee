using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public Vector3 offset = new Vector3(0f, 2f, -5f); // 플레이어 뒤쪽에 카메라를 배치하기 위한 오프셋
    public float sensitivity = 100f; // 마우스 감도

    private float currentYRotation = 0f;

    void Start()
    {
        // 초기 Y 회전값을 플레이어의 Y 회전값으로 설정
        currentYRotation = player.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // 마우스 입력 받기
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        // Y축 회전값 업데이트
        currentYRotation += mouseX;

        // 플레이어와 카메라의 회전 업데이트
        player.rotation = Quaternion.Euler(0f, currentYRotation, 0f);

        // 카메라 위치 업데이트 (플레이어 위치 + 오프셋을 회전값에 따라 이동시킴)
        Quaternion rotation = Quaternion.Euler(0f, currentYRotation, 0f);
        transform.position = player.position + rotation * offset;

        // 카메라가 플레이어를 바라보도록 회전 설정
        transform.LookAt(player.position + Vector3.up * 1.5f); // 약간 위쪽을 바라보도록
    }
}
