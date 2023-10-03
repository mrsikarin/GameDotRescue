using UnityEngine;

public class Obstacle : MonoBehaviour
{
     public float minRotationSpeed = 30f;
    public float maxRotationSpeed = 90f;
    public float minNextTime = 1f;
    public float maxNextTime = 5f;

    private float currentRotationSpeed;
    private float nextTime;
    private bool rotateClockwise;

    private void Start()
    {
        SetRandomRotationSpeed();
        SetRandomNextTime();
        rotateClockwise = Random.Range(0, 2) == 0; // สุ่มหมุนทางซ้ายหรือขวา
    }

    private void Update()
    {
        float rotationDirection = rotateClockwise ? 1f : -1f;

        transform.Rotate(Vector3.forward, currentRotationSpeed * rotationDirection * Time.deltaTime);

        if (Time.time >= nextTime)
        {
            SetRandomRotationSpeed();
            SetRandomNextTime();
            rotateClockwise = Random.Range(0, 2) == 0;
        }
    }

    private void SetRandomRotationSpeed()
    {
        currentRotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    private void SetRandomNextTime()
    {
        nextTime = Time.time + Random.Range(minNextTime, maxNextTime);
    }
    public float GetCurrentRotationSpeed()
    {
        return currentRotationSpeed;
    }
}
