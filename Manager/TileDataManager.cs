using OpenWarfare;
using OpenWarfare.Manager;
namespace OpenWarfare.Manager
{
    public class TileDataManager
    {
        public World world;
        public TileData[,] tiles;
        public TileData? GetTileAt(int x, int y)
        {
            if (tiles[x, y] == null)
            {
                return null;
            }
            return tiles[x, y];
        }
        public TileDataManager SetTileAt(int x, int y, TileData tile) // unsafe forceful replacement of TileData, which overrides building in other words.
        {
            if (tile.x != x || tile.y != y)
            {
                throw new ArgumentException();
            }
            tiles[x, y] = tile;
            return this;
        }
        public TileDataManager Build(int x, int y, Infrastructural.Infrastructure infrastructure) // SetTileAt replacement, much safer
        {
            if (tiles[x, y] != null)
            {
                throw new Exception("Build(...) called when building ALREADY exist. Call SetTileAt(...) instead!");
            }
            if (tiles[x, y] == null)
            {
                tiles[x, y] = new TileData((short)x, (short)y);
            }
            tiles[x, y].Building(infrastructure);
            return this;
        }
        public TileDataManager(World world)
        {
            this.world = world;
            tiles = new TileData[world.width, world.height];
        }
        public void tick()
        {
            foreach (TileData tile in tiles)
            {
                if (tile != null && tile.IsOccupied && tile.occupancy != null)
                {
                    tile.occupancy.tick();
                }
            }
        }
    }
}