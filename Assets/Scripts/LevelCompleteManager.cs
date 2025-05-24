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
        int currentLevelNum = int.Parse(levelName.Split('_')[0]);
        string nextLevelName = (currentLevelNum + 1).ToString() + "_Level";

        int score = PlayerPrefs.GetInt("LevelScore", 0);
        Debug.Log("LevelScore: " + score);
        scoreText.text = "Skor: " + score.ToString();

        int starCount = 0;
        if (score >= threeStarThreshold){
            starCount = 3;
        }
            
        else if (score >= twoStarThreshold)
           { starCount = 2;}
        else if (score >= oneStarThreshold)
            {starCount = 1;}


        // PlayerPrefs.SetInt("Stars_" + levelName, starCount);
        // PlayerPrefs.Save();


        //Debug.Log($"Level {levelName} için yıldız sayısı: {starCount}");
        //Debug.Log($"Level {levelName} için skor: {score}");

        if (starCount >= 1)
        {
            LevelDataManager.UnlockLevel(nextLevelName); // "Level2" yerine sonraki seviye ismini yaz
        }


        ShowStars(starCount, levelName, score);
    }

    void ShowStars(int starCount, string levelName, int score)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (stars[i] != null)
            {
                stars[i].enabled = true;
                stars[i].sprite = i < starCount ? fullStarSprite : emptyStarSprite;
            }
        }
        LevelDataManager.SaveScore(levelName, score);
        LevelDataManager.SaveStars(levelName,score);
        Debug.Log($"LevelCompleteManager çalıştı. Yıldız sayısı:  {starCount}");
    }


}