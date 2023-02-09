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
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null){Destroy(gameObject);}
    }
}
