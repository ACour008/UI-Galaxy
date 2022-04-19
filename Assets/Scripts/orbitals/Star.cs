using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Star : Orbital, IClickable
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject selectionIcon;

    private StarSettings data;
    private SystemType type;
    private Vector3 position;
    private Color color;
    private double luminosity;
    private Vector3 localScale;

    private int numPlanets, numJumpGates;
    private List<JumpGate> jumpGates = new List<JumpGate>();
    private List<Planet> planets = new List<Planet>();

    public event EventHandler OnClicked;

    private PlanetCreator planetCreator;
    private JumpGateCreator jumpGateCreator;

    private static Star Selected;

    public SystemType Type { get => type; }
    public int PlanetCount { get => numPlanets; }
    public int JumpGateCount { get => numJumpGates; }
    public List<Planet> Planets { get => planets; }
    public List<JumpGate> JumpGates { get => jumpGates; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        planetCreator = (PlanetCreator)CreatorFactory.GetCreatorFor<Planet>();
        jumpGateCreator = (JumpGateCreator)CreatorFactory.GetCreatorFor<JumpGate>();
    }

    public void Init(StarSettings settings, bool generateAll)
    {
        data = settings;
        float scaleXY = LehmerRNG.NextFloat(data.prefabScaleRange.min, data.prefabScaleRange.max);

        type = settings.type;
        color = settings.color;
        radius = LehmerRNG.NextDouble(data.radiusRange.min, data.radiusRange.max);
        age = LehmerRNG.NextDouble(data.ageRange.min, data.ageRange.max);
        temperature = LehmerRNG.NextDouble(data.tempRangeInK.min, data.tempRangeInK.max);
        luminosity = LehmerRNG.NextDouble(data.luminosityInMagnitude.min, data.luminosityInMagnitude.max);
        orbitalDistance = 0;
        name = $"Star_{LehmerRNG.Next(0, 5000)}";

    spriteRenderer.color = color;
        transform.localScale = new Vector3(scaleXY, scaleXY);

        numPlanets = Mathf.Max(LehmerRNG.Next(-1, 10), 1);
        numJumpGates = LehmerRNG.Next(data.numJumpgates.min, data.numJumpgates.max);

        if (!generateAll) return;

        for (int p = 0; p < numPlanets; p++)
        {
            Planet newPlanet = planetCreator.Create(0, 0, this.transform, generateAll);
            planets.Add(newPlanet);
        }


        for (int j = 0; j < numJumpGates; j++)
        {
            JumpGate newJumpGate = jumpGateCreator.Create(0, 0, this.transform, generateAll);
            jumpGates.Add(newJumpGate);
        }
    }

    public void OnPointerClicked()
    {
        Selected = this;

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        OnClicked?.Invoke(this, new OnStarClickEventArgs { star = this });
    }

    private void Update()
    {
        selectionIcon.SetActive(Selected == this);
    }
}