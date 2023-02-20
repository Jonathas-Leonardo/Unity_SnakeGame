using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="TileModel")]
public class TileModel : ScriptableObject
{
    [SerializeField] private int index;
    [SerializeField] public bool IsCollider;
    [SerializeField] public bool IsVisited;
    [SerializeField] public bool IsWarped;
    private Color32 default_color;
    [SerializeField] private Color32 trigger_color;
    [SerializeField] private Color32 visited_color;
    [SerializeField] private int numberColliders;
}
