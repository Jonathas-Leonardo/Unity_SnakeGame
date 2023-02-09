using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour
{
[SerializeField]
    private int tile_x =0;
  [SerializeField]
    private int tile_y =0;
    public Tile tile_pfb;
    public List<Tile> tile_list = new List<Tile>();
    public GameObject pivotCenter_obj;
    // Start is called before the first frame update
    void Start()
    {
        if(tile_pfb==null){return;}
        GenerateGrid();
        pivotCenter_obj.transform.position = CalcCenterPosition(tile_x-1,(tile_y-1)*-1);
    }

    private void GenerateGrid(){
        for (var y = 0; y < tile_y; y++)
        {
            for (var i = 0; i < tile_x; i++)
            {
                int index = (y*tile_x)+i+1;
                Tile tile_obj = Instantiate(tile_pfb,new Vector2(i,-y),Quaternion.identity);
                tile_obj.name="Tile_"+index;
                tile_obj.gameObject.transform.parent = transform;
                tile_obj.index = index;
                tile_list.Add(tile_obj);
            }
        }
    }

    private Vector2 CalcCenterPosition(float x, float y ){
        return new Vector2(x/2f,y/2f);
    }
}
