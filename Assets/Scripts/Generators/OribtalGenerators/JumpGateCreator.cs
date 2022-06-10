using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGateCreator : Creator<JumpGate>
{
    public JumpGateCreator(DataManager dataManager):base(dataManager)
    {
    }

    public JumpGate Create(int id, float x, float y, Transform parent, bool generateAll = false)
    {
        JumpGateData data = dataManager.GetData<JumpGateData>();

        GameObject gameObject = GameObject.Instantiate<GameObject>(data.Settings[0].prefab, parent);
        JumpGate jumpGate = gameObject.GetComponent<JumpGate>();
        gameObject.SetActive(false);

        return jumpGate;
    }
}
