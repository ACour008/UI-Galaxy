using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] Galaxy galaxy;

    TurnState currentState;

    Government ojibweGovt = new Government("Nswi Mishkodewinan", 45);
    Government englishGovt = new Government("Intergalactic Union", 45);
    Government alienGovt = new Government("SkinZim Republic", 500);

    public void SetState(TurnState state)
    {
        currentState = state;
        StartCoroutine(currentState.Start());
    }

    public void StartSimulation(int turns)
    {
    }
}
