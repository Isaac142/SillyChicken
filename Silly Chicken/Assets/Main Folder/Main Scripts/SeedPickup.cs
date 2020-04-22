using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedPickup : MonoBehaviour
{
    public GameObject pickupEffect;

    public static SeedPickup instance;

    public GameManager GM;
    int score;

    public int seedValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        GameObject gm = GameObject.Find("GameManager");

        GM = gm.GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);

            instance.ChangeScore(seedValue);

            Destroy(gameObject);
        }
    }

    public void ChangeScore(int seedValue)
    {
        score += seedValue;
        GM.seedText.text = "x" + score.ToString();
    }
}
