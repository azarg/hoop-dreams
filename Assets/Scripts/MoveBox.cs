using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector3 direction = Vector3.left;
    [SerializeField] float bounds;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        if (transform.position.x > bounds || transform.position.x < -bounds)
            direction *= -1;
    }
}
