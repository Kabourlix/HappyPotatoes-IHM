using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Hornetscript : MonoBehaviour
{

    // Distance between the bee or the player  and the hornet
    private float TargetDistance;
    private float Playerdistance;

    // List of potential targets
    public int currenttarget;
    public Transform[] targets;
    public Transform Player;

    //Distance of pursuit
    public float chaseRange = 10;

    // Range of the attacks
    public float attackRange = 2.2f;

    // Cooldown of attacks
    public float attackRepeatTime = 1;
    private float attackTime;

    // Amount of the inflicted dammage
    public float TheDammage;

    // Agent of navigation
    private NavMeshAgent agent;

    // Animations  of the enemy
    private Animator animations;

    // Life of the enemy
    public float enemyHealth;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        //agent.baseOffset= 1f ;
        animations = gameObject.GetComponent<Animator>();
        attackTime = Time.time;
    }

    
    void Update()
    {
        //update the target
        updatetarget();
       
        // calculate the distance between the target and the hornet
        TargetDistance = Vector3.Distance(targets[currenttarget].position, transform.position);

        // when the target is too far to be attacked
        if (TargetDistance > attackRange)
        {
            // The hornet adapts its height before chasing
            float ydelta = targets[currenttarget].position.y - transform.position.y;
            if (Mathf.Abs(ydelta) < 0.02f)
            {
                chase();
            }

            else
            {
                agent.baseOffset += ydelta*0.05f ;                    
            }
        }

        // when the target is near enough to be attacked
        if (TargetDistance < attackRange)
        {
            attack();
        }
    }

    // pursuit
    void chase()
    {
        animations.Play("Move");
        agent.destination = targets[currenttarget].position;
    }

    // The hornet attack the target
    void attack()
    {
        //Without cooldown
        if (Time.time > attackTime)
        {
            animations.Play("Attack");
            targets[currenttarget].GetComponent<BeeBehavior>().ApplyDammage(TheDammage);
            attackTime = Time.time + attackRepeatTime;
        }
    }
    // When the hornet takes dammage
    public void ApplyDammage(float TheDammage)
    {
        if (!isDead)
        {
            enemyHealth = enemyHealth - TheDammage;
            animations.Play("Damage");
            if (enemyHealth <= 0)
            {
                Dead();
            }
        }
    }

    // the hornet dies
    public void Dead()
    {
        //gameObject.GetComponent<CapsuleCollider>().enabled = false;
        isDead = true;
        animations.Play("Death");
        Destroy(transform.gameObject, 5);
    }

    public void updatetarget()
    {
        // Calculate the distance between the player and the hornet
        Playerdistance = Vector3.Distance(Player.position, transform.position);
        
        // Verifying that there is still a bee alive
        bool existlivingbee = false;
        int i = 1;
        while (i < targets.Length)
        {
            if (!(targets[i] == null) && !targets[i].GetComponent<BeeBehavior>().IsDead)
            {
                existlivingbee = true;
                break;
            }
            i++;
        }
        // The player is near enough to be attacked, he becomes the target or there is no living bee
        if (Playerdistance<=attackRange || (!existlivingbee))
        {
            currenttarget = 0;
        }

        // There is an alive bee and the player is too far to be attacked
        else if (existlivingbee)
        {
            currenttarget=i;
        }
        
    }
}
