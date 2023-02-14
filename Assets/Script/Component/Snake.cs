using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Player
{
    public SnakeBody snakeBody_pfb;
    [SerializeField] private int numberOfBody=0;
    [SerializeField] private List<SnakeBody> snakeBody_list = new List<SnakeBody>();
    [SerializeField] private SnakeBody lastBody;
    private SnakeBody snakeBody;

    private void Start() {
        snakeBody = GetComponent<SnakeBody>();
        snakeBody_list.Add(snakeBody);
        lastBody = snakeBody;
        numberOfBody++;
    }

    public override void Walk()
    {
        snakeBody.Walk(transform.position);
        base.Walk();
    }

    public void Warp(){
        
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        Food food = other.GetComponent<Food>();
        if (food != null)
        {
            CreateBody(lastBody.transform.position);
        }
    }

    public void CreateBody(Vector2 pos){
        SnakeBody body_obj = Instantiate(snakeBody_pfb,pos,Quaternion.identity);
        body_obj.name="Body_"+numberOfBody;
        numberOfBody++;
        snakeBody_list.Add(body_obj);
        lastBody.SetChild(body_obj);
        lastBody = body_obj;
    }
}