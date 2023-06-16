using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    public AudioClip[] passiveSounds;
    public AudioClip[] conditionalSounds;
    public float minTimeBetweenSounds = 1f;
    public float maxTimeBetweenSounds = 5f;
    private AudioSource audioSource;
    private bool shouldPlaySounds = true;
    public int maxEnemyHP = 100;
    public int currentEnemyHP;
    public GameObject GameManager_1;
    public GameObject player;
    NavMeshAgent agent;
    Animator animator;
    public float distance;
    Collider theCollider;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayPassiveSounds());
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        currentEnemyHP = maxEnemyHP;
    }
    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        theCollider = GetComponent<Collider>();
        if (currentEnemyHP > 0)
        {
            distance = Vector3.Distance(agent.transform.position, player.transform.position);

            if (distance >= 20)
            {
                animator.SetBool("idle", true);
                animator.SetBool("run", false);
                animator.SetBool("atack", false);
                animator.SetBool("damage", false);
                animator.SetBool("death", false);
            }
            if (distance <= 19)
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
        gameManager_1 GM_1 = GameManager_1.GetComponent<gameManager_1>();
        currentEnemyHP -= 40;
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("atack", false);
        animator.SetBool("damage", true);
        animator.SetBool("death", false);
        if (currentEnemyHP <= 0)
        {
            GM_1.zombieKilled++;
        }

    }
    private IEnumerator PlayPassiveSounds()
    {
        while (shouldPlaySounds)
        {
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds));
            if (passiveSounds.Length > 0)
            {
                AudioClip soundToPlay = passiveSounds[Random.Range(0, passiveSounds.Length)];
                audioSource.PlayOneShot(soundToPlay);
            }
        }
    }

    public void PlayConditionalSound()
    {
        if (conditionalSounds.Length > 0)
        {
            AudioClip soundToPlay = conditionalSounds[Random.Range(0, conditionalSounds.Length)];
            audioSource.PlayOneShot(soundToPlay);
        }
    }
}
