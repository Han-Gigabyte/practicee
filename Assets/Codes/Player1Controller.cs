using UnityEngine;
using UnityEngine.UI;

public class Player1Controller : MonoBehaviour
{
    public GameObject player2;            // Player2 오브젝트
    public GameObject friendUI1;          // UI 오브젝트
    public Button buttonYes;              // Yes 버튼
    public Button buttonNo;               // No 버튼
    public GameObject boat;               // Boat 오브젝트

    private const float activationDistance = 10f; // 거리가 10 이내일 때 UI 활성화

    private void Start()
    {
        // 시작 시 UI 비활성화
        friendUI1.SetActive(false);

        // 버튼 클릭 이벤트 설정
        buttonYes.onClick.AddListener(OnYesButtonClicked);
        buttonNo.onClick.AddListener(OnNoButtonClicked);
    }

    private void Update()
    {
        // Player1과 Player2 간의 거리 계산
        float distance = Vector3.Distance(transform.position, player2.transform.position);

        // 거리가 10 이내일 때만 UI 활성화
        if (distance <= activationDistance)
        {
            friendUI1.SetActive(true);
        }
        else
        {
            friendUI1.SetActive(false);
        }
    }

    private void OnYesButtonClicked()
    {
        // Player2 안의 Wood_BoatV2 오브젝트를 비활성화
        Transform woodBoat = player2.transform.Find("Wood_BoatV2");
        if (woodBoat != null)
        {
            woodBoat.gameObject.SetActive(false); // Wood_BoatV2 비활성화
        }

        // Player2를 Boat 오브젝트의 자식으로 설정
        if (boat != null)
        {
            player2.transform.SetParent(boat.transform);
            
        }
        else
        {
            Debug.LogWarning("Boat object is not assigned.");
        }

        // UI 비활성화
        friendUI1.SetActive(false);
    }

    private void OnNoButtonClicked()
    {
        // 단순히 UI 비활성화
        friendUI1.SetActive(false);
    }
}
