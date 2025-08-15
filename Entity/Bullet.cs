using System.Numerics;
using OpenWarfare.Entity;
namespace OpenWarfare.Entity
{
    public class Bullet : Entity
    {
        public delegate void BulletDelegate(Entity? origin, Bullet bullet);

        public event BulletDelegate BulletSpawnEvent = delegate { };

        public Bullet(Vector2 pos, Vector2 movement, float damage, int range)
        {
            BulletSpawnEvent.Invoke(null, this);
        }
        public Bullet(Entity origin, Vector2 pos, Vector2 movement, float damage, int range)
        {
            BulletSpawnEvent.Invoke(origin, this);
        }

        public float damage;
        public new readonly bool Vulnerable = false;
        public FlakInfo? flak;
    }
}
