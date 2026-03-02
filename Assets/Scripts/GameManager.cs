using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Enum idees
    public enum Idea
    {
        Reviure,
        Destrossar,
        Escoltar,
        Play,
        Matar,
        Amagar,
        Protegir,
        Separar,
        Casar
    }
    // Enum pistes
    public enum Pista
    {
        Misery,
        John,
        Ian,
        MrSheldon,
        Gravadora,
        DomPerignon,
        Informe,
        Tocadiscs,
        Escacs
    }

    // Diccionaris idees i pistes
    public static Dictionary<Idea, bool> idees = new Dictionary<Idea, bool>();
    public static Dictionary<Pista, bool> pistes = new Dictionary<Pista, bool>();

    public static int salut; // de 0 a 6
    public static int bucle; // de 1 a 6

    // Canvi fet a la ronda anterior
    public class Canvi
    {
        public Idea idea;
        public Pista pista;

        public Canvi(Idea i, Pista p)
        {
            idea = i;
            pista = p;
        }
    }

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
    public void ResetVariables()
    {
        salut = 1;
        bucle = 1;

        foreach (Idea idea in System.Enum.GetValues(typeof(Idea)))
            idees[idea] = false;

        foreach (Pista pista in System.Enum.GetValues(typeof(Pista)))
            pistes[pista] = false;
    }

    public void LoadDialogue()
    {
        SceneManager.LoadScene("Platform");
    }

    public void LoadPlatforms()
    {
        SceneManager.LoadScene("Platform");
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
