using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileGrid : MonoBehaviour
{
    [SerializeField] private int tile_x =0;
    [SerializeField] private int tile_y =0;
    [SerializeField] private List<Tile> tile_list = new List<Tile>();
    [SerializeField] private List<int> tileActived_list = new List<int>();
    [SerializeField] private List<int> tileEmpty_list = new List<int>();
    [SerializeField] private List<int> tileVisited_list = new List<int>();
    [SerializeField] private List<int> tileNeverVisited_list = new List<int>();
    [SerializeField] private List<Tile> tileWarped_list = new List<Tile>();
    
    public Tile tile_pfb;
    public GameObject pivotCenter_obj;
    public static TileGrid instance;

    private void Awake() {
        if(instance==null){instance=this;}
    }

    // Start is called before the first frame update
    private void Start()
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
                //if((i==0 && y==0) || (i==tile_x-1 && y== tile_y-1) || i==0 && y==tile_y-1 || y==0 && i==tile_x-1){continue;}

                int index = (y * tile_x) + i + 1;
                Tile tile_obj = Instantiate(tile_pfb, new Vector2(i, -y), Quaternion.identity);
                tile_obj.name = "Tile_" + index;
                tile_obj.gameObject.transform.parent = transform;
                tile_obj.SetIndex(index);
                tile_obj.destinationPos = SetDestination(i, y);

                if (i == 0 || i == (tile_x - 1) || y == 0 || y == (tile_y - 1))
                {
                    tile_obj.IsWarped = true;
                    tileWarped_list.Add(tile_obj);
                }
                else
                {
                    tileEmpty_list.Add(index);
                    tileNeverVisited_list.Add(index);
                }
                tile_list.Add(tile_obj);
            }
        }
    }

    private Vector2Int SetDestination(int i, int y)
    {
        int dest_x = i;
        int dest_y = y;
        int limit_x = tile_x - 1;
        int limit_y = tile_y - 1;

        if (i == 0){ dest_x = limit_x-1; }
        else if (i == limit_x){ dest_x = 1; }
        if (y == 0) { dest_y = limit_y-1; }
        else if (y == limit_y) { dest_y = 1; }

        return new Vector2Int(dest_x, -dest_y);
    }

    private Vector2 CalcCenterPosition(float x, float y )=> new Vector2(x/2f,y/2f);

    public Vector3? GetRandomEmptyTilePosition(){
        int count = GetNumberOfEmptyGrid();
        if(count<1){return null;}
        int randomIndex = Random.Range(0,count);
        int indexx = tileEmpty_list[randomIndex];
        return tile_list[indexx-1].gameObject.transform.position;
    }
    public int GetNumberOfEmptyGrid() => tileEmpty_list.Count();
    public int GetNumberOfNerverVisitedTileGrid() => tileNeverVisited_list.Count();
    public void AddTileVisited(int index)
    {
        tileVisited_list.Add(index);
        tileNeverVisited_list.Remove(index);
    }
    public void RemoveTileEmpty(int index)=>tileEmpty_list.Remove(index);
    public void AddTileEmpty(int index) => tileEmpty_list.Add(index);
    public void RemoveTileSelected(int  index) => tileActived_list.Remove(index);
    public void AddTileSelected(int index) => tileActived_list.Add(index);
}
