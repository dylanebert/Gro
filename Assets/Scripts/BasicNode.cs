using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNode : Node {

    protected override void Start() {
        base.Start();
        StartCoroutine(Connect());
    }

    IEnumerator Connect() {
        List<Vector2> path = CalculatePath();
      
        for (int i = 0; i < path.Count - 1; i++) {
            GameObject connection = new GameObject("Connection");
            LineRenderer line = connection.AddComponent<LineRenderer>();
            line.material = lineMat;
            line.startWidth = line.endWidth = .01f;
            float t = 0f;
            while (t < 1f) {
                t += Time.deltaTime / 2f;
                line.SetPositions(new Vector3[] { path[i], Vector2.Lerp(path[i], path[i + 1], t) });
                yield return null;
            }
        }
    }    
}
