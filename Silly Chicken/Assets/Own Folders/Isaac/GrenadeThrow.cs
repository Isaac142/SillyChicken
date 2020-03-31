using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{

    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public bool canThrow = true;
    public Transform firingPoint;

    // Start is called before the first frame update
    void Start()
    {
        canThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        if (canThrow)
        {
            GameObject grenade = Instantiate(grenadePrefab, firingPoint.transform.position, firingPoint.transform.rotation);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
            StartCoroutine(ThrowingNadeDelay());
        }
    }

    public IEnumerator ThrowingNadeDelay()
    {
        canThrow = false;
        yield return new WaitForSeconds(2f);
        canThrow = true;
    }
}
