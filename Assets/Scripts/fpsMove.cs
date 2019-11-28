using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsMove : MonoBehaviour
{
    public float speed = 10;
    public float jumpHeight = 5;
    public float gravity = 20f;

    private CharacterController cc;

    private Vector3 move = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //jumping code
        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            move.y = jumpHeight;           
        }
        //add gravity
        move.y -= gravity * Time.deltaTime;

        float strafe = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        //moving front and back
        move.x = speed * forward;
        move.z = speed * strafe ;

        //actually move the character
        cc.Move(transform.TransformDirection(move * Time.deltaTime));
    }
}
