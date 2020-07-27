using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    public Spawn spawn;

    private void Awake()
    {
        currentHealth = startingHealth;
        spawn = FindObjectOfType<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <=1)
        {
            //Spawn.instance.callSpawn();
            Destroy(gameObject);
        }
    }
}
