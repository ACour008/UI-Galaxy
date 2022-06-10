using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnState
{
    protected Galaxy galaxy;
    protected StateManager stateManager;
    
    public TurnState(Galaxy galaxy, StateManager stateManager)
    {
        this.galaxy = galaxy;
        this.stateManager = stateManager;
    } 

    public virtual IEnumerator Start() { yield break; }
    public virtual IEnumerator Build() { yield break; }
    public virtual IEnumerator Gather() { yield break; }
    public virtual IEnumerator Scan() { yield break; }
    public virtual IEnumerator End() { yield break; }

}
