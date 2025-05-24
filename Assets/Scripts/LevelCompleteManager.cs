using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelCompleteManager : MonoBehaviour
{
    public Image[] stars; // Inspector'dan 3 yıldız image atayacaksın
    public TextMeshProUGUI scoreText;
    public int oneStarThreshold = 5;
    public int twoStarThreshold = 10;
    public int threeStarThreshold = 15;

    void Start()
    {
        int score = PlayerPrefs.GetInt("LevelScore", 0);
        scoreText.text = "Toplanan Skor: " + score.ToString();

        // Yıldız hesaplama
        int starCount = 0;
        if (score >= oneStarThreshold) starCount = 1;
        if (score >= twoStarThreshold) starCount = 2;
        if (score >= threeStarThreshold) starCount = 3;

        // Yıldızları göster
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = i < starCount; // İlk "starCount" kadarını göster
        }
    }
}



