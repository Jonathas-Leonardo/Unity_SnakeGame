using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    [SerializeField] private Vector3 prevPos;
    [SerializeField] private SnakeBody child_obj;

    public void Walk(Vector3 pos){
        prevPos = transform.position;
        transform.position = pos;
        if(child_obj==null){return;}
        child_obj.Walk(prevPos);
    }

    public void SetChild(SnakeBody obj){
        child_obj = obj;
    }
}
