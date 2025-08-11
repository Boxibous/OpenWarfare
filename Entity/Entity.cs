using System.Numerics;
using OpenWarfare.Event;

namespace OpenWarfare.Entity
{
    public class Entity
    {
        public delegate void EntityDelegate(Entity entity);
        public delegate void EntityDelegate2(Entity entity, Vector2 pos);
        public delegate void EntityDamageDelegate(Entity entity, float damage);

        public event EntityDelegate EntityDeathEvent = delegate { };
        public event EntityDamageDelegate EntityDamageEvent = delegate { };
        public event EntityDelegate2 EntityFactorizeEvent = delegate { };
        public event EntityDelegate2 EntityMoveEvent = delegate { };
        public event EntityDelegate2 EntityCreateEvent = delegate { };

        public Vector2 Pos { get { return new Vector2(x, y); } set { x = value.X; y = value.Y; } }
        public float x { get { return Pos.X; } set { Pos = new Vector2(value, Pos.Y); } }
        public float y { get { return Pos.Y; } set { Pos = new Vector2(Pos.X, value); } }
        public Vector2 movement = Vector2.Zero;
        public float Health;
        public float MaxHealth;
        public bool Vulnerable;
        public bool IsAlive;
        public bool Collidable;
        public bool Flying;
        public virtual Entity Damage(float dmg)
        {
            Health -= dmg;
            if (dmg > 0)
            {
                EntityDamageEvent.Invoke(this, dmg);
            }
            if (Health <= 0)
            {
                onDeath();
            }
            return this;
        }
        public virtual Action tick { private set; get; } = () => { };
        public virtual void onDeath()
        {
            List<object> args = [this];
            EntityDeathEvent.Invoke(this);
            IsAlive = false;
        }
        public Entity()
        { 
            
        }
    }
}