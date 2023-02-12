using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{

    [SerializeField] private int points=1;

    private void OnTriggerEnter2D(Collider2D other) {
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null){
            Vector3? vec = TileGrid.instance.GetRandomEmptyTilePosition();
            if(vec==null){
                Destroy(gameObject);
                return;
            }
            transform.position = vec.Value;
        }
    }

    public int GetPoints(){
        return points;
    }

    public void SetPosition(Vector2 vec){
        transform.position = vec;
    }
}
