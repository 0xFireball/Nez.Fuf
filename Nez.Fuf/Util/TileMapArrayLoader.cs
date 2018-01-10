using System.Linq;
using Nez.Tiled;

namespace Nez.Fuf.Util {
    public class TileMapArrayLoader {
        public TiledLayer loadLayerFromArray(TiledMap map, string layerName, int[] tileData, int width, int height,
            TiledTileset tileset,
            int tileWidth,
            int tileHeight) {
            var tiles = tileData.Select(x => new TiledTile(x) {tileset = tileset}).ToArray();
            var tileLayer = map.createTileLayer(layerName, width, height, tiles);

            return tileLayer;
        }
    }
}