using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("GateOpen", true);
        anim.SetBool("GateClose", false);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            anim.SetBool("GateOpen", true);
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    anim.SetTrigger("GateOpen");
    //}
}
