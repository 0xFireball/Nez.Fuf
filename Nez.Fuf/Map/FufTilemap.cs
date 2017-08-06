using System;
using Nez.Tiled;

namespace Nez.Fuf.Map
{
    public class FufTilemap : TiledMap
    {
        public FufTilemap(
            int firstGid,
            int width,
            int height,
            int tileWidth,
            int tileHeight,
            TiledMapOrientation orientation = TiledMapOrientation.Orthogonal) : base(
                firstGid,
                width,
                height,
                tileWidth,
                tileHeight
            )
        {
        }
    }
}
