using UnityEngine.SceneManagement;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public void GameEnd()
    {
        SceneManager.LoadScene("SampleScene"); // SampleScene �̸����� �� �ε�
    }
}
