using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 500f;
    private float currentHealth;

    [Header("UI")]
    public Slider healthSlider;

    [Header("Rage Damage Settings")]
    public float minDamage = 5f;    // Full health pe damage
    public float maxDamage = 50f;   // Low health pe max damage

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

    // 🔥 Health kam → Damage zyada
    public float GetCurrentDamage()
    {
        float healthPercent = currentHealth / maxHealth;

        // Inverted scaling
        float scaledDamage = Mathf.Lerp(maxDamage, minDamage, healthPercent);

        return scaledDamage;
    }
}
