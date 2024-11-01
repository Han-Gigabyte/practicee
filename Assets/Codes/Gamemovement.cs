using UnityEngine;

public class Gamemovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 3f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; // 충돌 감지 모드 설정
    }

    void FixedUpdate()
    {
        // 이동 방향을 입력으로 받기
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical).normalized;

        // 옆면 충돌 감지
        if (!IsWallInDirection(move))
        {
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void Update()
    {
        // 점프 체크
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // 벽 충돌 감지 메서드
    private bool IsWallInDirection(Vector3 direction)
    {
        RaycastHit hit;
        float distance = 0.6f; // 벽까지의 최소 거리 설정 (필요시 조정 가능)
        return Physics.Raycast(transform.position, direction, out hit, distance);
    }
}
