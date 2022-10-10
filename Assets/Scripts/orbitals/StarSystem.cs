using System;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem : Orbital
{
    private static int idAssigner = -1;
    
    [SerializeField] private SystemType type;
    private StarCreator starCreator;
    private SpriteRenderer spriteRenderer;
    private List<Star> stars;
    private List<JumpGate> jumpGates = new List<JumpGate>();
    [SerializeField] private int numJumpGates = 0;
    [SerializeField] private int maxJumpGates = 0;
    private int orbitalCount;
    private Government government;

    #region Fields
    public Vector3 Position { get => transform.position; set => transform.position = value; }
    public int OrbitalCount { get => orbitalCount;}
    public List<JumpGate> JumpGates { get => jumpGates; }
    public int JumpGateCount { get => numJumpGates; }
    public int MaxJumpGates { get => maxJumpGates; }
    public string Government {get => this.government.Name; }     // prob turn to actual object when fully implemented.
    public Color Color { get => CombineColors(); }
    public SystemType Type { get => this.type; }
    public double Age { get => age; }
    public int Id { get => id; }
    public override double Radius { get => solarRadius; }
    public override double Mass { get => solarMass; }
    public List<Star> Stars { get => stars; }
    #endregion

    public void Awake()
    {
        starCreator = (StarCreator)CreatorFactory.GetCreatorFor<Star>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    // turn back to private when testing is done.
    public Color CombineColors()
    {
        Color newColor = new Color();

        for (int i = 0; i < stars.Count; i++)
        {
            newColor = stars[i].Color;
        }

        newColor /= (int)type;
        newColor.a = 1;

        return newColor;
    }

    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }

    public override void Initialize(OrbitalSettings orbitalSettings, Orbital parent, Government government, string name, bool generateAll)
    {
        StarSystemSettings settings = orbitalSettings as StarSystemSettings;
        this.id = ++idAssigner;
        this.name = name;
        this.type = settings.type;
        this.age = LehmerRNG.NextDouble(settings.ageRange.min, settings.ageRange.max);
        this.government = government;

        if (!generateAll) return;

        stars = starCreator.CreateOrbitals(this, government, name, generateAll);

        float scale = DetermineScale();
        transform.localScale = new Vector3(scale, scale, 0);
        spriteRenderer.color = CombineColors();
    }

    private float DetermineScale()
    {
        float largestSystem = 0;

        for (int i = 0; i < stars.Count; i++)
        {
            largestSystem = (stars[i].Planets.Count > largestSystem) ? stars[i].Planets.Count : largestSystem;
        }

        return Mathf.Clamp(largestSystem / 10, 0.1f, 1f);
    }

    public void SetRadius(double radius)
    {
        solarRadius = radius;
    }
}
