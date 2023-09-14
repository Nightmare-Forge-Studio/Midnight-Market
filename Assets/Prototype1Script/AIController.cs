using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Vector3 range;
    public Transform[] waypoint;

    enum EnemyState
    {
        non_active,
        activating,
        idle,
        seeking,
        chasing,
        attacking
    }
    // Start is called before the first frame update
    void Start()
    {
        EnemyState state;
        state = EnemyState.non_active;
        
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
            EnemyPatrol();
        }

    }
    private void EnemyPatrol(){
        if (!agent.hasPath)
        {   
        int randomIndex= Random.Range(0 ,waypoint.Length );
        agent.SetDestination(waypoint[randomIndex].position);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //give damage to player
            playerController.TakeDamage();

        }
    }


    private void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,sightRange);
    }
}
