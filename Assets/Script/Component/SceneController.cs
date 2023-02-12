using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    public TileGrid tileGrid;

    Action onItemGetting; 

    void Awake(){
        if(instance==null){instance=this;}
    }

    private void Start() {
       onItemGetting += OnGetItem;
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.M)){
            tileGrid.GetRandomEmptyTilePosition();
        }
    }

    public void OnGetItem(){

    }

    IEnumerator GetItems(){
        yield return new WaitForSeconds(1000);
    }
}