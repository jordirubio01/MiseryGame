using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static GameManager;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Enum idees
    public enum Idea
    {
        None,
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
        None,
        Misery,
        John,
        Ian,
        MrSheldon,
        Michelle,
        DomPerignon,
        Cafeteria,
        Concert,
        Escacs
    }

    // Diccionaris idees i pistes
    public static Dictionary<Idea, bool> idees = new Dictionary<Idea, bool>();
    public static Dictionary<Pista, bool> pistes = new Dictionary<Pista, bool>();

    public static int salut; // de 0 a 6
    public static int bucle; // de 1 a 6

    public static Idea idea_escogida = Idea.None;
    public static Pista pista_escogida = Pista.None;

    public static Canvi ultimCanvi = null;


    public void RegistrarCanvi(Idea idea, Pista pista)
    {
        ultimCanvi = new Canvi(idea, pista);
        bucle++;
        if (ultimCanvi.idea == Idea.Reviure && ultimCanvi.pista == Pista.Misery) salut++;
        if (ultimCanvi.idea == Idea.Destrossar && ultimCanvi.pista == Pista.John) salut++;
        if (ultimCanvi.idea == Idea.Destrossar && ultimCanvi.pista == Pista.Cafeteria) salut--;
        if (ultimCanvi.idea == Idea.Destrossar && ultimCanvi.pista == Pista.Misery) salut--;
        if (ultimCanvi.idea == Idea.Destrossar && ultimCanvi.pista == Pista.Ian) salut++;
        if (ultimCanvi.idea == Idea.Matar && ultimCanvi.pista == Pista.Misery) salut -= 6;
    }

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
            pistes.Add(pista, true);
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
        if (Keyboard.current.digit0Key.wasPressedThisFrame) LoadMenu();
        if (Keyboard.current.digit1Key.wasPressedThisFrame) LoadDialogue();
        if (Keyboard.current.digit2Key.wasPressedThisFrame) LoadPlatforms();
        if (Keyboard.current.digit3Key.wasPressedThisFrame) LoadExploration();
        if (Keyboard.current.digit4Key.wasPressedThisFrame) LoadBook();
        if (Keyboard.current.digit5Key.wasPressedThisFrame) RegistrarCanvi(Idea.Reviure, Pista.Misery);
        if (Keyboard.current.digit6Key.wasPressedThisFrame) LoadChoose();
        if (Keyboard.current.digit7Key.wasPressedThisFrame) LoadBad();
        if (Keyboard.current.digit8Key.wasPressedThisFrame) LoadNeutral();
        if (Keyboard.current.digit9Key.wasPressedThisFrame) LoadGood();
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

        idees[Idea.Reviure] = true;
        idees[Idea.Destrossar] = true;

        foreach (Pista pista in System.Enum.GetValues(typeof(Pista)))
            pistes[pista] = true;

        ultimCanvi = null;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
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

    public void LoadChoose()
    {
        SceneManager.LoadScene("Choose");
    }
    public void LoadBook()
    {
        SceneManager.LoadScene("Book");
    }

    public void LoadBad()
    {
        SceneManager.LoadScene("EndingBad");
    }

    public void LoadNeutral()
    {
        SceneManager.LoadScene("EndingNeutral");
    }

    public void LoadGood()
    {
        SceneManager.LoadScene("EndingGood");
    }

    public void LoadBadMenu()
    {
        SceneManager.LoadScene("MenuBad");
    }

    public void LoadNeutralMenu()
    {
        SceneManager.LoadScene("MenuNeutral");
    }

    public void LoadGoodMenu()
    {
        SceneManager.LoadScene("MenuGood");
    }
}
