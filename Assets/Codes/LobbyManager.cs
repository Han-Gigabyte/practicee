using UnityEngine.SceneManagement;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public void StartGame(string friendName)
    {
        SceneManager.LoadScene("MiniGameScene"); // MiniGameScene �̸����� �� �ε�
    }
}
