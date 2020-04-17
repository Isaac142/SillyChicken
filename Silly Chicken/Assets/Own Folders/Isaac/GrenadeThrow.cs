using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    GrenadeJump GJ;

    public int maxAmmo = 5;
    public int currentAmmo;
    public int ammoPickup = 1;

    public bool canThrow;
    public bool hasAmmo;

    public float forwardThrowForce;
    public float upwardThrowForce;
    public GameObject grenadePrefab;
    public Transform firingPoint;

    // Start is called before the first frame update
    void Start()
    {
        canThrow = true;
        hasAmmo = true;
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

        if (currentAmmo >= 1)
        {
            hasAmmo = true;
        }

        if (currentAmmo <= 0)
        {
            hasAmmo = false;
        }
    }

    void ThrowGrenade()
    {
        if (hasAmmo)
        {
            if (canThrow)
            {
                GameObject grenade = Instantiate(grenadePrefab, firingPoint.transform.position, firingPoint.transform.rotation);
                Rigidbody rb = grenade.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * forwardThrowForce, ForceMode.VelocityChange);

                currentAmmo--;
                Debug.Log(currentAmmo);
                if (currentAmmo >= 1)
                {
                    StartCoroutine(ThrowingNadeDelay());
                }
            }
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
            currentAmmo = +ammoPickup;
            Destroy(other.gameObject);
        }
    }
}
