/* Item representation.
 * This file is part of the OpenWarfare project.
 */
using OpenWarfare.Infrastructural;
namespace OpenWarfare.Infrastructural
{
    public abstract class Infrastructure
    {
        public Infrastructure(string name, string desc, string displayName)
        {
            this.Name = name;
            this.Desc = desc;
            this.DisplayName = displayName;

        }
        public Infrastructure(string name, string desc, string displayName, Infrastructural.Category category)
        {
            this.Name = name;
            this.Desc = desc;
            this.DisplayName = displayName;
            this.Category = category;
        }
        public Infrastructure(string name, string desc, string displayName, Infrastructural.Category category, int lifetime)
        {
            this.Name = name;
            this.Desc = desc;
            this.DisplayName = displayName;
            this.Category = category;
            this.Lifetime = lifetime;
        }
        public string Name;
        public string Desc;
        public string DisplayName;
        private int Lifetime;
        private int TickCount;
        public int MaintenanceCost; // Maintenance cost per quarter (450 game ticks / 30 = 15 seconds)
        public bool Collidable;
        public virtual void tick()
        {
            TickCount++;
        }
        public void onPlacement() { }
        public void onRemoval() { }
        public Infrastructural.Category Category;
        public int CurrentHealth;
        public int MaxHealth;
     }
}
