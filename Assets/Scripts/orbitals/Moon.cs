public class Moon : Orbital
{
    public override double Radius { get => solarRadius * Utils.Conversions.RO_EARTH; }
    public override double Mass { get => solarMass * Utils.Conversions.MO_EARTH; }

    public override void Initialize(OrbitalSettings setting, Orbital parent, Government government, string name, bool generateAll)
    {

    }
}
