using System.Numerics;
using OpenWarfare.Entity;
using OpenWarfare.Event;

namespace OpenWarfare.Manager
{
    public class World
    {

        public List<PowerNetwork>? PowerNetworks;
        public TileDataManager TileDataManager;
        public WorldEntityManager EntityManager;
        public Player[] players;

        public short width;
        public short height;
        public World(short width, short height)
        {
            TileDataManager = new TileDataManager(this);
            EntityManager = new WorldEntityManager(this);
            players = [];
            this.width = width;
            this.height = height;
        }
        public World(short width, short height, TileDataManager tileDataManager)
        {
            players = [];
            EntityManager = new WorldEntityManager(this);
            this.width = width;
            this.height = height;
            this.TileDataManager = tileDataManager;
        }
        public void tick()
        {
            TileDataManager.tick();
            EntityManager.tick();
        }
        // Causes explosion in square radius.
        public void Explosion(byte intensity, byte radius, Vector2 pos)
        {
            int realDMG = (int)(10 * intensity * (radius / 2.5)); // Yes, radius affects intensity.

        }
        public void SpawnPlayer(Player p)
        {

            players.Append(p);
            var args = new List<object>();
            args.Add(p);
            Event.Events.PlayerJoinEvent.Invoke(args);
        }
        public void SpawnPlayer(Player p, Vector2 pos, Team team)
        {
            players.Append(p
                .SetTeam(team)
                .SetPos(pos));
        }
        public void SpawnBullet(Entity.Entity e, Bullet b)
        {
            // new Bullet(e.Pos, [0,0], )
        }
    }
}