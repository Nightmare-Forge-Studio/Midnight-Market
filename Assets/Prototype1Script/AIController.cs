using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class AIController : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public float sightRange;
    private bool playerInSightRange = false;
    public LayerMask whatIsPlayer;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        // playerController = GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

                if (playerInSightRange)
                {
                    agent.SetDestination(player.transform.position);
                }
                else
                {
                    agent.ResetPath();
                }*/
        // Direction from the enemy to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Check if there's a clear line of sight between the enemy and the player
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, directionToPlayer, out hitInfo, sightRange, whatIsPlayer))
        {
            // The ray hit something on the player's layer, meaning the enemy can see the player
            agent.SetDestination(player.transform.position);
            Debug.DrawRay(transform.position, directionToPlayer, Color.green);
        }
        else
        {
            // The ray did not hit the player's layer, meaning the player is not in sight
            Debug.DrawRay(transform.position, directionToPlayer, Color.red);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerController.TakeDamage();
            Debug.Log("letsgo");
        }
    }


    private void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,sightRange);
    }
}
