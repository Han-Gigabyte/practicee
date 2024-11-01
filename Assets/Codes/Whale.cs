using UnityEngine;
using UnityEngine.UI;

public class Whale : MonoBehaviour // 클래스 이름은 관례에 따라 대문자로 시작해야 합니다.
{
    public GameObject panel_whale; // 고래 UI 패널
    public GameObject player; // 플레이어 오브젝트
    public Camera mainCamera; // 메인 카메라
    public float interactionRange = 5f; // 상호작용 범위
    public Button yesButton; // 예 버튼
    public Button noButton; // 아니요 버튼
    public float ballSpeed = 10f; // 공이 이동하는 속도

    public GameObject currentBall; // 현재 생성된 공의 참조
    private bool isBallMoving = false; // 공이 이동 중인지 여부

    private void Awake()
    {
        yesButton.onClick.AddListener(YesButtonClicked);  // 예 버튼 클릭 시 호출
        noButton.onClick.AddListener(ClosePanel);         // 아니요 버튼 클릭 시 호출
    }

    private void Update()
    {
        // 플레이어와 고래 사이의 거리 계산
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // 플레이어가 상호작용 범위 안에 들어오면 패널 표시
        if (distance <= interactionRange)
        {
            panel_whale.SetActive(true); // UI 패널 활성화
        }

        // U 키가 눌렸을 때 공을 앞으로 이동
        if (Input.GetKeyDown(KeyCode.U))
        {
            MoveBallForward();
        }
    }

    private void YesButtonClicked()
    {
        panel_whale.SetActive(false); // 고래 패널 비활성화
        SpawnBallAtPlayer(); // 플레이어 위치에 공 생성
    }

    private void SpawnBallAtPlayer()
    {
        // 기본 구체 오브젝트를 생성하고 플레이어 앞쪽에 배치
        currentBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        // 플레이어 위치에서 3만큼 앞쪽으로 이동
        Vector3 spawnPosition = player.transform.position + player.transform.forward * 1f;
        currentBall.transform.position = spawnPosition;

        currentBall.transform.localScale = Vector3.one; // 구의 크기를 조정할 수 있습니다.

        // 공을 플레이어의 자식으로 설정
        currentBall.transform.SetParent(player.transform);

        // 공에 Rigidbody 추가
        Rigidbody ballRigidbody = currentBall.AddComponent<Rigidbody>();
        ballRigidbody.useGravity = false; // 중력을 사용하지 않으려면 false로 설정
    }

    private void MoveBallForward()
    {
        if (currentBall != null && !isBallMoving)
        {
            isBallMoving = true; // 공이 이동 중임을 표시
            StartCoroutine(MoveBall());
        }
    }

    private System.Collections.IEnumerator MoveBall()
    {
        Vector3 forwardDirection = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z).normalized; // Y축은 0으로 설정

        while (currentBall != null)
        {
            // 공을 앞으로 이동
            currentBall.transform.position += forwardDirection * ballSpeed * Time.deltaTime;

            yield return null; // 다음 프레임 대기
        }
        isBallMoving = false; // 공 이동이 끝났음을 표시
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 공이 고래와 충돌할 경우
        if (collision.gameObject == currentBall)
        {
            Destroy(currentBall); // 공 제거
            Destroy(gameObject);  // 고래 제거
        }
    }

    private void ClosePanel()
    {
        Debug.Log("ClosePanel 호출됨"); // 호출 확인 메시지
        panel_whale.SetActive(false); // UI 패널 비활성화
    }
}
