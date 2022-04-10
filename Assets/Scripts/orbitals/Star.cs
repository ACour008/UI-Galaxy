using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Star : Orbital, IPointerClickHandler
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private SystemType type;
    private Vector3 position;
    private Color color;
    private double luminosity;
    private Vector3 localScale;

    private List<JumpGate> jumpGates = new List<JumpGate>();
    private List<Planet> planets = new List<Planet>();

    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(StarSettings settings, bool generateAll)
    {
        StarSettings s = settings;
        float scaleXY = LehmerRNG.NextFloat(s.prefabScaleRange.min, s.prefabScaleRange.max);

        type = settings.type;
        color = settings.color;
        radius = LehmerRNG.NextDouble(s.radiusRange.min, s.radiusRange.max);
        age = LehmerRNG.NextDouble(s.ageRange.min, s.ageRange.max);
        temperature = LehmerRNG.NextDouble(s.tempRangeInK.min, s.tempRangeInK.max);
        luminosity = LehmerRNG.NextDouble(s.luminosityInMagnitude.min, s.luminosityInMagnitude.max);

        spriteRenderer.color = color;
        transform.localScale = new Vector3(scaleXY, scaleXY);

        if (!generateAll) return;

        int numPlanets = Mathf.Max(LehmerRNG.Next(-2, 10), 0);

        //temp
        for (int p = 0; p < numPlanets; p++)
        {
            planets.Add(new Planet());
        }

        int numJumpGates = LehmerRNG.Next(s.numJumpgates.min, s.numJumpgates.max);

        for (int j = 0; j < numPlanets; j++)
        {
            jumpGates.Add(new JumpGate());
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"SYSTEM INFO:\nType: {type}\nNo. of Planets: {planets.Count}\nNo. of Jump Gates: {jumpGates.Count}");
    }
}