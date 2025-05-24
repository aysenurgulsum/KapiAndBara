using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButtonExtended : MonoBehaviour
{
    public string levelName;
    public Image[] starImages;
    public Sprite fullStar;
    public Sprite emptyStar;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        int stars = PlayerPrefs.GetInt("Stars_" + levelName, 0);
        int score = PlayerPrefs.GetInt("Score_" + levelName, 0);

        // Butonu aktif/pasif yap
        GetComponent<Button>().interactable = (levelName == "1_Level" || LevelDataManager.IsLevelUnlocked(levelName));

        // Yıldızları göster
        for (int i = 0; i < starImages.Length; i++)
        {
            if (i < stars)
                starImages[i].sprite = fullStar;
            else
                starImages[i].sprite = emptyStar;
        }

        // Skor yazısı
        if (scoreText != null)
        {
            scoreText.text = "Skor: " + score.ToString();
        }
    }

    void OnEnable()
{
    UpdateButton();
}

void UpdateButton()
{
    int stars = PlayerPrefs.GetInt("Stars_" + levelName, 0);
    int score = PlayerPrefs.GetInt("Score_" + levelName, 0);

    GetComponent<Button>().interactable = (levelName == "1_Level" || LevelDataManager.IsLevelUnlocked(levelName));

    for (int i = 0; i < starImages.Length; i++)
    {
        if (starImages[i] != null)
        {
            starImages[i].sprite = i < stars ? fullStar : emptyStar;
        }
    }

    if (scoreText != null)
    {
        scoreText.text = "Skor: " + score.ToString();
    }

    Debug.Log($"Level: {levelName}, Stars: {stars}, Score: {score}");
}

}
