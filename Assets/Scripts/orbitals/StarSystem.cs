using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem : OrbitalBase, IOrbital, IClickable
{
    [SerializeField] private StarSystemType type;

    private StarCreator starCreator;
    private JumpGateCreator jumpGateCreator;
    private SpriteRenderer spriteRenderer;

    private List<Star> stars = new List<Star>();
    private List<JumpGate> jumpGates = new List<JumpGate>();
    private Dictionary<int, StarSystem> adjacencies = new Dictionary<int, StarSystem>();

    private float largestSystem = -1f;
    [SerializeField] private int numJumpGates = 0;
    [SerializeField] private int maxJumpGates = 0;

    public event EventHandler<OnStarSystemClickEventArgs> OnClicked;


    public Transform Transform { get => this.transform; }
    public Vector2 Position { get => transform.position; }
    public List<JumpGate> JumpGates { get => jumpGates; }
    public int NumberOfJumpGates { get => numJumpGates; }
    public int MaxJumpGates { get => maxJumpGates; }

    public Color Color { get => CombineColors(); }
    public StarSystemType Type { get => this.type; }
    public double Age { get => age; }
    public int Id { get => id; }
    public double Radius { get => radius; }

    public void Awake()
    {
        starCreator = (StarCreator)CreatorFactory.GetCreatorFor<Star>();
        jumpGateCreator = (JumpGateCreator)CreatorFactory.GetCreatorFor<JumpGate>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    public void AddJumpGateTo(StarSystem destination, bool ignoreLimit = false)
    {
        bool canAddJumpgate = numJumpGates < maxJumpGates;
        if (ignoreLimit)
        {
            canAddJumpgate = true;
            maxJumpGates++;
            destination.numJumpGates++;
        }

        if (canAddJumpgate)
        {
            JumpGate newJumpGate = jumpGateCreator.Create(id, 0, 0, this);
            newJumpGate.CreateConnection(this, destination);
            
            // both until we decide how to store the info.
            jumpGates.Add(newJumpGate);

            numJumpGates++;
            destination.numJumpGates++;
            return;
        }

        Debug.LogWarning("jumpGate Count exceeds maxJumpGates");

    }

    public bool AddToAdjacency(StarSystem destination)
    {
        if (!adjacencies.ContainsKey(destination.Id))
        {
            adjacencies.Add(destination.Id, destination);
            return true;
        }
        return false;
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

    public void CreateOrbitals(OrbitalSettings orbitalSettings, IOrbital parent, Dictionary<int, int> childrenProbabilities, bool generateAll)
    {
        // Do we need a radius for the star system??
        // What if we just base the icon size on how many orbitals it has??

        StarSystemSettings settings = orbitalSettings as StarSystemSettings;

        int i = 0;
        int starCount = 0;
        int starLimit = (int)type;
        maxJumpGates = GetNumberOfJumpgates(childrenProbabilities);
        int maxLimit = Mathf.Max(starLimit, maxJumpGates);

        while (i < maxLimit)
        {
            if (starCount < starLimit)
            {
                Star newStar = starCreator.Create(i, 0, 0, this, generateAll);
                // Size based on number of planets. Kinda like this one rn.
                if (newStar.Planets.Count > largestSystem) largestSystem = newStar.Planets.Count;
                
                // Size based on size of star
                // if (newStar.PrefabScale > largestSystem) largestSystem = newStar.PrefabScale * 10;

                stars.Add(newStar);
                starCount++;
            }

            i++;
        }

    }

    public int GetNumberOfJumpgates(Dictionary<int, int> chances)
    {
        int total = 0;
        
        // keep as foreach. The first key may not start at 0.
        foreach(KeyValuePair<int, int> pair in chances)
        {
            total += chances[pair.Key];
        }

        foreach(KeyValuePair<int, int> pair in chances)
        {
            int chance = chances[pair.Key];
            bool chanceSucceeds = LehmerRNG.Next(0, total) < chance;

            if (chanceSucceeds) return pair.Key;

            total -= chance;
        }

        // failsafe.
        return 1;
    }

    public bool HasConnectionTo(int starSystemId)
    {
        return adjacencies.ContainsKey(starSystemId);
    }

    public bool HasOpenSpacesForJumpgates()
    {
        return numJumpGates < maxJumpGates;
    }
    public void Initialize(int id, OrbitalSettings orbitalSettings, IOrbital parent, Dictionary<int, int> childrenProbabilities, bool generateAll)
    {
        StarSystemSettings settings = orbitalSettings as StarSystemSettings;
        this.id = id;
        this.name = $"StarSystem_{id}";
        this.type = settings.type;
        this.age = LehmerRNG.NextDouble(settings.ageRange.min, settings.ageRange.max);

        if (!generateAll) return;

        CreateOrbitals(settings, parent, childrenProbabilities, generateAll);

        float scale = Mathf.Clamp(largestSystem / 10, 0.1f, 1f);
        transform.localScale = new Vector3(scale, scale, 0);
        spriteRenderer.color = CombineColors();
    }

    public void OnPointerClicked()
    {
        OnClicked?.Invoke(this, new OnStarSystemClickEventArgs { system = this });
    }
}
