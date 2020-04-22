using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody controller;

    public float speed;
    public float baseSpeed = 15f;
    public float sprintSpeed = 20f;
    public bool sprinting;

    public float velocity = 10f;

    public bool isGrounded;

    public float distanceGround = 1.2f;

    public LayerMask groundLayer;

    public Transform firingPoint;
    public GameObject grenade;

    public UIManager UI;
    public GameManager GM;


    //Calling on the CharacterController Component
    void Start()
    {
        controller = GetComponent<Rigidbody>();

        sprinting = false;

        speed = baseSpeed;

        Cursor.visible = false;
    }

    //Calling the PlayerJumping function
    void Update()
    {
        Movement();
        Grounded();
        Jump();
    }

    //Creating the player jumping, and player movement function.
    //If the player is on ground then he is able to jump, depending on the jumpforce and gravity.
    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);

        Jump();

        if (Input.GetKey(KeyCode.LeftShift) && !sprinting && isGrounded)
        {
            sprinting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && sprinting)
        {
            sprinting = false;
        }

        if (sprinting)
        {
            speed = sprintSpeed;
        }

        if (!sprinting)
        {
            speed = baseSpeed;
        }

    }

    public void Jump()
    {
        //controller.AddForce(new Vector3(0, velocity, 0));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            controller.AddForce(new Vector3(0, velocity, 0));
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            controller.AddForce(new Vector3(0, velocity, 0) * 2);
        }
    }

    void Grounded()
    {
        RaycastHit hit;
        Vector3 dir = new Vector3(0, -1, 0);

        if (Physics.Raycast(transform.position, dir, out hit, distanceGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (other.gameObject.CompareTag("WinBox"))
        {
            Debug.Log("hit");
            UI.winPanel.SetActive(true);
            Time.timeScale = 0f;
            UI.inGamePanel.SetActive(false);
            GM.PCMX.canMove = false;
            GM.PCMY.canMove = false;
            GM.wonGame = true;
            //player.GetComponent<Renderer>().material.color = Color.green;
            //SceneManager.LoadScene("_Scene_01");
        }
    }
}
