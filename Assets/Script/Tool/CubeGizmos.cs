using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGizmos : MonoBehaviour
{
    public float radius_x=.2f;
    public float radius_y=.2f;
    private void OnDrawGizmos() {
        Vector3 vec = transform.position;
        Gizmos.DrawWireCube(vec,new Vector3(radius_x,radius_y,1));
    }

    private void OnDrawGizmosSelected() {
        Vector3 vec = transform.position;
        Gizmos.DrawWireCube(vec,new Vector3(radius_x,radius_y,1));
        //Gizmos.DrawWireCube(vec,Vector3.one*radius);
    }
}
