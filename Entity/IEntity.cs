namespace OpenWarfare.Entity
{
    public abstract class Entity
    {
        public float x;
        public float y;
        public float Health;
        public float MaxHealth;
        public bool Vulnerable;
        public bool IsAlive;
        public bool Collidable;
        public bool Flying;
        public void tick() { }
        public virtual void onDeath()
        {
            List<object> args = new List<object>();
            args.Add(this);
            Event.Events.PlayerDeathEvent.Invoke(args);
            IsAlive = false;
        }
    }
}