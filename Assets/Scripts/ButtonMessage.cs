using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonMessage : MonoBehaviour
{
    public TextMeshProUGUI actionText; // Primer Text que se actualizará
    public TextMeshProUGUI objectsText; // Segundo Text que se actualizará

    // Primer conjunto de botones
    public void CopyButtonTextToAction(TextMeshProUGUI btnText)
    {
        if (btnText != null && actionText != null)
        {
            actionText.text = btnText.text;
        }
    }

    // Segundo conjunto de botones
    public void CopyButtonTextToMessage(TextMeshProUGUI btnText)
    {
        if (btnText != null && objectsText != null)
        {
            objectsText.text = btnText.text;
        }
    }
}
