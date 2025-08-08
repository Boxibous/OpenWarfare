namespace OpenWarfare.Manager
{
    public class WorldEntityManager
    {
        // Add methods and properties to manage world entities
        // Here's List<T> of IEntity
        public List<Entity.IEntity> entities;
        public World world;
        public WorldEntityManager(World w)
        {
            this.entities = new List<Entity.IEntity>();
            this.world = w;
        }
        public void tick()
        {
            foreach (Entity.IEntity entity in entities)
            {
                entity.tick();
            }
        }
    }
}