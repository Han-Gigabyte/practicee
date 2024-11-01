using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FriendlyInteraction : MonoBehaviour
{
    public GameObject player;                  // 플레이어 오브젝트
    public float interactionRange = 2f;        // 친구 오브젝트와의 상호작용 거리
    public GameObject FriendlyPanel;           // "친구를 얻었습니다!" UI 패널
    public GameObject friendListPanel;         // 친구 목록 패널 (오른쪽 화면에 표시)
    public Button closeButton;                 // 패널 닫기 버튼
    public Button yesButton;                   // 친구 추가 버튼
    public Button buttonPrefab;                 // 친구 목록에 추가할 버튼 프리팹
    public LobbyManager lobbyManager;           // LobbyManager 스크립트의 인스턴스

    private List<string> friendNames = new List<string>(); // 친구 이름을 저장하는 리스트

    private void Awake()
    {
        closeButton.onClick.AddListener(ClosePanel);       // Close 버튼 클릭 시 ClosePanel 호출
        yesButton.onClick.AddListener(AddFriendToList);    // Yes 버튼 클릭 시 AddFriendToList 호출
    }

    private void Start()
    {
        FriendlyPanel.SetActive(false);        // 초기에는 패널을 비활성화
        friendListPanel.SetActive(true);       // 친구 목록 패널 활성화

        
    }

    private void Update()
    {
        // 플레이어와 친구 오브젝트 사이의 거리 계산
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // 특정 거리 안에 플레이어가 들어오면 친구 오브젝트 제거 및 패널 표시
        if (distance <= interactionRange)
        {
            FriendlyPanel.SetActive(true);    // UI 패널 활성화
            gameObject.SetActive(false);      // 친구 오브젝트 삭제
        }
    }

    private void ClosePanel()
    {
        Debug.Log("ClosePanel 호출됨");       // 호출 확인 메시지
        FriendlyPanel.SetActive(false);       // UI 패널 비활성화
    }

    public void AddFriendToList()
    {
        Debug.Log("AddFriendToList 호출됨"); // 호출 확인 메시지

        // 오브젝트 이름을 친구 목록에 추가
        string friendName = gameObject.name;
        friendNames.Add(friendName);

        // friendListPanel에 새로운 버튼 생성
        Button newButton = Instantiate(buttonPrefab, friendListPanel.transform);
        newButton.GetComponentInChildren<Text>().text = friendName;  // 버튼의 텍스트를 친구 이름으로 설정

        // 버튼 클릭 시 OnFriendButtonClicked 함수 호출
        newButton.onClick.AddListener(() => OnFriendButtonClicked(friendName));

        // 친구 추가 패널 비활성화 후 "친구가 추가되었습니다!" 패널 활성화
        FriendlyPanel.SetActive(false);
    }

    private void OnFriendButtonClicked(string friendName)
    {
        Debug.Log($"{friendName} 버튼이 클릭되었습니다.");

        // LobbyManager의 StartGame 함수 호출
        if (lobbyManager != null)
        {
            lobbyManager.StartGame(friendName);
        }
        else
        {
            Debug.LogError("LobbyManager가 null입니다. 확인하세요.");
        }
    }
}
