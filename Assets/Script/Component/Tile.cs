using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] public bool IsCollider;
    [SerializeField] public bool IsVisited;
    [SerializeField] public bool IsWarped;
    private Color32 default_color;
    [SerializeField] private Color32 trigger_color;
    [SerializeField] private Color32 visited_color;
    [SerializeField] private int numberColliders;
    public UnityEvent tileEvent;

    private Renderer rend; //Component

    public Vector2 destinationPos;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        default_color = rend.material.color;
        if(IsWarped){rend.enabled=false;}
    }


    // Update is called once per frame
    void Update()
    {
        if (IsVisited) { rend.material.color = visited_color; }
        else if (IsCollider) { rend.material.color = trigger_color; }
        else { rend.material.color = default_color; }
    }

    public void SetIndex(int value){index = value;}

    public int GetIndex(){return index;}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        Food food = other.GetComponent<Food>();
        SnakeBody snakeBody = other.GetComponent<SnakeBody>();

        if (player == null && food == null && snakeBody == null) { return; }

        numberColliders++;

        if(IsWarped){return;}
        if (!IsVisited)
        {
            TileGrid.instance.AddTileVisited(this.index);
        }
        IsVisited = true;
        IsCollider = (numberColliders > 0);

        if (numberColliders == 1)
        {
            TileGrid.instance.AddTileSelected(index);
            TileGrid.instance.RemoveTileEmpty(index);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        Food food = other.GetComponent<Food>();
        SnakeBody snakeBody = other.GetComponent<SnakeBody>();

        if (player == null && food == null && snakeBody == null) { return; }


        numberColliders--;
        IsCollider = (numberColliders > 0);

        if(IsWarped){return;}
        if (numberColliders == 0)
        {
            TileGrid.instance.RemoveTileSelected(index);
            TileGrid.instance.AddTileEmpty(index);
        }
    }
}
