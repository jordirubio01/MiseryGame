// Archivo: SelectIdeaPista.cs
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

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
    }

    void OnSubmit()
    {
        // Tomamos directamente los valores globales de GameManager
        var selectedIdea = GameManager.idea_escogida;
        var selectedPista = GameManager.pista_escogida;

        // Mostramos por consola los valores
        Debug.Log("✅ Botón Confirmar pulsado");
        Debug.Log("Idea escogida: " + selectedIdea);
        Debug.Log("Pista escogida: " + selectedPista);

        // Actualizamos los textos visibles en la UI (opcional)
        if (ideaText != null) ideaText.text = selectedIdea.ToString();
        if (pistaText != null) pistaText.text = selectedPista.ToString();

        // Creamos el cambio en GameManager como hacías antes
        GameManager.Instance.RegistrarCanvi(selectedIdea, selectedPista);
    }
}