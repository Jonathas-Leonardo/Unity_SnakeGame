using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="SnakeModel")]
public class SnakeModel : ScriptableObject
{
    public SnakeBody snakeBody_pfb;
    [SerializeField] private int numberOfBody=0;
    [SerializeField] private List<SnakeBody> snakeBody_list = new List<SnakeBody>();
    [SerializeField] private SnakeBody lastBody;
    private SnakeBody snakeBody;

    public bool IsWarped;
}
