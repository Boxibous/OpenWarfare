/*
 * Electrical, resource,... consumer representation.
 */
namespace OpenWarfare.Infrastructural
{
    public class Consumer : Infrastructure
    {
        public Consumer(string name, string desc, string displayName) : base(name, desc, displayName) { }
        public Consumer(string name, string desc, string displayName, OpenWarfare.Infrastructural.Category category) : base(name, desc, displayName, category) { }
        public Consumer(string name, string desc, string displayName, OpenWarfare.Infrastructural.Category category, int lifetime) : base(name, desc, displayName, category, lifetime) { }
        public int currConsumption = 0;
        public int maxConsumption = 0;
        public override void tick()
        {
            base.tick();
        }
        public void OnPlacement(Manager.PowerNetwork nw)
        {
            nw.add(this);
        }
        public void onRemoval(Manager.PowerNetwork nw)
        {
            nw.remove(this);
        }
    }
}