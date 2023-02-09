using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null) { return; }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) { return; }

        if (Input.GetKeyDown(KeyCode.I))
        {
            player.Walk();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            player.TurnLeft();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            player.TurnRight();
        }
    }
}
