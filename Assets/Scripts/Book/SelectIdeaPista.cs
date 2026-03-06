using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectIdeaPista : MonoBehaviour
{
    [Header("Textos de selección (solo para mostrar)")]
    public TextMeshProUGUI ideaText;
    public TextMeshProUGUI pistaText;

    [Header("Botón de confirmación")]
    public Button submitButton;

    public LevelExit levelexit;

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
    }

    void OnSubmit()
    {
        // Solo permitir si ambos están asignados
        if (GameManager.idea_escogida == GameManager.Idea.None ||
            GameManager.pista_escogida == GameManager.Pista.None)
        {
            Debug.LogWarning("No se ha seleccionado idea o pista aún");
            return;
        }

        // Tomamos los valores globales
        var selectedIdea = GameManager.idea_escogida;
        var selectedPista = GameManager.pista_escogida;

        // Actualizamos los textos visibles (opcional)
        if (ideaText != null) ideaText.text = selectedIdea.ToString();
        if (pistaText != null) pistaText.text = selectedPista.ToString();

        // Registramos el cambio
        GameManager.Instance.RegistrarCanvi(selectedIdea, selectedPista);
        Debug.Log($"✅ Canvi registrado: {selectedIdea} - {selectedPista}");

        //GameManager.Instance.LoadDialogue();
        levelexit.ExitLevel();
    }
}