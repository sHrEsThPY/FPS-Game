using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 10f;
    public int scoreValue = 1;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        
        ScoreManager.instance.AddScore(scoreValue);

        Destroy(gameObject);
    }
}
