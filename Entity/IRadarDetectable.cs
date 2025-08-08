namespace OpenWarfare.Entity
{
    public interface IRadarDetectable
    {
        RadarFlags Undetectables { get; }
        bool EmitsRadiation { get; } // Used for semi-active radars.
        bool IsTargetable { get; } // Used for vehicles that are capable of deploying countermeasures.
        bool EmitsHeatRadiation { get; } // Used for infrared targeting missiles.
        
    }
}