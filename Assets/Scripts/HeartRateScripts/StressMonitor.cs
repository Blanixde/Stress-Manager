using UnityEngine;

public class StressMonitor : MonoBehaviour
{
    public static int age = 20;
    public Renderer myRenderer;

    public BioDataManager dataManager;

    private double RMSSDvalue;

    private float minRMSSD;

    // Update is called once per frame
    void Update()
    {
        this.RMSSDvalue = dataManager.getStressLevel();
        changeColor(getColor());
    }

    // Methode to change Color of the Status Window
    private void changeColor(Color color)
    {
        myRenderer.material.color = color;
    }

    // Get Color depending On your RMSSD Value compared to the Baseline
    private Color getColor()
    {
        RMSSDbaseLine();

        if (this.RMSSDvalue > this.minRMSSD + this.minRMSSD * 0.05)
        {
            return new Color(0, 0, 255);
        }
        else if (this.RMSSDvalue >= this.minRMSSD)
        {
            return new Color(0, 255, 0);
        }
        else if (this.RMSSDvalue > this.minRMSSD - this.minRMSSD * 0.05)
        {
            return new Color(255, 0, 100);
        }
        else if (this.RMSSDvalue > this.minRMSSD - this.minRMSSD * 0.1)
        {
            return new Color(255, 100, 0);
        }
        else
        {
            return new Color(255, 0, 0);
        }
    }

    // Methode to get the RMSSD Base Value depending on your Age
    private void RMSSDbaseLine()
    {
        float baseLine = 50f;

        if (StressMonitor.age > 64)
        {
            baseLine -= 35;
        }
        else if (StressMonitor.age > 49)
        {
            baseLine -= 30;
        }
        else if (StressMonitor.age > 29)
        {
            baseLine -= 20;
        }

        this.minRMSSD = baseLine;
    }
}
