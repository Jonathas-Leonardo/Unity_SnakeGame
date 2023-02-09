using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGizmos : MonoBehaviour
{
    public float radius=.2f;
    private void OnDrawGizmos() {
        Vector3 vec = transform.position;
        Gizmos.DrawWireSphere(vec,radius);
    }

    private void OnDrawGizmosSelected() {
                Vector3 vec = transform.position;
        Gizmos.DrawWireSphere(vec,radius);
    }
}
