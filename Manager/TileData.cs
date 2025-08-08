namespace OpenWarfare.Manager
{
    public class TileData
    {
        public short x { get; private set; }
        public short y { get; private set; }
        public bool IsOccupied { get; private set; }
        public bool IsBuildable { get; private set; }
        public Infrastructural.Infrastructure? occupancy;
        public bool entities_can_exist => occupancy?.Collidable ?? true;
        public Entity.IEntity? Entity;
        public byte ownedBy = 0; // 0 is international. 
        public Entity.AreaEffects[]? areaEffects; // Nullable; list of area effects on the tile.
        public TileData(short x, short y) // init TileData from position
        {
            this.x = x;
            this.y = y;
            IsOccupied = false;
            IsBuildable = true;
            occupancy = null;
        }
        public TileData(Vector<short> position) // init TileData from Vector data
        {
            x = position.x;
            y = position.y;
            IsOccupied = false;
            IsBuildable = true;
            occupancy = null;
        }
        public void Building(Infrastructural.Infrastructure infrastructure) // build building
        {
            if (IsOccupied)
            {
                throw new Error.GenericError("Tile is already occupied.");
            }
            IsOccupied = true;
            occupancy = infrastructure;
        }
        public Infrastructural.Infrastructure? Building() // retrieve building data
        {
            return occupancy;
        }
        public void RemoveBuilding() // Remove existing buildings on this tile
        {
            
        }
    }
}
