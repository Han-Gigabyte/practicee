using UnityEngine.SceneManagement;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // GameScene �̸����� �� �ε�
    }
}
