using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Add this

public class BeatSync : MonoBehaviour
{
    public float bpm = 120f;
    public AudioSource musicSource;
    public AudioSource soundEffect;
    public Image beatIndicator; // Assign in Inspector

    private float beatInterval;
    private float nextBeatTime;
    private bool canPressE = false;
    private int beatCount = 0; // Counts the beats

    void Start()
    {
        beatInterval = 60f / bpm;
        nextBeatTime = beatInterval;
        if (beatIndicator != null)
            beatIndicator.enabled = false; // Hide at start
    }

    void Update()
    {
        if (musicSource == null || !musicSource.isPlaying)
            return;

        float musicTime = musicSource.time;

        // Check if it's time for the next beat
        if (musicTime >= nextBeatTime)
        {
            beatCount++;
            // Only allow on every other beat (e.g., even beats)
            if (beatCount % 2 == 0)
            {
                canPressE = true;
                if (beatIndicator != null)
                    beatIndicator.enabled = true; // Show indicator
            }
            else
            {
                canPressE = false;
                if (beatIndicator != null)
                    beatIndicator.enabled = false; // Hide indicator
            }
            nextBeatTime += beatInterval;
        }

        // Listen for E key press on the allowed beat
        if (canPressE && Input.GetKeyDown(KeyCode.E))
        {
            if (soundEffect != null)
                soundEffect.Play();
            canPressE = false;
            if (beatIndicator != null)
                beatIndicator.enabled = false; // Hide indicator
        }

        // If the player missed the beat window, trigger Game Over
        if (canPressE && (musicTime > nextBeatTime - (beatInterval * 0.5f)))
        {
            canPressE = false;
            if (beatIndicator != null)
                beatIndicator.enabled = false; // Hide indicator
            SceneManager.LoadScene("GameOver"); // Load GameOver scene
        }
    }
}
