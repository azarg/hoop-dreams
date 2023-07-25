using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    private GameObject currentBall;
    [SerializeField] private float force;
    [SerializeField] private float forceAngle;
    private bool mouseClicked;

    // Start is called before the first frame update
    void Start()
    {
        currentBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseClicked = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(mouseClicked)
        {
            if (currentBall != null)
            {
                var rb = currentBall.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.AddForce(Quaternion.Euler(forceAngle, 0, 0) * Vector3.forward * force, ForceMode.Impulse);
                mouseClicked = false;
                currentBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
