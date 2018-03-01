using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Node : MonoBehaviour {

    public Material lineMat;

    protected List<Node> adjacent;

    protected virtual void Start() {
        adjacent = new List<Node>();
        World.instance.nodes[transform.position] = this;
    }

    protected List<Vector2> CalculatePath() {
        List<Vector2> path = new List<Vector2>();
        Vector2 target = transform.position;
        Vector2 pos = FindNearest();
        path.Add(pos);
        while(pos != target) {
            bool found = false;
            foreach(Vector2 next in HexMetrics.Corners) {
                if(World.instance.nodes.ContainsKey(pos + next) && ((pos + next) - target).sqrMagnitude < (pos - target).sqrMagnitude) {
                    pos += next;
                    found = true;
                    break;
                }
            }
            if (!found)
                pos = target;
            path.Add(pos);
        }
        foreach (Vector2 p in path)
            Debug.Log(p);
        return path;
    }

    protected Vector2 FindNearest() {
        float minDist = float.MaxValue;
        Vector2 nearest = Core.instance.transform.position;
        foreach (Node node in World.instance.nodes.Values) {
            if (node != null && node != this) {
                float dist = (node.transform.position - transform.position).sqrMagnitude;
                if (dist < minDist) {
                    minDist = dist;
                    nearest = node.transform.position;
                }
            }
        }
        return nearest;
    }
}
