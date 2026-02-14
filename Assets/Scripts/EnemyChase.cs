using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform player;

    public float chaseDistance = 10f;
    public float stopDistance = 3f;

    public float normalDamage = 10f;
    public float angryDamage = 25f;

    public float normalStopDistance = 3f;
    public float angryStopDistance = 8f;

    public float attackCooldown = 1.5f;

    private float nextAttackTime;
    private NavMeshAgent agent;

    private EnemyHealth enemyHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseDistance)
        {
            agent.SetDestination(player.position);

            float currentStopDistance = enemyHealth.isAngry ? angryStopDistance : normalStopDistance;

            if (distance <= currentStopDistance && Time.time > nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
        else
        {
            agent.ResetPath();
        }
    }

    void Attack()
    {
        PlayerHealth ph = player.GetComponent<PlayerHealth>();
        if (ph == null) return;

        float damageToGive = enemyHealth.isAngry ? angryDamage : normalDamage;

        ph.TakeDamage(damageToGive);

        Debug.Log("Enemy Damage: " + damageToGive);
    }
}
