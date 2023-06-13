using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI_2 : MonoBehaviour
{
    public int maxEnemyHP = 400;
    public int currentEnemyHP;
    public GameObject GameManager_2;

    public GameObject player;
    NavMeshAgent agent;
    Animator animator;

    public float distance;

    Collider theCollider;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        currentEnemyHP = maxEnemyHP;

    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {

        theCollider = GetComponent<Collider>();


        if (currentEnemyHP >= 0)
        {
            distance = Vector3.Distance(agent.transform.position, player.transform.position);



            if (distance >= 26)
            {
                animator.SetBool("idle", true);
                animator.SetBool("run", false);
                animator.SetBool("atack", false);
                animator.SetBool("damage", false);
                animator.SetBool("death", false);



            }
            if (distance <= 25)
            {
                agent.destination = player.transform.position;
                animator.SetBool("idle", false);
                animator.SetBool("run", true);
                animator.SetBool("atack", false);
                animator.SetBool("damage", false);
                animator.SetBool("death", false);



            }
            if (distance <= 2)
            {
                animator.SetBool("idle", false);
                animator.SetBool("run", false);
                animator.SetBool("atack", true);
                animator.SetBool("damage", false);
                animator.SetBool("death", false);



            }
        }

        if (currentEnemyHP <= 0)
        {



            animator.SetBool("death", true);

            agent.Stop(true);
            theCollider.enabled = false;

            animator.SetBool("idle", false);
            animator.SetBool("run", false);
            animator.SetBool("atack", false);
            animator.SetBool("damage", false);

        }





    }
    public void takeDamage()
    {
        gameManager_2 GM_2 = GameManager_2.GetComponent<gameManager_2>();
        currentEnemyHP -= 40;
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("atack", false);
        animator.SetBool("damage", true);
        animator.SetBool("death", false);
        if (currentEnemyHP <= 0)
        {
            GM_2.zombieKilled++;
        }

    }
}
