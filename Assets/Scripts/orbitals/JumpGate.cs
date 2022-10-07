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
    public override double Radius { get => solarRadius * Utils.Conversions.RO_EARTH; }
    public override double Mass { get => solarMass * Utils.Conversions.MO_EARTH; }


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

    public override void Initialize(OrbitalSettings setting, Orbital parent, Government government, string name, bool generateAll)
    {
    }
}
