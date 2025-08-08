namespace OpenWarfare.Manager
{
    public class World
    {

        public List<PowerNetwork>? PowerNetworks;
        public TileDataManager TileDataManager;
        public WorldEntityManager EntityManager;
        
        public short width;
        public short height;
        public World(short width, short height)
        {
            TileDataManager = new TileDataManager(this);
            EntityManager = new WorldEntityManager(this);
            this.width = width;
            this.height = height;
        }
        public World(short width, short height, TileDataManager tileDataManager)
        {
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
    }
}