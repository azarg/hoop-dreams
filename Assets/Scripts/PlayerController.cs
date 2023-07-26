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
    public IndicatorArrow indicatorArrow;

    private Camera mainCamera;
    private bool mouseClicked;
    private float mouseAngle;

    void Start()
    {
        currentBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        mainCamera = Camera.main;
        var pinPosition = mainCamera.WorldToScreenPoint(transform.position);
        indicatorArrow.Initialize(pinPosition);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseAngle = 90f - Vector2.Angle(indicatorArrow.transform.up, Vector2.right);
            mouseClicked = true;
        }
    }

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
        rb.AddForce(Quaternion.Euler(forceAngle,mouseAngle,0) * Vector3.forward * indicatorArrow.GetSize(), ForceMode.Impulse);
    }

    IEnumerator SpawnNextBall()
    {
        yield return new WaitForSeconds(spawnDelay);
        currentBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
    }
}
