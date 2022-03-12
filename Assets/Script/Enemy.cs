using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float speed;
    private float playerDetectedTime;
    public float playerDetectedRate;
    public float chaseRange;

    [Header("Attack")]
    [SerializeField] float attackRange;
    [SerializeField] int dmg;
    [SerializeField] float attackRate;
    private float lastAttackTime;

    [Header("Component")]
    Rigidbody2D rb;
    private playerController targetPlayer;

    [Header("PathFinding")]
    public float nextWaypointDistance = 2f;
    Path path;
    int currentWaypoint = 0;
    bool reachEndPath = false;
    Seeker seeker;




    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void onPathComplete(Path p){
        //En gros on reset le chemin
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void UpdatePath()
    {  
        //Commence le chemin de la position X a la position du joueur 
        if(seeker.IsDone() && targetPlayer != null)
        {
            //Et si il a reussi on appelle la fonction onPathComplete pour reset le chemin
            seeker.StartPath(rb.position, targetPlayer.transform.position, onPathComplete);
        }
    }

    private void FixedUpdate() {

        if(targetPlayer != null)
        {
            float dist = Vector2.Distance(transform.position, targetPlayer.transform.position);
            if(dist < attackRange && Time.time - lastAttackTime >= attackRate)
            {
                //attack
                rb.velocity = Vector2.zero;
            }
            else if( dist > attackRange)
            {
                if(path == null)
                {
                    return;
                }
                if(currentWaypoint > path.vectorPath.Count)
                {
                    reachEndPath = true;
                }
                else
                {
                    reachEndPath = false;
                }

                Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
                Vector2 force = direction * speed * Time.fixedDeltaTime;
                rb.velocity = force;

                float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
                if(distance <  nextWaypointDistance)
                {
                    currentWaypoint++;
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

        }
          
        DetectPlayer();
    }

    void DetectPlayer()
    {
        if(Time.time - playerDetectedTime > playerDetectedRate)
        {
            playerDetectedTime = Time.time;
            foreach (playerController player in FindObjectsOfType<playerController>())
            {
                if(player != null)
                {
                    float dist = Vector2.Distance(transform.position, player.transform.position);
                    if(player == targetPlayer)
                    {
                        if(dist > chaseRange)
                        {
                            targetPlayer = null;
                        }
                    }else if(dist < chaseRange)
                    {
                        if(targetPlayer == null)
                        {
                            targetPlayer = player;
                        }
                    }
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
