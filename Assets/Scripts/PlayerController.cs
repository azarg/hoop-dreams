using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    private GameObject currentBall;
    [SerializeField] private float force;
    [SerializeField] private float forceAngle;
    [SerializeField] private float spawnDelay;

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
            mouseClicked = false;
            if (currentBall != null)
            {
                Kick(currentBall);

                // set to null so that further mouse clicks do not kick the same ball
                currentBall = null;
                StartCoroutine(SpawnNextBall());
            }
        }
    }

    private void Kick(GameObject ball)
    {
        var rb = ball.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(Quaternion.Euler(forceAngle, 0, 0) * Vector3.forward * force, ForceMode.Impulse);
    }

    IEnumerator SpawnNextBall()
    {
        yield return new WaitForSeconds(spawnDelay);
        currentBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
    }
}
