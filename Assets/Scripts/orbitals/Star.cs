using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Star : Orbital, IClickable
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private StarSettings data;
    private SystemType type;
    private Vector3 position;
    private Color color;
    private double luminosity;
    private Vector3 localScale;

    private int numPlanets, numJumpGates;
    private List<JumpGate> jumpGates = new List<JumpGate>();
    private List<Planet> planets = new List<Planet>();

    public event EventHandler<OnStarClickEventArgs> OnClicked;

    private PlanetCreator planetCreator;
    private JumpGateCreator jumpGateCreator;

    public SystemType Type { get => type; }
    public Vector3 Position { get => position; }
    public int PlanetCount { get => numPlanets; }
    public int JumpGateCount { get => numJumpGates; }
    public List<Planet> Planets { get => planets; }
    public List<JumpGate> JumpGates { get => jumpGates; }
    public Color Color { get => color; }

    private void Awake()
    {
        // spriteRenderer = GetComponent<SpriteRenderer>();
        planetCreator = (PlanetCreator)CreatorFactory.GetCreatorFor<Planet>();
        jumpGateCreator = (JumpGateCreator)CreatorFactory.GetCreatorFor<JumpGate>();
    }

    public void Init(Vector3 position, float zoomFactor, StarSettings settings, bool generateAll)
    {
        SetData(position, zoomFactor, settings);

        numPlanets = Mathf.Max(LehmerRNG.Next(-1, 10), 1);
        numJumpGates = LehmerRNG.Next(data.numJumpgates.min, data.numJumpgates.max);

        if (!generateAll) return;

        for (int p = 0; p < numPlanets; p++)
        {
            Planet newPlanet = planetCreator.Create(0, 0, zoomFactor, this.transform, generateAll);
            planets.Add(newPlanet);
        }


        for (int j = 0; j < numJumpGates; j++)
        {
            JumpGate newJumpGate = jumpGateCreator.Create(0, 0, zoomFactor, this.transform, generateAll);
            jumpGates.Add(newJumpGate);
        }
    }

    public void OnPointerClicked()
    {
        OnClicked?.Invoke(this, new OnStarClickEventArgs { star = this });
    }

    private void SetData(Vector3 position, float zoomFactor, StarSettings data)
    {
        float scaleXY = LehmerRNG.NextFloat(data.prefabScaleRange.min, data.prefabScaleRange.max);

        this.position = position;
        type = data.type;
        color = data.color;
        radius = LehmerRNG.NextDouble(data.radiusRange.min, data.radiusRange.max);
        age = LehmerRNG.NextDouble(data.ageRange.min, data.ageRange.max);
        temperature = LehmerRNG.NextDouble(data.tempRangeInK.min, data.tempRangeInK.max);
        luminosity = LehmerRNG.NextDouble(data.luminosityInMagnitude.min, data.luminosityInMagnitude.max);
        orbitalDistance = 0;

        name = $"Star_{LehmerRNG.Next(0, 5000)}";
        transform.position = this.position;
        transform.localScale = new Vector3(scaleXY, scaleXY);
        spriteRenderer.color = data.color;
    }

    public override string ToString() => name;
}