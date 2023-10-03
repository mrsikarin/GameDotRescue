using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Obstacle rotatingObject;
    private bool rotateClockwise;
    private float rotationDirection;
    private Rigidbody2D rb;
    public GameController gameController;
    public GameObject DeathEffect;
    public Transform pos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        // หมุนผู้เล่นตามความเร็วของ RotatingObject
        if (Input.GetMouseButtonDown(0))
        {
            rotateClockwise = !rotateClockwise;
        }
        rotationDirection = rotateClockwise ? 1f : -1f;
        float rotationSpeed = rotatingObject.GetCurrentRotationSpeed();
        rb.transform.Rotate(Vector3.forward, rotationSpeed * rotationDirection * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Obstacle obstacle = other.collider.GetComponent<Obstacle>();
        if(obstacle != null)
        {
            onDeath();
            Instantiate(DeathEffect,pos.transform.position,Quaternion.identity);
        }
    }
    public void onDeath()
    {
        gameController.GameEnd();
        Destroy(gameObject);
    }
}
