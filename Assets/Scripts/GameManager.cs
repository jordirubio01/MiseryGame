using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadDialogue()
    {
        SceneManager.LoadScene("Reviure");
    }

    public void LoadPlatforms()
    {
        SceneManager.LoadScene("Reviure");
    }

    public void LoadExploration()
    {
        SceneManager.LoadScene("Exploration");
    }

    public void LoadBook()
    {
        SceneManager.LoadScene("Book");
    }
}
