using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 5000f;   // Increased long distance (can be overridden in Inspector)
    public float baseDamage = 500f;

    public Camera playerCamera;

    void Start()
    {
        // Auto-assign main camera if none set in Inspector
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
            Debug.Log("PlayerAttack: playerCamera was null, assigned Camera.main");
        }

        Debug.Log("PlayerAttack: attackRange = " + attackRange);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        if (playerCamera == null)
        {
            Debug.LogWarning("PlayerAttack: playerCamera is null, cannot raycast.");
            return;
        }

        RaycastHit hit;

        // Ray visual debug (scene view) and log range
        Debug.DrawRay(playerCamera.transform.position,
                      playerCamera.transform.forward * attackRange,
                      Color.red,
                      1f);

        if (Physics.Raycast(playerCamera.transform.position,
                            playerCamera.transform.forward,
                            out hit,
                            attackRange))
        {
            Debug.Log("Hit object: " + hit.transform.name + " at distance: " + hit.distance);

            // Important: check parent for EnemyHealth
            EnemyHealth eh = hit.transform.GetComponentInParent<EnemyHealth>();

            if (eh != null)
            {
                eh.TakeDamage(baseDamage);
            }
            else
            {
                Debug.Log("EnemyHealth NOT Found on hit object");
            }
        }
        else
        {
            Debug.Log("No hit within range: " + attackRange);
        }
    }
}
