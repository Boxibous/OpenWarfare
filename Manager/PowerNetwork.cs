using System.Runtime.CompilerServices;

namespace OpenWarfare.Manager
{
    public class PowerNetwork
    {
        public List<Infrastructural.Consumer> consumer = new List<Infrastructural.Consumer>();

        public void add(Infrastructural.Consumer c)
        {
            consumer.Add(c);
        }
        public void remove(Infrastructural.Consumer c)
        {
            consumer.RemoveAt(consumer.IndexOf(c));
        }
        public void tick()
        {
            foreach (var c in consumer)
            {
                c.tick();
            }
        }
    }
}