using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    [SerializeField] float scaleMultiplier = 1.25f;
    [SerializeField] float pulseSharpness = 2.5f;
    [SerializeField] float refreshIntervall = 5f;

    public BioDataManager dataManager;

    public AudioSource audio;

    private double bpm = 60;

    private Vector3 originalScale;

    private float time = 0f;


    private void Start()
    {
        originalScale = transform.localScale;
    }

    // Heartrate Animation due to Time done with AI
    void Update()
    {

        time += Time.deltaTime;

        if (time >= refreshIntervall)
        {
            {
                UpdateHeartRate();
                time = 0f;
            }
        }


        if (bpm <= 0) return;

        // Convert BPM to cycles per second (Frequency in Hz)
        float beatsPerSecond = (float)bpm / 60f;

        // Use Sine wave to generate a 0 to 1 smooth oscillation
        // Mathf.Sin returns -1 to 1; (Sin + 1) / 2 maps it to 0 to 1
        float wave = (Mathf.Sin(Time.time * beatsPerSecond * Mathf.PI * 2f) + 1f) * 0.5f;

        // Optional: Apply power function to make it feel more like a sharp beat than a smooth wave
        float heartbeatFactor = Mathf.Pow(wave, pulseSharpness);

        // Interpolate between original scale and expanded scale
        float currentScaleFactor = Mathf.Lerp(1f, scaleMultiplier, heartbeatFactor);
        transform.localScale = originalScale * currentScaleFactor;


        if (transform.localScale == originalScale)
        {
            audio.Play();
        }
    }

    // Update the BPM value 
    private void UpdateHeartRate()
    {
        this.bpm = dataManager.getHeartRate();
    }
}
