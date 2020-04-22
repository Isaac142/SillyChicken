using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Camera-Control/Mouse Look")]
public class PlayerCameraMovement : MonoBehaviour
{

    //Creating different variables for the different Axis.
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensX = 15f;
    public float sensY = 15f;

    public float minX = -360f;
    public float maxX = 360f;

    public float minY = -60f;
    public float maxY = 60f;

    private float rotationY = 0f;

    public bool canMove;

    //Calling upon the Rigidbody, and freezing their rotations.
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }

        canMove = true;
    }

    void Update()
    {

        if(canMove)
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensX;

                rotationY += Input.GetAxis("Mouse Y") * sensY;
                rotationY = Mathf.Clamp(rotationY, minY, maxY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensX, 0);
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensY;
                rotationY = Mathf.Clamp(rotationY, minY, maxY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }
    }
}
