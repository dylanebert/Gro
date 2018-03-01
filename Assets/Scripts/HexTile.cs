using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour {

    public Node nodeObj;

    [HideInInspector]
    public List<Node> nodes;
    [HideInInspector]
    public bool live;

    public void Initialize() {
        World.instance.AddControlPoints(transform.position);
    }

    public void AddNodes(List<Vector2> positions) {
        foreach (Vector2 pos in positions) {
            Node node = Instantiate(nodeObj, transform);
            node.transform.localPosition = pos;
            nodes.Add(node);
        }
        live = true;
    }
}
