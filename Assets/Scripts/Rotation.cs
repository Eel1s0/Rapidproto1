using UnityEngine;

public class Rotation : MonoBehaviour
{ 
    public float RotationSpeed = 50.0f;
    private void Update()
    {
        transform.Rotate(Vector3.forward * RotationSpeed * Time.deltaTime);
    }
}
