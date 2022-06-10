using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DelaunatorSharp;

public class JumpgatePathGenerator
{
    private Galaxy galaxy;
    private Delaunator delaunator;
    bool initialized = false;

    public Int32[] Paths { get => GetPaths(); }

    public JumpgatePathGenerator(Galaxy galaxy)
    {
        this.galaxy = galaxy;
        Initialize();
    }

    private Int32[] GetPaths()
    {
        if (!initialized) Initialize();
        return delaunator.Triangles;
    }

    public void Initialize()
    {
        /*List<IPoint> points = new List<IPoint>();

        foreach(var pair in galaxy.StarSystems.Grid)
        {
            List<StarSystem> list = pair.Value;
            for (int i = 0; i < list.Count; i++)
            {
                points.Add(list[i]);
            }
        }

        delaunator = new Delaunator(points.ToArray());
        initialized = true;*/
    }
}
