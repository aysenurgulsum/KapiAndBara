using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public string levelName;
    public bool isLocked = true;

    void Start()
    {
        // İlk level her zaman açık olsun
        if (levelName == "1_Level")
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            int stars = PlayerPrefs.GetInt("Stars_" + levelName, 0);
            GetComponent<Button>().interactable = stars >= 1;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
