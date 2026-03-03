using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonMessage : MonoBehaviour
{
    public TextMeshProUGUI actionText;   // Text de acciones (Ideas)
    public TextMeshProUGUI objectsText;  // Text de objetos (Pistas)

    public enum TipoBoton
    {
        Idea,
        Pista
    }

    [Header("Config del botón")]
    public TipoBoton tipoBoton;

    // Se usa solo si tipoBoton = Idea
    public GameManager.Idea ideaNecesaria;

    // Se usa solo si tipoBoton = Pista
    public GameManager.Pista pistaNecesaria;

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    void Start()
    {
        ActualizarEstadoBoton();
    }

    void OnEnable()
    {
        ActualizarEstadoBoton();
    }

    void Update()
    {
        ActualizarEstadoBoton();
    }

    void ActualizarEstadoBoton()
    {
        if (button == null) return;

        if (tipoBoton == TipoBoton.Idea)
        {
            if (!GameManager.idees.ContainsKey(ideaNecesaria))
            {
                button.interactable = false;
                return;
            }

            button.interactable = GameManager.idees[ideaNecesaria];
        }
        else if (tipoBoton == TipoBoton.Pista)
        {
            if (!GameManager.pistes.ContainsKey(pistaNecesaria))
            {
                button.interactable = false;
                return;
            }

            button.interactable = GameManager.pistes[pistaNecesaria];
        }
    }

    // Botones de Idea (acción)
    public void CopyButtonTextToAction(TextMeshProUGUI btnText)
    {
        if (btnText != null && actionText != null)
        {
            actionText.text = btnText.text;
        }
    }

    // Botones de Pista (objeto)
    public void CopyButtonTextToMessage(TextMeshProUGUI btnText)
    {
        if (btnText != null && objectsText != null)
        {
            objectsText.text = btnText.text;
        }
    }

    [Header("Referència al BookManager")]
    public BookManager bookManager;

    public void SelectIdea()
    {
        if (bookManager != null)
            bookManager.SeleccionarIdea((int)ideaNecesaria);
    }

    public void SelectPista()
    {
        if (bookManager != null)
            bookManager.SeleccionarPista((int)pistaNecesaria);
    }
}