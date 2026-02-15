using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public float speed = 6f;
    public float attackDistance = 3f;
    public float damagePerSecond = 15f;

    private Transform player;
    private NavMeshAgent agent;
    private PlayerHealth playerHealth;

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
    }

    void Update()
    {
        if (player == null || playerHealth == null)
            return;

        agent.SetDestination(player.position);

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackDistance)
        {
            playerHealth.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}
