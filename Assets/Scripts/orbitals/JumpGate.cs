using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpGate: Orbital
{
    private JumpgateType type;
    private LineRenderer lineRenderer;

    private int home = int.MinValue;
    private int destination = int.MinValue;

    public int Home { get => home; }
    public int Destination { get => destination; }


    private void Awake()
    {
        name = "Jump Gate " + LehmerRNG.Next(0, 20);
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.startWidth = 0.045f;
        lineRenderer.endWidth = 0.045f;
    }

    public void CreateConnection(StarSystem fromSystem, StarSystem toSystem)
    {

        lineRenderer.SetPosition(0, fromSystem.Position);
        lineRenderer.SetPosition(1, toSystem.Position);
        home = fromSystem.Id;
        destination = toSystem.Id;

        this.gameObject.SetActive(true);
    }
}
