using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeJump : MonoBehaviour
{
    public float radius = 5.0f;
    public float power = 500.0f;
    public float upForce = 10f;
    public int damage;

    public float delay = 3f;
    float countdown;
    public bool hasExploded = false;

// Start is called before the first frame update
void Start()
    {
        //Explosion();
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(power, transform.position, radius, upForce, ForceMode.Impulse);
            }

            EnemyHealth enemyHealth = nearbyObject.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.currentHealth = enemyHealth.currentHealth - damage;
            }
        }

        Destroy(gameObject);
        Debug.Log("BOOM");
    }
}
