using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    [SerializeField] private float speed = 2f;           // Movement speed in units per second
    [SerializeField] private float moveDistance = 10f;   // Distance before resetting

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the object horizontally
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Check if the object has moved the specified distance
        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
        {
            // Reset position to start
            transform.position = startPosition;
        }
    }
}
