using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{

    public int points=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.name);
        if(gameObject.tag.ToLower()=="player"){
            // Player other_obj = other.gameObject.GetComponent<Player>();
            // other.gameObject.GetComponent<Player>();
            Destroy(this);
        }
    }
}
