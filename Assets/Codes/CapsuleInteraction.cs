using UnityEngine;
using UnityEngine.UI;

public class CapsuleInteraction : MonoBehaviour
{
    public GameObject player;          // 플레이어 오브젝트
    public float interactionRange = 5f; // 캡슐이 사라지는 거리
    public GameObject capsulePanel;    // "캡슐을 얻었습니다!" UI 패널
    public Button yesButton;           // Yes 버튼
    public Button noButton;            // No 버튼
    public GameObject panel1;          // 랜덤으로 활성화될 패널 1
    public GameObject panel2;          // 랜덤으로 활성화될 패널 2
    public GameObject panel3;          // 랜덤으로 활성화될 패널 3
    public GameObject panel4;          // 랜덤으로 활성화될 패널 4

    private FriendPointRandom friendPointRandom;

    public GameObject pointPanel;      // 점수를 표시할 패널
    public Text scoreText;             // 점수 텍스트
    private int score = 0;             // 점수 값

    // 각 패널에 있는 완료 버튼
    public Button completeButton1;
    public Button completeButton2;
    public Button completeButton3;
    public Button completeButton4;

    private void Awake()
    {
        yesButton.onClick.AddListener(YesButtonClicked);  // Yes 버튼 클릭 시 YesButtonClicked 호출
        noButton.onClick.AddListener(ClosePanel);         // No 버튼 클릭 시 ClosePanel 호출

        // 각 완료 버튼에 CompleteButtonClicked 연결
        completeButton1.onClick.AddListener(CompleteButtonClicked);
        completeButton2.onClick.AddListener(CompleteButtonClicked);
        completeButton3.onClick.AddListener(CompleteButtonClicked);
        completeButton4.onClick.AddListener(CompleteButtonClicked);
    }

    private void Start()
    {
        capsulePanel.SetActive(false); // 초기에는 캡슐 패널 비활성화

        // 모든 랜덤 패널 비활성화
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);

        pointPanel.SetActive(false);   // 초기에는 점수 패널 비활성화
    }

    private void Update()
    {
        // 플레이어와 캡슐 사이의 거리 계산
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // 특정 거리 안에 플레이어가 들어오면 캡슐 제거 및 패널 표시
        if (distance <= interactionRange)
        {
            capsulePanel.SetActive(true); // UI 패널 활성화
            gameObject.SetActive(false);  // 캡슐 오브젝트 비활성화
            
        }
    }

    private void YesButtonClicked()
    {
        capsulePanel.SetActive(false); // 캡슐 패널 비활성화
        pointPanel.SetActive(false);   // 점수 패널 초기화 (숨기기)

        // 랜덤으로 패널 선택 및 활성화
        int randomPanel = Random.Range(1, 5);
        switch (randomPanel)
        {
            case 1:
                panel1.SetActive(true);
                break;
            case 2:
                panel2.SetActive(true);
                break;
            case 3:
                panel3.SetActive(true);
                break;
            case 4:
                panel4.SetActive(true);
                break;
        }

        FriendPointRandom friendPointRandom = GetComponent<FriendPointRandom>();
        if (friendPointRandom != null)
        {
            friendPointRandom.SetRandomPosition();
            gameObject.SetActive(true);
        }
    }

    private void ClosePanel()
    {
        Debug.Log("ClosePanel 호출됨"); // 호출 확인 메시지
        capsulePanel.SetActive(false); // UI 패널 비활성화
    }

    private void CompleteButtonClicked()
    {
        // 점수를 증가시키고 텍스트 업데이트
        score += 1;
        scoreText.text = "점수: " + score;

        // 점수 패널 활성화
        pointPanel.SetActive(true);

        // 활성화된 패널을 모두 비활성화
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);
    }
}
