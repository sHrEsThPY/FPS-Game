using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    private float currentHealth;

    public Slider healthSlider;

    private int hitCount = 0;  // For increasing damage
    public bool isAngry = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(float baseDamage)
    {
        hitCount++;

        // Har hit pe +5 damage
        float finalDamage = baseDamage + (hitCount * 5f);

        currentHealth -= finalDamage;

        isAngry = true;

        Debug.Log("Damage Given: " + finalDamage);
        Debug.Log("Enemy Health Now: " + currentHealth);

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Destroyed!");
        Destroy(gameObject);
    }
}
