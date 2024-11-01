using UnityEngine;
using UnityEngine.UI;

public class Player1Controller : MonoBehaviour
{
    public GameObject player2;            // Player2 ������Ʈ
    public GameObject friendUI1;          // UI ������Ʈ
    public Button buttonYes;              // Yes ��ư
    public Button buttonNo;               // No ��ư
    public GameObject boat;               // Boat ������Ʈ

    private const float activationDistance = 10f; // �Ÿ��� 10 �̳��� �� UI Ȱ��ȭ

    private void Start()
    {
        // ���� �� UI ��Ȱ��ȭ
        friendUI1.SetActive(false);

        // ��ư Ŭ�� �̺�Ʈ ����
        buttonYes.onClick.AddListener(OnYesButtonClicked);
        buttonNo.onClick.AddListener(OnNoButtonClicked);
    }

    private void Update()
    {
        // Player1�� Player2 ���� �Ÿ� ���
        float distance = Vector3.Distance(transform.position, player2.transform.position);

        // �Ÿ��� 10 �̳��� ���� UI Ȱ��ȭ
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
        // Player2 ���� Wood_BoatV2 ������Ʈ�� ��Ȱ��ȭ
        Transform woodBoat = player2.transform.Find("Wood_BoatV2");
        if (woodBoat != null)
        {
            woodBoat.gameObject.SetActive(false); // Wood_BoatV2 ��Ȱ��ȭ
        }

        // Player2�� Boat ������Ʈ�� �ڽ����� ����
        if (boat != null)
        {
            player2.transform.SetParent(boat.transform);
            
        }
        else
        {
            Debug.LogWarning("Boat object is not assigned.");
        }

        // UI ��Ȱ��ȭ
        friendUI1.SetActive(false);
    }

    private void OnNoButtonClicked()
    {
        // �ܼ��� UI ��Ȱ��ȭ
        friendUI1.SetActive(false);
    }
}
