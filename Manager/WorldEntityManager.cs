namespace OpenWarfare.Manager
{
    public class WorldEntityManager
    {
        // Add methods and properties to manage world entities
        // Here's List<T> of IEntity
        public List<Entity.Entity> entities;
        public World world;
        public WorldEntityManager(World w)
        {
            this.entities = new List<Entity.Entity>();
            this.world = w;
        }
        public void tick()
        {
            foreach (Entity.Entity entity in entities)
            {
                entity.tick();
            }
        }
    }
}