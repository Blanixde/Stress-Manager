using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }

    public void setAge(string age)
    {
        if (int.TryParse(age, out int numAge))
        {
            if (numAge < 0)
            {
                numAge = 20;
            }
            else if (numAge > 100)
            {
                numAge = 100;
            }
        }
        else
        {
            numAge = 20;
        }

        StressMonitor.age = numAge;
    }
}