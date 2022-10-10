using UnityEngine;

public class StarPropertiesPanel : Panel
{
    [SerializeField] string panelID;
    [SerializeField] private SolarPropertiesComponent starProperties;

    public override string id { get => panelID; }

    public override void SetActive(bool active)
    {
        starProperties.gameObject.SetActive(active);
    }

    public override void Refresh(object payload = null)
    {
        if (payload == null) return;
        starProperties.SetData(payload as StarSystem);
    }
}
