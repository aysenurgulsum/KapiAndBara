using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject player1;
    public GameObject player2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnBothPlayers();
        }
    }

    void RespawnBothPlayers()
    {
        if (player1 != null)
        {
            player1.transform.position = respawnPoint.position;
            Rigidbody2D rb1 = player1.GetComponent<Rigidbody2D>();
            if (rb1 != null) rb1.linearVelocity = Vector2.zero;
        }

        if (player2 != null)
        {
            player2.transform.position = respawnPoint.position;
            Rigidbody2D rb2 = player2.GetComponent<Rigidbody2D>();
            if (rb2 != null) rb2.linearVelocity = Vector2.zero;
        }
    }
}
