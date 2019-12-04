using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMove : MonoBehaviour {
    public float speed = 10;
    public float jumpHeight = 5;
    public float gravity = 20f;

    private CharacterController cc;

    private Vector3 move = Vector3.zero;

    public int NumJumps = 3; 
    private int multiJump = 0; // allow for double, triple, whatever jumps
    
    // Start is called before the first frame update
    void Start() {
        cc = GetComponent<CharacterController>();
        // multiJump = NumJumps;
    }

    // Update is called once per frame
    void Update() {
        // jumping code
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (cc.isGrounded) {
                move.y = jumpHeight;
                multiJump = NumJumps - 1;
            } else if (multiJump > 0) {
                move.y = jumpHeight;
                multiJump--;
            }
        }

        // add gravity
        if (!cc.isGrounded) {
            move.y -= gravity * Time.deltaTime;
        }

        float strafe = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        // moving WASD
        move.z = speed * forward;
        move.x = speed * strafe;

        // actually move the player
        cc.Move(transform.TransformDirection(move * Time.deltaTime));
    }
}
