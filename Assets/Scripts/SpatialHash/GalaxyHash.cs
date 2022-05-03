using System;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyHash
{
    private int width;
    private int height;
    private int cellSize;
    private Dictionary<string, List<Star>> grid;
    
    public GalaxyHash(int width, int height, int cellSize)
    {
        grid = new Dictionary<string, List<Star>>();
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

    }

    public void Add(Star star)
    {
        string key = Hash(star.Position);

        if (!grid.ContainsKey(key))
        {
            grid[key] = new List<Star>();
        }
        grid[key].Add(star);
    }

    public List<Star> GetSharedBucketAs(Star star)
    {
        string key = Hash(star.Position);
        if (!grid.ContainsKey(key))
        {
            return null;
        }

        return grid[key];
    }

    private string Hash(Vector3 point)
    {
        int x = Mathf.RoundToInt(point.x / cellSize) * cellSize;
        int y = Mathf.RoundToInt(point.y / cellSize) * cellSize;

        return $"{x},{y}";
    }

}
