using UnityEngine;

public class Gamemovement : MonoBehaviour
{
    public float moveSpeed = 30f;      // 플레이어의 이동 속도
    public float jumpForce = 7f;      // 점프 힘
    private Rigidbody rb;              // Rigidbody 참조
    private bool isGrounded;           // 지면에 닿았는지 확인

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트 가져오기
    }

    void Update()
    {
        // 점프 체크
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // 이동 방향을 입력으로 받기
        float horizontal = Input.GetAxis("Horizontal"); // A/D 또는 좌/우 화살표
        float vertical = Input.GetAxis("Vertical");     // W/S 또는 위/아래 화살표

        Vector3 move = new Vector3(horizontal, 0, vertical).normalized; // 이동 벡터 생성 및 정규화

        // 물리 이동
        rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);

        // 점프 기능
        if (isGrounded && Input.GetButtonDown("Jump")) // 땅에 있을 때 점프
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 점프 힘 추가
        }
    }
}