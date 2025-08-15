namespace OpenWarfare.Entity
{
    public class FlakInfo
    {
        public List<Bullet> Bullets;
        public Entity Origin;
        public FlakInfo(Entity origin, Bullet[]? bullets)
        {
            Origin = origin;
            foreach (var bullet in bullets) {
                
            }
        }
        public FlakInfo Add(Bullet bullet)
        {
            bool b = Bullets.Add(bullet);
            if (b is not false)
            {
                return this;
            }
            return this;
        }
        public bool IfExists(Bullet bullet)
        {
            return Bullets.Contains(bullet);
        }
        public FlakInfo? Remove(Bullet bullet)
        {
            int idx = Array.IndexOf(Bullets, bullet);
            if (idx != -1)
            {
                var list = Bullets.ToList();
                list.RemoveAt(idx);
                Bullets = list.ToArray();
                return this;
            }
            return null;
        }
    }
}