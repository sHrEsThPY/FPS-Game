using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public float speed = 6f;
    public float attackDistance = 3f;

    private Transform player;
    private NavMeshAgent agent;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
            playerHealth = playerObj.GetComponent<PlayerHealth>();
        }

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (player == null || playerHealth == null || enemyHealth == null)
            return;

        agent.SetDestination(player.position);

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackDistance)
        {
            
            float damage = enemyHealth.GetCurrentDamage();
            playerHealth.TakeDamage(damage * Time.deltaTime);
        }
    }
}
