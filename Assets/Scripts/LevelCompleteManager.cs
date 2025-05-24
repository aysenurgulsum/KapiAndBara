using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCompleteManager : MonoBehaviour
{
    public Image[] stars;
    public Sprite fullStarSprite;
    public Sprite emptyStarSprite;
    public TextMeshProUGUI scoreText;
    public int oneStarThreshold = 50;
    public int twoStarThreshold = 80;
    public int threeStarThreshold = 110;

    void Start()
    {
        string levelName = LevelTracker.LastPlayedLevel;
        int score = PlayerPrefs.GetInt("LevelScore", 0);
        Debug.Log("LevelScore: " + score);
        scoreText.text = "Skor: " + score.ToString();

        int starCount = 0;
        if (score >= oneStarThreshold) starCount = 1;
        if (score >= twoStarThreshold) starCount = 2;
        if (score >= threeStarThreshold) starCount = 3;

        PlayerPrefs.SetInt("Stars_" + levelName, starCount);
        PlayerPrefs.Save();

        ShowStars(starCount);
    }

    void ShowStars(int starCount)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (stars[i] != null)
            {
                stars[i].enabled = true;
                stars[i].sprite = i < starCount ? fullStarSprite : emptyStarSprite;
            }
        }
    }

}
