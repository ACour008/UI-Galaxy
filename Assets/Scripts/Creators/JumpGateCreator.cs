using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGateCreator : Creator, ICreator<JumpGateData, JumpGate>
{
    public JumpGateCreator(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public JumpGate Create(int id, float x, float y, IOrbital parent, bool generateAll = false)
    {
        JumpGateData data = dataManager.GetData<JumpGateData>();

        GameObject gameObject = GameObject.Instantiate<GameObject>(data.Settings[0].prefab, parent.Transform);
        JumpGate jumpGate = gameObject.GetComponent<JumpGate>();
        gameObject.SetActive(false);

        return jumpGate;
    }
}
