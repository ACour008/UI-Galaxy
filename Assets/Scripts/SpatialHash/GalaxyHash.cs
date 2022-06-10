using System;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyHash
{
    private int width;
    private int height;
    private int cellSize;
    private int count;
    private Dictionary<string, List<StarSystem>> grid;
    private Dictionary<int, Vector3> systemReference;

    public int Count { get => count; }
    public Dictionary<string, List<StarSystem>> Grid { get => grid; }
    public int Height { get => height; }
    public int Width { get => width; }


    public GalaxyHash(int width, int height, int cellSize)
    {
        grid = new Dictionary<string, List<StarSystem>>();
        systemReference = new Dictionary<int, Vector3>();

        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
    }

    public void Add(StarSystem star)
    {
        string key = Hash(star.Position);

        if (!grid.ContainsKey(key))
        {
            grid[key] = new List<StarSystem>();
            systemReference.Add(star.Id, star.Position);
        }

        grid[key].Add(star);
        count++;
    }

    public List<StarSystem> GetCellAt(Vector3 position)
    {
        string key = Hash(position);
        if (!grid.ContainsKey(key))
        {
            return null;
        }

        return grid[key];
    }

    public List<StarSystem> GetCellAtCoordinate(int x, int y)
    {
        return GetCellAt(new Vector3(x, y, 0));
    }

    public (int x, int y) GetCellCoordinates(Vector3 position)
    {
        string key = Hash(position);
        if (!grid.ContainsKey(key))
        {
            throw new KeyNotFoundException($"No Cell at: Cell {key}");
        }

        string[] coordinateStrings = key.Split(',');
        return (int.Parse(coordinateStrings[0]), int.Parse(coordinateStrings[1]));
    }

    public int GetCellCountAt(Vector3 position)
    {
        string key = Hash(position);
        if (!grid.ContainsKey(key))
        {
            throw new KeyNotFoundException($"No Cell at: Cell {key}");
        }

        return grid[key].Count;
    }

    public StarSystem GetClosestInCell(Vector3 position, float minDistance)
    {
        List<StarSystem> cell = GetCellAt(position);
        Vector2 pos = new Vector2(position.x, position.y);

        cell.Sort((ss1, ss2) => Mathf.FloorToInt(Vector3.Distance(ss1.Position, position)).CompareTo(Mathf.FloorToInt(Vector3.Distance(ss2.Position, position))));

        for (int i = 1; i < cell.Count; i++)
        {
            if (Vector3.Distance(cell[i].Position, position) > minDistance)
            {
                return cell[i];
            }
        }

        Debug.LogWarning($"System at {pos} not found in grid cell [{Hash(position)}].");
        return null;
    }

    public StarSystem GetSystemById(int id)
    {
        List<StarSystem> cell = GetCellAt(systemReference[id]);
        
        for (int i = 0; i < cell.Count; i++)
        {
            if (cell[i].Id == id) return cell[i];
        }
        return null;
    }

    public bool StarSystemExistsInPosition(Vector3 position)
    {
        List<StarSystem> cell = GetCellAt(position);

        if (cell == null) return false;

        for (int i = 0; i < cell.Count; i++)
        {
            if (cell[i].Position == position) return true;
        }
        return false;
    }

    private string Hash(Vector3 point)
    {
        int x = Mathf.RoundToInt(point.x / cellSize) * cellSize;
        int y = Mathf.RoundToInt(point.y / cellSize) * cellSize;

        return $"{x},{y}";
    }

}
