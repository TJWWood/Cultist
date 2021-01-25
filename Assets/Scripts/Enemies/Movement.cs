using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Movement : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    public float sightRange;
    public float attackRange;
    public LayerMask playerMask;
    public Transform[] points;
    private int destPoint = 0;

    bool playerInSightRange;
    bool playerInAttackRange;

    bool hasCastMagic;
    public float castTimer;
    public float castTime;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        anim = gameObject.GetComponent<Animator>();
        castTimer = castTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCastMagic)
        {
            castTimer -= Time.deltaTime;
            if (castTimer <= 0)
            {
                hasCastMagic = false;
                castTimer = castTime;
            }
        }

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (!playerInSightRange)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                PatrolPoints();
            }
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            FollowPlayer();
        }

        if(playerInAttackRange)
        {
            if (!hasCastMagic)
            {
                AttackPlayer();
            }
        }
    }

    void PatrolPoints()
    {
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    void FollowPlayer()
    {
        agent.destination = player.position;
    }

    void AttackPlayer()
    {
        if(TryGetComponent<CastMagic>(out CastMagic cm))
        {
            Destroy(cm);
            gameObject.AddComponent<CastMagic>();
        }
        else
        {
            gameObject.AddComponent<CastMagic>();
        }
        hasCastMagic = true; 
    }

    
    /**
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, sightRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, attackRange);
    }
    */
}
