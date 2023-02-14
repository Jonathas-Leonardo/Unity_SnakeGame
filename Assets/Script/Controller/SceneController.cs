using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    public TileGrid tileGrid;
    public Food food_pfb;

    Action onItemGetting; 

    void Awake(){
        if(instance==null){instance=this;}
    }

    private void Start() {

        //TileGrid.bui
       //onItemGetting += OnGetItem;
       if(food_pfb==null){return;}
       ///Vector3? vec = tileGrid.GetRandomEmptyTilePosition();
       ///LoadFood(vec.Value);
    }

    // private void LoadTileGrid(){
    //     TileGrid tileGrid = Instantiate(tileGrid_pfb,position,Quaternion.identity);
    // }

    private void LoadFood(Vector3 pos){
        Food food_obj = Instantiate(food_pfb,pos,Quaternion.identity);
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void OnGetItem(){

    }

    IEnumerator GetItems(){
        yield return new WaitForSeconds(1000);
    }
}