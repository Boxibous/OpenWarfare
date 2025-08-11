using System.Numerics;
using OpenWarfare.Event;
using OpenWarfare.Manager;

namespace OpenWarfare
{
    public class Player
    {
        public Team Team { get; private set; }
        public string Name;
        public bool IsAlive;
        public float Health;
        public Vector2 Pos;
        public Vector2 Movement;
        public World world { get; }

        public Player(World world, Team team, Vector2 pos, string name)
        {
            Team = team;
            this.world = world;
            Pos = pos;
            IsAlive = true;
            Movement = new Vector2(0, 0);
            Name = name;
        }
        public Player Damage(float dmg)
        {
            Health -= dmg;
            if (Health <= 0)
            {
                List<object> args = [this];
                Events.PlayerDeathEvent.Invoke(args);
            }
            return this;
        }
        public Team GetTeam()
        {
            return Team;
        }
        public Player SetTeam(Team t)
        {
            Team = t;
            return this;
        }
        public Player SetPos(Vector2 pos)
        {
            Pos = pos;
            return this;
        }
    }
}