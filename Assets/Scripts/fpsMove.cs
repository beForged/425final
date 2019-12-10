using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fpsMove : MonoBehaviour {
    public float speed = 10;
    public float jumpHeight = 5;
    public float gravity = 20f;

    private CharacterController cc;

    private Vector3 move = Vector3.zero;

    private float lightlevel = 1;

    public int NumJumps = 3; 
    private int multiJump = 0; // allow for double, triple, whatever jumps
    private Color surfaceColor;
    //private LayerMask layerMask;
    private  float brightness1;

    private AudioSource feet;
    public AudioClip footsteps;
    public AudioClip fasterFootsteps;

    // Start is called before the first frame update
    void Start() {
        cc = GetComponent<CharacterController>();
        // multiJump = NumJumps;
        feet = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ResetToMenu(.3f));
        }
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
        // Debug.Log(feet.isPlaying);
        if (!feet.isPlaying && cc.isGrounded && (move.x != 0 || move.z != 0)) {
            feet.Play();
        } else if (!cc.isGrounded || (move.x == 0 && move.z == 0)) {
            feet.Pause();
        }
        // fast?
        if (lightlevel == 1) {
            feet.clip = fasterFootsteps;
        } else {
            feet.clip = footsteps;
        }

        // actually move the player
        // float light = lightlevel();
        cc.Move(transform.TransformDirection(lightlevel * move * Time.deltaTime));
    }

    public void SideCollision(int side) {
        // detected left/right wall jump
        // moving left is < 0, and left side returns (-1) so move.x * side > 0
        // moving right is > 0, and right side returns (1) so move.x * side > 0
        // else, no beans
        // Debug.Log(move.x * side);
        
        if (move.x * side > 0) {
            multiJump = NumJumps;
        }

        // do this version if you are okay with people multi-jumping up a single wall
        // multiJump = NumJumps;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("collectible")) {
            other.gameObject.GetComponent<Collectible>().collect();
            StartCoroutine(ResetToMenu(1f));
        }

        if(other.gameObject.CompareTag("enemy"))
        {
            //Debug.Log("enemy collider enter");
            
            StartCoroutine(ResetToMenu(.1f));
        }

        //when entering lightened area
        if (other.gameObject.CompareTag("lamp"))
        {
            lightlevel = .5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //when leaving lamp collider make speed correct again
        if (other.gameObject.CompareTag("lamp"))
        {
            lightlevel = 1;
        }
    }

    IEnumerator ResetToMenu(float timeToWait) {
        ((GameManager) FindObjectOfType(typeof(GameManager))).snapSwitch("Menu", timeToWait);
		yield return new WaitForSeconds(timeToWait); // todo any pause or whatever?
        //StartCoroutine(GameObject.FindObjectOfType<Fading>().FadeAndLoadScene(Fading.FadeDirection.Out, "Main"));
        Cursor.visible = true;
		SceneManager.LoadScene("Menu");
	}

       
}
