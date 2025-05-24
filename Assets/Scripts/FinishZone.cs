using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishZone : MonoBehaviour
{
    public string nextSceneName = "LevelCompleteScene"; // sahne adını Unity'de sen oluşturacaksın



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelTracker.LastPlayedLevel = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("LevelCompleteScene");

            // Skoru LevelComplete ekranına aktar
            PlayerPrefs.SetInt("LevelScore", ScoreManager.instance.GetScore());

            // Geçiş yap
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
