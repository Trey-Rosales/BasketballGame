using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public BasketballGame2D gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            gameManager.AddScore();
        }
    }
}