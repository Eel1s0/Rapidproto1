using UnityEngine;
using UnityEngine.SceneManagement;

public class Colliding : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Bush"))
            {
                Debug.Log("Player hit an untagged object!");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bush"))
        {
            Debug.Log("Hit the bush.");
            Time.timeScale = 0f;
            SceneManager.LoadScene("GameOver");
        }
    }
}

