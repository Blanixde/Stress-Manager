using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteractableScript : MonoBehaviour, IInteractable
{
    [SerializeField] string objectInteractMessage;
    public string InteractMessage => objectInteractMessage;

    void IInteractable.interact()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
