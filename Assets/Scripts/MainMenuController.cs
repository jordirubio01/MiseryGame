using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public LevelExit levelexit;
    public void NovaPartida()
    {
        GameManager.Instance.ResetVariables();
        GameManager.Instance.LoadDialogue();
    }
    public void TornarAlMenu()
    {
        GameManager.Instance.ResetVariables();
        levelexit.ExitLevel();
    }
}
