using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public string currentLevelScene = "Level1";
    public string nextLevelScene = "Level2";

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevelScene);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}