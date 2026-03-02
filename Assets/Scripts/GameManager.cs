using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Enum idees
    public enum Idea
    {
        Reviure,
        Destrossar,
        Escoltar,
        Reproduir,
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

        idees.Clear();
        pistes.Clear();

        foreach (Idea idea in System.Enum.GetValues(typeof(Idea)))
            idees.Add(idea, false);

        foreach (Pista pista in System.Enum.GetValues(typeof(Pista)))
            pistes.Add(pista, false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        salut = 1;
        Debug.Log("Resolución actual: " + Screen.width + "x" + Screen.height);
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (Keyboard.current.digit0Key.wasPressedThisFrame) SceneManager.LoadScene("MainMenu");
        if (Keyboard.current.digit1Key.wasPressedThisFrame) LoadDialogue();
        if (Keyboard.current.digit2Key.wasPressedThisFrame) LoadPlatforms();
        if (Keyboard.current.digit3Key.wasPressedThisFrame) LoadExploration();
        if (Keyboard.current.digit4Key.wasPressedThisFrame) LoadBook();
        if (Keyboard.current.numpadPlusKey.wasPressedThisFrame && salut < 6)
        {
            salut += 1;
            Debug.Log("Salut: " + salut + " | Time: " + Time.time);
        }
        if (Keyboard.current.numpadMinusKey.wasPressedThisFrame && salut > 0)
        {
            salut -= 1;
            Debug.Log("Salut: " + salut + " | Time: " + Time.time);
        }
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
        SceneManager.LoadScene("Dialogue");
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
