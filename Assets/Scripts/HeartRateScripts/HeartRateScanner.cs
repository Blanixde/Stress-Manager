using System.IO;
using UnityEngine;

public class HeartRateScanner : MonoBehaviour
{
    [SerializeField] float interval = 1.0f;

    public BioDataManager dataManager;

    private string filePath;
    private StreamReader file;
    private float timer = 0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Open File that contains the Simulated HeartData
        filePath = Path.Combine(Application.streamingAssetsPath, "heart_rate_only_1sec.csv");
        this.file = new StreamReader(filePath);
        file.ReadLine();
    }

    // Update is called once per frame
    // Read Data every intervall
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            updateHeartRate();
            timer = 0f;
        }
    }

    // Read HeartRate Data from file
    void updateHeartRate()
    {
        string line = file.ReadLine();

        if (line == null)
        {
            dataManager.setHeartRate(0);
        }
        else
        {
            if (double.TryParse(line, out double heartRate))
            {
                dataManager.setHeartRate(heartRate);
            }
            else
            {
                dataManager.setHeartRate(0);
            }
        }
    }
}
