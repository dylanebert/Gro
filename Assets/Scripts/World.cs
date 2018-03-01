using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    static World world;
    public static World instance {
        get {
            return world;
        }
    }

    public HexGrid grid;

    [HideInInspector]
    public Dictionary<Vector2, Node> nodes;

    private void Awake() {
        world = this;
        nodes = new Dictionary<Vector2, Node>();
    }

    public void AddControlPoints(Vector2 center) {
        foreach(Vector2 point in HexMetrics.ControlPoints(center)) {
            if(!nodes.ContainsKey(point)) {
                nodes.Add(point, null);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        if (nodes != null) {
            foreach (Vector2 point in nodes.Keys) {
                Gizmos.DrawSphere(point, .02f);
            }
        }
    }
}
