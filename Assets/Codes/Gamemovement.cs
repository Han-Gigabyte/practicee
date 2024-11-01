using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가

public class Gamemovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 3f;
    public int lives = 3; // 플레이어의 목숨 수
    public Text currentLivesText; // 현재 목숨 개수를 표시할 UI Text
    public GameObject gameOverPanel; // 게임 오버 패널
    public GameObject gameClearPanel; // 게임 클리어 패널
    private Rigidbody rb;
    private bool isGrounded;

    public GameSceneManager gameSceneManager;

    // 원래 위치
    private Vector3 startingPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; // 충돌 감지 모드 설정

        startingPosition = new Vector3(0, 3, -3); // 원래 위치 설정
        transform.position = startingPosition; // 시작할 때 원래 위치로 설정

        UpdateLivesText(); // 초기 목숨 표시 업데이트
        gameOverPanel.SetActive(false); // 게임 오버 패널 비활성화
        gameClearPanel.SetActive(false); // 게임 클리어 패널 비활성화
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

    private void OnTriggerEnter(Collider other)
    {
        // deadline 오브젝트와 충돌 체크
        if (other.CompareTag("Deadline"))
        {
            // 플레이어 위치를 원래 위치로 되돌리기
            transform.position = startingPosition;

            // 목숨 1 감소
            lives--;

            // 현재 목숨 텍스트 업데이트
            UpdateLivesText();

            // 목숨이 소진되었는지 체크
            if (lives <= 0)
            {
                HandleGameOver(); // 게임 오버 처리 함수 호출
            }
        }
        else if (other.CompareTag("Goal")) // "Goal" 태그가 설정된 목표 지점 오브젝트
        {
            HandleGameClear(); // 게임 클리어 처리 함수 호출
        }
        else if (other.CompareTag("BouncePlatform")) // "BouncePlatform" 태그가 설정된 발판
        {
            Bounce(); // 발판에 닿았을 때 튕겨 오르는 함수 호출
        }
    }

    // 벽 충돌 감지 메서드
    private bool IsWallInDirection(Vector3 direction)
    {
        RaycastHit hit;
        float distance = 0.6f; // 벽까지의 최소 거리 설정 (필요시 조정 가능)
        return Physics.Raycast(transform.position, direction, out hit, distance);
    }

    private void Bounce()
    {
        rb.AddForce(Vector3.up * jumpForce * 3, ForceMode.Impulse); // jumpForce의 두 배로 위로 튕겨 오름
    }

    private void HandleGameClear()
    {
        Debug.Log("게임 클리어!"); // 게임 클리어 메시지 출력
        gameClearPanel.SetActive(true); // 게임 클리어 패널 활성화
        StartCoroutine(HandleGameClearCoroutine()); // Coroutine 시작
    }

    private IEnumerator HandleGameClearCoroutine()
    {
        yield return new WaitForSeconds(3f); // 3초 대기
        gameSceneManager.GameEnd(); // 게임 종료 처리 호출
    }

    private void HandleGameOver()
    {
        Debug.Log("게임 오버!"); // 게임 오버 메시지 출력
        gameOverPanel.SetActive(true); // 게임 오버 패널 활성화
        StartCoroutine(HandleGameOverCoroutine()); // Coroutine 시작
    }

    private IEnumerator HandleGameOverCoroutine()
    {
        yield return new WaitForSeconds(3f); // 3초 대기
        gameSceneManager.GameEnd(); // 게임 종료 처리 호출
    }

    // 현재 목숨 텍스트 업데이트 메서드
    private void UpdateLivesText()
    {
        currentLivesText.text = "Life: " + lives; // 현재 목숨 개수 표시
    }
}
