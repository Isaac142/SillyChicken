using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeJump : MonoBehaviour
{
    public float radius = 5.0f;
    public float power;
    public float upForce;
    public int damage;
    public GameObject timerCanvas;
    //public Text timer;
        
    public GameObject explodeEffect;

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
            Instantiate(explodeEffect, transform.position, transform.rotation);
            Destroy(timerCanvas);
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
        SoundManager.PlaySound("Explode");
        Debug.Log("BOOM");
    }
}
