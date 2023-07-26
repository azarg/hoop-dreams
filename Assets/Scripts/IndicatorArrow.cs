using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class IndicatorArrow : MonoBehaviour
{
    [SerializeField] private float indicatorOffsetY = 50;
    [SerializeField] private RectTransform baseRect;
    [SerializeField] private float maxIndicatorSize = 200;
    [SerializeField] private float size_to_force_ratio = 0.1f;
    private Vector3 origin;

    void Update()
    {
        // Origin is where the player (ball) is.
        // Ideally the transform position should only be set once (in Start() for example),
        // since this position will not change during the gameplay,
        // however, that did not seem to work in published WebGL version
        transform.position = origin;

        // Limit how far the indicator arrow can go up.
        // We want it to say below the origin (which is where it points) by the some offset value.
        float max_Y = Mathf.Min(origin.y - indicatorOffsetY, Input.mousePosition.y);

        // Find the vector pointing from clamped mouse position to the origin.
        Vector2 clampedMousePos = new Vector2(Input.mousePosition.x, max_Y);
        Vector2 fromMouseToOrigin = (Vector2)origin - clampedMousePos;
        
        // The effect of this is to rotate the indicator arrow to point towars the origin.
        transform.up = fromMouseToOrigin;

        // Resize the indicator arrow to match the distance from mouse position to origin.
        var clampledSize = Mathf.Min(fromMouseToOrigin.magnitude, maxIndicatorSize);
        baseRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, clampledSize);
    }

    public float GetForce()
    {
        return baseRect.rect.height * size_to_force_ratio;
    }

    public void SetOrigin(Vector2 p)
    {
        origin = p;
    }
}
