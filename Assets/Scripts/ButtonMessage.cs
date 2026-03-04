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
        button.onClick.AddListener(OnButtonClick);
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

    void OnButtonClick()
    {
        // Actualiza los textos visibles
        if (tipoBoton == TipoBoton.Idea)
        {
            if (actionText != null)
            {
                actionText.text = ideaNecesaria.ToString();
                Debug.Log("Idea seleccionada (texto): " + actionText.text);
            }
            // Guarda en GameManager
            GameManager.idea_escogida = ideaNecesaria;
            Debug.Log("Idea global seleccionada: " + GameManager.idea_escogida);
        }
        else if (tipoBoton == TipoBoton.Pista)
        {
            if (objectsText != null)
            {
                objectsText.text = pistaNecesaria.ToString();
                Debug.Log("Pista seleccionada (texto): " + objectsText.text);
            }
            // Guarda en GameManager
            GameManager.pista_escogida = pistaNecesaria;
            Debug.Log("Pista global seleccionada: " + GameManager.pista_escogida);
        }
    }
}