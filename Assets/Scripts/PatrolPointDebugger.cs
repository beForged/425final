using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPointDebugger : MonoBehaviour {
    public void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 0.75f);
    }
    public void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.75f);
    }
}
