using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    //public HealthBar healthBar;

    private void Awake()
    {
        currentHealth = startingHealth;
        //healthBar.SetMaxHealth(startingHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.SetHealth(currentHealth);


        //Restarts entire game if player dies
        /*if(currentHealth <= 0)
        {
            SceneManager.LoadScene(3);
        }*/

        if(currentHealth <= 0)
        {
            RestartScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            //RestartScene()

            currentHealth = 0;
        }

        if(other.gameObject.CompareTag("Farmer"))
        {
            //Hurt()

            //currentHealth -= 20;
        }

        if(other.gameObject.CompareTag("Fox"))
        {
            //Hurt()

            //currentHealth -= 20;
        }
    }

    public void RestartScene()
    {
        //Insert death animation??

        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }

    public void Hurt()
    {
        //Insert hurt animation??
    }
}
