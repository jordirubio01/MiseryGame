using UnityEngine;

public class DialogueSelector : MonoBehaviour
{
    [SerializeField] private Dialogue annieDialogue;

    // Aquí defineixes tots els diàlegs possibles
    // L'índex 0 és sempre el diàleg inicial (bucle 1)
    [System.Serializable]
    public class DialogueCase
    {
        public GameManager.Idea idea;
        public GameManager.Pista pista;
        [TextArea(2, 4)]
        public string[] lines;
    }

    [SerializeField] private string[] dialogueInicial;   // Bucle 1, sempre igual
    [SerializeField] private DialogueCase[] dialogueCases; // Un per cada combinació possible

    void Start()
    {
        string[] linesToUse;

        // Bucle 1 o sense canvi previ → diàleg inicial
        if (GameManager.bucle == 1 || GameManager.ultimCanvi == null)
        {
            linesToUse = dialogueInicial;
        }
        else
        {
            linesToUse = TrobarDialeg(GameManager.ultimCanvi.idea, GameManager.ultimCanvi.pista);
        }

        annieDialogue.SetDialogueLines(linesToUse);
    }

    private string[] TrobarDialeg(GameManager.Idea idea, GameManager.Pista pista)
    {

        foreach (var cas in dialogueCases)
        {
            if (cas.idea == idea && cas.pista == pista)
                return cas.lines;
        }

        // Si no hi ha diàleg específic per aquesta combinació
        return new string[] { "El diàleg per aquesta combinació no està creat..." };
    }
}