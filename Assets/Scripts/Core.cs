using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : Node {

    static Core core;
    public static Core instance {
        get {
            return core;
        }
    }

    private void Awake() {
        core = this;
    }

    protected override void Start() {
        base.Start();
        StartCoroutine(ContinuousGrow());
    }

    IEnumerator ContinuousGrow() {
        while(true) {
            Grow();
            yield return new WaitForSeconds(5f);
        }
    }

    void Grow() {
        foreach(Coords coords in World.instance.grid.tiles.Keys) {
            HexTile tile = World.instance.grid.tiles[coords];
            if (!tile.live) {
                tile.AddNodes(new List<Vector2>() { HexMetrics.Corners[0] / 2f });
                break;
            }
        }
    }
}
