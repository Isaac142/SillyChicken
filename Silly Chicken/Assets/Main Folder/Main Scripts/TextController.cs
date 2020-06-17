using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public GameObject grenade;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - grenade.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = grenade.transform.position + offset;
    }
}
