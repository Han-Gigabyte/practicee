using UnityEngine.SceneManagement;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public void StartGame(string friendName)
    {
        SceneManager.LoadScene("MiniGameScene"); // MiniGameScene 이름으로 씬 로드
    }
}
