using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed; //movement speed in units per second
    public float jumpForce; //force applied upwards


    [Header("Camera")]
    public float lookSensitivity; //look sensitivity
    public float maxLookX; //lowest down we can look
    public float minLookX; //Highest up we can look
    private float rotX; //current x roation of the camera
    private Camera cam;
    private Rigidbody rig;
    [Header("Weapon")]
    private ProjectileWeapon weapon;


    void Awake()
    {
        //Get the components
        cam = Camera.main;
        rig = GetComponent<Rigidbody>();
        weapon = GetComponent<ProjectileWeapon>(); //Get Weapon Script Component

        Cursor.lockState = CursorLockMode.Locked;   
    }
    


    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();

        if(Input.GetButtonDown("Jump"))
            TryJump();
        
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot()) //If CanShoot is true
                weapon.Shoot(); //Fire the weapon
        }
    }

    void Move(){
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //Move relative to the cameras forward direction
        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rig.velocity.y;
        
        rig.velocity = dir;
    }

    void CamLook(){
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX); //Clamp the vertical rotation on the x-axis

        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0); //drive rotation on the x-axis
        transform.eulerAngles += Vector3.up * y; //drive rotation on the y-axis
    }

    void TryJump(){
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }
}
