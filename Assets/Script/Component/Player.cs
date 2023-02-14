using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    [SerializeField] private int score = 0;

    public void AddScore(int value)
    {
        score += value;
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        Food food = other.GetComponent<Food>();
        if (food != null)
        {
            AddScore(food.GetPoints());
        }
    }

    public virtual void TurnLeft()
    {
        transform.eulerAngles += new Vector3(0, 0, 90);
        Walk();
    }

    public virtual void TurnRight()
    {
        transform.eulerAngles += new Vector3(0, 0, -90);
        Walk();
    }

    public virtual void Walk()
    {
        transform.position += transform.right;
    }
}
