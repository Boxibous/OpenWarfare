using System.Runtime.CompilerServices;

namespace OpenWarfare.Event
{
    public class Event
    {
        private protected List<Action<List<object>?>> listeners;
        public Event()
        {
            listeners = [];
        }
        public void Invoke(List<object>? args)
        {
            foreach (var listener in listeners)
            {
                if (args is null)
                {
                    listener.Invoke(null);
                    return;
                }
                listener.Invoke(args);
            }
        }
        public void Revoke(Action<List<object>?> listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
        public void Listen(Action<List<object>?> listener)
        {
            listeners.Add(listener);
        }
    };
    public class Events
    {
        // public static Event EntityMoveEvent = new Event();
        // public static Event EntityCreateEvent = new Event();
        // public static Event EntityFactorizeEvent = new Event();
        // public static Event EntityDamageEvent = new Event();
        // public static Event EntityDeathEvent = new Event();
        public static Event PlayerJoinEvent = new Event();
        // public static Event PlayerLeaveEvent = new Event();
        public static Event PlayerDeathEvent = new Event();
        // public static Event ConstructionConstructEvent = new Event();
        // public static Event ConstructionDeconstructEvent = new Event();
        // public static Event ServerConnectionEvent = new Event(); // Use PlayerJoinEvent instead. This is meant to be PreJoin
        // public static Event ServerDisconnectionEvent = new Event(); // Use PlayerLeaveEvent instead
        // public static Event InfrastructureDamageEvent = new Event();
        // public static Event InfrastructureConstructionCompleteEvent = new Event();
        // public static Event InfrastructureDeconstructEvent = new Event();
    }
}
