using UnityEngine;

public static class LevelDataManager
{
    public static int oneStarThreshold = 50;
    public static int twoStarThreshold = 80;
    public static int threeStarThreshold = 110;

    public static void SaveScore(string levelName, int score)

    {
        PlayerPrefs.SetInt($"Score_{levelName}", score);
    }

    public static void SaveStars(string levelName, int score)
    {
        int previousStars = PlayerPrefs.GetInt($"Stars_{levelName}", 0);
        //Debug.Log($"SaveStars: {levelName} - Önceki: {previousStars}, Yeni: {stars}");
        int starCount = 0;
        if (score >= threeStarThreshold){
            starCount = 3;
        }
            
        else if (score >= twoStarThreshold)
           { starCount = 2;}
        else if (score >= oneStarThreshold)
            {starCount = 1;}
        
        int stars = starCount; // Yeni yıldız sayısını hesapla

        if (stars > previousStars)
        {
            PlayerPrefs.SetInt($"Stars_{levelName}", stars);
            Debug.Log($"Yıldız güncellendi: {stars}");
        }
        else
        {
            Debug.Log("Yıldız güncellenmedi, eski yıldız daha yüksek veya eşit.");
        }
    }


    public static int GetStars(string levelName)
    {
        return PlayerPrefs.GetInt($"Stars_{levelName}", 0);
        
    }

    public static void UnlockLevel(string levelName)
    {
        PlayerPrefs.SetInt($"{levelName}_Unlocked", 1);
    }

    public static bool IsLevelUnlocked(string levelName)
    {
        return PlayerPrefs.GetInt($"{levelName}_Unlocked", 0) == 1;
    }

}
