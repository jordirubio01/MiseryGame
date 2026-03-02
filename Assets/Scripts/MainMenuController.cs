using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void NovaPartida()
    {
        GameManager.Instance.ResetVariables();
        GameManager.Instance.LoadDialogue();
    }
}
