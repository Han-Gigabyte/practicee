using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CapsuleInteraction : MonoBehaviour
{
    public GameObject player;       // 플레이어 오브젝트
    public float interactionRange = 10f; // 캡슐이 사라지는 거리
    public GameObject capsulePanel; // "캡슐을 얻었습니다!" UI 패널
    public Button closeButton;      // 패널 닫기 버튼

    private void Start()
    {
        capsulePanel.SetActive(false); // 초기에는 패널을 비활성화
        closeButton.onClick.AddListener(ClosePanel); // 버튼 클릭 시 ClosePanel 호출
    }

    private void Update()
    {
        // 플레이어와 캡슐 사이의 거리 계산
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // 특정 거리 안에 플레이어가 들어오면 캡슐 제거 및 패널 표시
        if (distance <= interactionRange)
        {
            capsulePanel.SetActive(true); // UI 패널 활성화
            Destroy(gameObject); // 캡슐 오브젝트 삭제
        }
    }

    private void ClosePanel()
    {
        Debug.Log("ClosePanel 호출됨"); // 호출 확인 메시지
        capsulePanel.SetActive(false); // UI 패널 비활성화
    }
}
