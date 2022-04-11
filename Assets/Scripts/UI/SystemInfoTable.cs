using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SystemInfoTable : MonoBehaviour
{
    // TODO: Create Pools for the Entries;

    [SerializeField] private Transform prefabParent;
    [SerializeField] private List<TableEntry> tableRows;

    public void Create(Star star)
    {
        Clear();

        int i = 0;
        tableRows[i++].SetRow(star.name, star.orbitalDistance);

        for (int p = 0; p < star.PlanetCount; p++)
        {
            Planet planet = star.Planets[p];
            tableRows[i].SetRow($"  {planet.name}", planet.OrbitalDistance);
            i++;
        }

        for (int j = 0; j < star.JumpGateCount; j++)
        {
            JumpGate jumpGate = star.JumpGates[j];
            tableRows[i].SetRow($"  {jumpGate.name}", jumpGate.OrbitalDistance);
        }
    }


    private void Clear()
    {
        foreach(TableEntry entry in tableRows)
        {
            entry.ClearAll();
        }
    }

}
