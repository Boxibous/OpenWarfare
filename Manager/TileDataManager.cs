using System.Numerics;
using OpenWarfare;
using OpenWarfare.Manager;
namespace OpenWarfare.Manager
{
    public class TileDataManager
    {
        public World world { get; private set; }
        public Dictionary<Vector2, TileData> tiles;
        public TileData? GetTileAt(int x, int y)
        {
            Vector2 v = new Vector2(x, y);
            if (tiles.TryGetValue(v, out TileData? td))
            {
                return td;
            }
            throw new Exception();
        }
        public TileDataManager SetTileAt(int x, int y, TileData tile, bool? force) // unsafe forceful replacement of TileData, which overrides building in other words.
        {
            Vector2 v = new Vector2(x, y);
            if (tiles.TryGetValue(v, out TileData? td))
            {
                if (td is not null &&
                    td.occupancy?.Collidable is not true &&
                    td.Entity?.Collidable is not true &&
                    force is not true)
                {
                    throw new Exception("ahh");
                }
                tiles.GetValueOrDefault(v)?.Copy(tile);
            }
            return this;
        }
        public TileDataManager(World world)
        {
            this.world = world;
            tiles = new Dictionary<Vector2, TileData>();
        }
        public void tick()
        {
            
        }
    }
}