using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = 1f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }
}
