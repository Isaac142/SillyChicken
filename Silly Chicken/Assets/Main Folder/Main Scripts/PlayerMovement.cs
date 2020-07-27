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

    public bool canJump;

    public float distanceGround = 1.2f;

    public LayerMask groundLayer;

    public Transform firingPoint;
    public GameObject grenade;

    public UIManager UI;
    public GameManager GM;

    public Health ht;


    //Calling on the CharacterController Component
    void Start()
    {
        GameObject gm = GameObject.Find("GameManager");

        GM = gm.GetComponent<GameManager>();

        controller = GetComponent<Rigidbody>();

        sprinting = false;

        speed = baseSpeed;

        canJump = true;
    }

    //Calling the PlayerJumping function
    void Update()
    {
        Grounded();
        Jump();
    }

    void FixedUpdate()
    {
        Movement();
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
        if(isGrounded)
        {
            if(canJump)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    controller.AddForce(new Vector3(0, velocity, 0));

                    if(isGrounded)
                    {
                        StartCoroutine(JumpingDelay());
                    }
                }
            }
        }

        Debug.Log(velocity);
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


        if (other.gameObject.CompareTag("Water"))
        {
            ht.health--;
            //GM.timer = 0f;
        }
    }
    
    public IEnumerator JumpingDelay()
    {
        canJump = false;
        yield return new WaitForSeconds(1f);
        canJump = true;
    }
}
