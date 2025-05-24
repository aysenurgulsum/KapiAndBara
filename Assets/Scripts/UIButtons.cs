using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    private string currentLevelScene;
    private string nextLevelScene;

    void Start()
    {
        currentLevelScene = LevelTracker.LastPlayedLevel;

        // Örn: "1_Level" → 1 → 2 → "2_Level"
        int levelNum = int.Parse(currentLevelScene.Split('_')[0]);
        nextLevelScene = (levelNum + 1).ToString() + "_Level";
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentLevelScene);
    }

    public void NextLevel()
    {
        if (Application.CanStreamedLevelBeLoaded(nextLevelScene))
        {
            SceneManager.LoadScene(nextLevelScene);
        }
        else
        {
            Debug.Log("Sonraki seviye bulunamadı.");
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
