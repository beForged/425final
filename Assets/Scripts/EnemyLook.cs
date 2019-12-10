using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLook : MonoBehaviour
{

    // https://docs.unity3d.com/Manual/nav-AgentPatrol.html
    // also have logic for chasing after player (aggro radius)
    public float gazeRadius = 1; // radians?
    private Transform points;
    private Transform player;
    Animator anim;
    public GameObject model;


    private int destPoint = 0;
    NavMeshAgent agent;
    public float origSpeed = 5f;
    public float chaseSpeed = 8f;

    Light flashlight;
    
    void Awake() {
        points = transform.parent.Find("PatrolPoints");
        player = GameObject.FindWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = model.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GoToNextPoint();

        flashlight = GetComponentInChildren<Light>();
    }

    //patrol logic
    void GoToNextPoint()
    {
        //no points to patrol between
        if (points.childCount == 0)
        {
            return;
        }
        agent.destination = points.GetChild(destPoint).position;
        destPoint = (destPoint + 1) % points.childCount;
    }
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        Vector3 targetDirection = player.position - transform.position;
        float viewAngle = Vector3.Angle(targetDirection, transform.forward);
        // if player is visible to agent
        // maybe if the player makes sound or gets in close but not too close they turn and face player?
        if ((viewAngle >= -60 && viewAngle <= 60) && dist <= 10f)
        {
            agent.SetDestination(player.position);
            agent.speed = chaseSpeed;
            anim.SetBool("isRunning", true);

            if (dist <= agent.stoppingDistance)
            {
                face(player);
            }

            flashlight.color = Color.red; // might be cool to make it such that the player is "shot" or something only when the flashlight hits them
        }
        else if(!agent.pathPending && agent.remainingDistance < .5f)
        {
            // if player isnt there
            anim.SetBool("isRunning", false);
            agent.speed = origSpeed;
            GoToNextPoint();

            flashlight.color = Color.green;
        }
    }

    void face(Transform target)
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion Rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, Time.deltaTime * 2f);
    }
}
