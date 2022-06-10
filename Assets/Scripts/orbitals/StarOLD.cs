using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarOLD
{
    // Do i put localScaleRange in here too?? It is a property for the component
    // Position and color are in here. Why not scale?
    // Because we are gonna move position and color out of Star.

 /*   private bool _shouldExist;
    private bool _generateAll;
    private Vector3 position;
    private SystemType type;
    private Color color;
    private double luminosity;

    private List<JumpGate> jumpGates = new List<JumpGate>();
    private List<Planet> planets = new List<Planet>();

    public Vector3 Position { get => position; }
    public SystemType Type { get => this.type; }
    public Color Color { get => this.color; }
    public double Size { get => this.radius; }
    public double JumpGateCount { get => jumpGates.Count; }
    public double PlanetCount { get => planets.Count; }


    public bool ShouldExist { get => _shouldExist; }

    public StarOLD(float x, float y, bool generateAll = false)
    {
        position = new Vector3(x, y);
        _shouldExist = (int)LehmerRNG.Next(0, 21) == 1;
        _generateAll = generateAll;

        if (!_shouldExist) return;
        SetData();
    }

    private void SetData()
    {
        StarData data = DataManager.GetData<StarData>();

        float total = 0;

        foreach(StarSettings info in data.Settings)
        {
            total += info.chanceOfSpawn;
        }

        foreach(StarSettings info in data.Settings)
        {
            float chance = info.chanceOfSpawn;
            bool something = LehmerRNG.NextDouble(0f, 1f) < chance;

            if (something)
            {
                this.type = info.type;
                this.color = info.color;
                this.radius = LehmerRNG.NextDouble(info.radiusRange.min, info.radiusRange.max);

                if (!_generateAll) return;
                
                // Move to Creator class;
                int numJumpgates = LehmerRNG.Next(info.numJumpgates.min, info.numJumpgates.max);

                for (int i = 0; i < numJumpgates; i++)
                {
                    // figure out connections to nearby neighbors after implementation of spatial hashing.
                    jumpGates.Add(new JumpGate());
                }


                // Move to Creator class
                int numPlanets = Mathf.Max(LehmerRNG.Next(-1, 10), 0);
                for (int j = 0; j < numPlanets; j++)
                {
                    planets.Add(new Planet());
                }
            }
            else
            {
                total -= chance;
            }
        }
    }*/
}
