using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour {

    public int height = 6;
    public int width = 6;

    public HexTile hexCellObj;

    [HideInInspector]
    public Dictionary<Coords, HexTile> tiles;

    private void Awake() {
        tiles = new Dictionary<Coords, HexTile>();

        for(int y = 0; y < height; y++) {
            for(int x = 0; x < width; x++) {
                HexTile tile = Instantiate(hexCellObj, transform);
                tile.name = x + ", " + y;
                tile.transform.localPosition = new Vector2(x * HexMetrics.OuterRadius * 1.5f, (y + x * .5f - x / 2) * HexMetrics.InnerRadius * 2f);
                tile.Initialize();
                tiles.Add(new Coords(x, y), tile);
            }
        }
    }
}

public class Coords {
    public int x;
    public int y;

    public Coords(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object obj) {
        if(obj is Coords) {
            Coords coords = (Coords)obj;
            if (coords.x == x && coords.y == y)
                return true;
        }
        return false;
    }

    public override int GetHashCode() {
        return x.GetHashCode() ^ y.GetHashCode();
    }
}