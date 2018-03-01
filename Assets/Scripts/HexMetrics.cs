using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMetrics : MonoBehaviour {

    public static float OuterRadius = .5f;
    public static float InnerRadius = OuterRadius * Mathf.Sqrt(3f) / 2f;

    public static Vector2[] Corners = {
        new Vector2(OuterRadius, 0f),
        new Vector2(.5f * OuterRadius, -InnerRadius),
        new Vector2(-.5f * OuterRadius, -InnerRadius),
        new Vector2(-OuterRadius, 0f),
        new Vector2(-.5f * OuterRadius, InnerRadius),
        new Vector2(.5f * OuterRadius, InnerRadius),
        new Vector2(OuterRadius, 0f)
    };

    public static Vector2[] ControlPoints(Vector2 center) {
        List<Vector2> points = new List<Vector2>();
        points.Add(center);
        for (int i = 0; i < 6; i++) {
            points.Add(center + Corners[i]);
            points.Add(center + Vector2.Lerp(Corners[i], Corners[i + 1], .5f));
            points.Add(center + (Corners[i] / 2f));
        }
        return points.ToArray();
    }
}
