using TMPro;
using UnityEngine;

public class BPMScreen : MonoBehaviour
{
    public TextMeshProUGUI text;
    public BioDataManager dataManager;

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    // Update the BPM Monitor Text with Value from Datamanager
    void UpdateText()
    {
        text.text = (dataManager.getHeartRate()).ToString();
    }
}
