using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    GrenadeJump GJ;

    public int maxAmmo = 5;
    public int currentAmmo;
    public int ammoPickup = 1;
    
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public bool canThrow = true;
    public Transform firingPoint;

    // Start is called before the first frame update
    void Start()
    {
        canThrow = true;
        currentAmmo = maxAmmo;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ThrowGrenade();
        }

        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }

    void ThrowGrenade()
    {
        if (canThrow)
        {
            GameObject grenade = Instantiate(grenadePrefab, firingPoint.transform.position, firingPoint.transform.rotation);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);

            currentAmmo --;
            Debug.Log(currentAmmo);
            if (currentAmmo > 0)
            {
                StartCoroutine(ThrowingNadeDelay());
            }
            //StartCoroutine(ThrowingNadeDelay());
        }
        if (currentAmmo <= 0)
        {
            canThrow = false;
        }
    }

    public IEnumerator ThrowingNadeDelay()
    {
        canThrow = false;
        yield return new WaitForSeconds(2f);
        canThrow = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GrenadeEgg"))
        {
            ammoPickup =+ ammoPickup;
        }
    }
}
