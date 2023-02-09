using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private bool IsCollider;
    private bool IsVisited;
    [SerializeField]
    private Color32 trigger_color;
    private Color32 default_color;
    [SerializeField]
    private Color32 visited_color;

    [SerializeField]
    public int index;
    public UnityEvent tileEvent;

    private Renderer rend; //Component

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        default_color = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsVisited){rend.material.color = visited_color;}
        else if(IsCollider){rend.material.color = trigger_color;}
        else{rend.material.color = default_color;}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsCollider = true;
        TileGrid.instance.tileSelected_list.Add(this);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsCollider = false;
        IsVisited = true;
        TileGrid.instance.tileSelected_list.Remove(this);
    }
}
