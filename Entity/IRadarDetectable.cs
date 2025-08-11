namespace OpenWarfare.Entity
{
    public enum RadarFlags
    {
        ONE_METER,
        TWO_METER,
        TWENTY_CENTIMETER,
        INFRARED,
        LASER
    }
    public interface IRadarDetectable
    {
        RadarFlags[] Undetectables { get; }
        bool EmitsRadiation { get; } // Used for semi-active radars.
        bool IsTargetable { get; } // Used for vehicles that are capable of deploying countermeasures.
        bool EmitsHeatRadiation { get; } // Used for infrared targeting missiles.

    }
}