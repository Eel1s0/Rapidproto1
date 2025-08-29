using UnityEngine;
using UnityEngine.UI;

public class BeatSync : MonoBehaviour
{
    public float bpm = 120f;
    public AudioSource musicSource;
    public AudioSource soundEffect;
    public Image beatIndicator; // Assign in Inspector

    private float beatInterval;
    private float nextBeatTime;
    private bool canPressE = false;

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
            canPressE = true;
            nextBeatTime += beatInterval;
            if (beatIndicator != null)
                beatIndicator.enabled = true; // Show indicator
        }

        // Listen for E key press on the beat
        if (canPressE && Input.GetKeyDown(KeyCode.E))
        {
            if (soundEffect != null)
                soundEffect.Play();
            canPressE = false;
            if (beatIndicator != null)
                beatIndicator.enabled = false; // Hide indicator
        }

        // Optionally, reset canPressE if the player missed the beat window
        if (musicTime > nextBeatTime - (beatInterval * 0.5f))
        {
            canPressE = false;
            if (beatIndicator != null)
                beatIndicator.enabled = false; // Hide indicator
        }
    }
}
