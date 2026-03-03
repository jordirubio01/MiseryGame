using UnityEngine;

public class BookManager : MonoBehaviour
{
    private GameManager.Idea ideaEscollida;
    private GameManager.Pista pistaEscollida;
    private bool ideaSeleccionada = false;
    private bool pistaSeleccionada = false;

    // Crida des de l'OnClick de cada botó d'Idea
    public void SeleccionarIdea(int ideaIndex)
    {
        ideaEscollida = (GameManager.Idea)ideaIndex;
        ideaSeleccionada = true;
        Debug.Log($"Idea seleccionada: {ideaEscollida}");
    }

    // Crida des de l'OnClick de cada botó de Pista
    public void SeleccionarPista(int pistaIndex)
    {
        pistaEscollida = (GameManager.Pista)pistaIndex;
        pistaSeleccionada = true;
        Debug.Log($"Pista seleccionada: {pistaEscollida}");
    }

    // Crida des del botó Confirmar
    public void ConfirmarCanvi()
    {
        if (!ideaSeleccionada || !pistaSeleccionada)
        {
            Debug.LogWarning("Cal seleccionar una idea i una pista abans de confirmar.");
            return;
        }
        GameManager.Instance.RegistrarCanvi(ideaEscollida, pistaEscollida);
    }
}