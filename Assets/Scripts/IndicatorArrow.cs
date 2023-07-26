using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorArrow : MonoBehaviour
{
    [SerializeField] private float indicatorOffsetY;
    [SerializeField] private RectTransform baseRect;
    [SerializeField] private float maxIndicatorSize;

    void Update()
    {
        Vector2 clippedMousePos = new Vector2(Input.mousePosition.x, Mathf.Min(transform.position.y - indicatorOffsetY, Input.mousePosition.y));
        Vector2 diffToMouse = (Vector2)transform.position - clippedMousePos;

        transform.up = diffToMouse;
        var clampledSize = Mathf.Min(diffToMouse.magnitude, maxIndicatorSize);
        baseRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, clampledSize);
        baseRect.localPosition = new Vector3(0, -baseRect.rect.height /2 - indicatorOffsetY, 0);
    }

    public float GetSize()
    {
        return baseRect.rect.height / 10;
    }
    public void Initialize(Vector2 position)
    {
        transform.position = position;
    }
}
