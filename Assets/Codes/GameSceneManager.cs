using UnityEngine.SceneManagement;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public void GameEnd()
    {
        SceneManager.LoadScene("SampleScene"); // SampleScene 이름으로 씬 로드
    }
}
