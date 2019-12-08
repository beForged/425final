using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideJump : MonoBehaviour {
    public int side = 0;
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("AllowWallJump")) {
            transform.parent.GetComponent<fpsMove>().SideCollision(side);
        }
    }
}
