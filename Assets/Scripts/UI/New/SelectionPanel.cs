using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPanel : Panel
{
    [SerializeField] string panelId;
    [SerializeField] SelectionComponent data;

    public override string id { get => panelId; }

    public override void Refresh(object payload = null)
    {
        if (payload == null) return;

        StarSystem starSystem = payload as StarSystem;
        gameObject.transform.position = starSystem.Position;
        data.SetData(starSystem);

    }

    public override void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
