using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IPlayer
{

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int value){
        score+=value;
    }

private void OnTriggerEnter2D(Collider2D other) {
    Food food = other.GetComponent<Food>();
    if(food!=null){
        AddScore(food.points);
    }
}

    public void Walk(){}
    public void Eat(){}
    public void Damage(){}
    public void Death(){}
    public void Win(){}
    public void Lose(){}
}
