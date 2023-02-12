using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target_obj;
    [SerializeField] private bool IsMoveToTarget;

    // Start is called before the first frame update
    void Start()
    {
        if (target_obj == null) { return; }
        GetTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (target_obj == null) { return; }
        if (IsMoveToTarget) { GetTargetPosition(); }
    }

    private void GetTargetPosition()
    {
        //if(target_obj==null){return;}
        Vector3 target_pos = target_obj.transform.position;
        transform.position = new Vector3(target_pos.x, target_pos.y, transform.position.z);
    }
}
