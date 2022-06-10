using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjibweTurnState : TurnState
{
    public OjibweTurnState(Galaxy galaxy, StateManager stateManager) : base(galaxy, stateManager)
    {

    }

    public override IEnumerator Start()
    {
        // Here you can decide what you wanna do.
        // and then call Scan, Gather, Build, Move based on whatever.
        yield break;
    }
}
