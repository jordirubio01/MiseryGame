using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ObjectDescriptionUI : MonoBehaviour
{
    public static ObjectDescriptionUI Instance;

    public GameObject panel;
    public Image objectImage;
    public TMP_Text descriptionText;

    void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    void Update()
    {
        if ((panel.activeSelf && Keyboard.current.escapeKey.wasPressedThisFrame)
            || (panel.activeSelf && Keyboard.current.qKey.wasPressedThisFrame))
        {
            Hide();
        }
    }
    public void Show(Sprite sprite, string text)
    {
        objectImage.sprite = sprite;
        descriptionText.text = text;
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}