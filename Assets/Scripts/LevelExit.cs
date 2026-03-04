using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelExit : MonoBehaviour
{
    public string NextSceneName = "Exploration"; // CAMBIAR AQUÍ para ir a otra escena
    public FadeOut fadeOut; // arrastra el FadeOut en el inspector

    public void ExitLevel()
    {
        StartCoroutine(ExitLevelCoroutine());
    }

    private IEnumerator ExitLevelCoroutine()
    {
        Debug.Log($"Starting fade before loading scene: {NextSceneName}");

        // Espera a que termine el fade
        yield return StartCoroutine(fadeOut.FadeOutCoroutine());

        // Cargar escena
        SceneManager.LoadScene(NextSceneName);
    }
}
