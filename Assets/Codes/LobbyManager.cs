using UnityEngine.SceneManagement;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // GameScene 이름으로 씬 로드
    }
}
