using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    public void Walk();
    public void Eat();
    public void Damage();
    public void Death();
    public void Win();
    public void Lose();
}
