using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;

    public GameManager GM;




    void Start()
    {
       
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        GameObject gm = GameObject.Find("GameManager");

        GM = gm.GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        LookRadius();
    }

    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
       

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // animator.SetTrigger("death");

            //gameManager.RestartGame();
            Debug.Log("Silly chimken is ded");
            //Destroy(other.gameObject);
            GM.timer = 0f;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void LookRadius()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        if (dist <= lookRadius)
        {

            agent.SetDestination(target.position);

            if (dist <= agent.stoppingDistance)
            {



                FaceTarget();


            }

        }
    }
}
