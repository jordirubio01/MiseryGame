using UnityEngine;
using UnityEngine.UI;

public class BookSceneSetup : MonoBehaviour
{
    public string backgroundImageName = "Book"; // Pon aquí el nombre de tu imagen en Resources (sin extensión)

    void Start()
    {
        // Crear Canvas
        GameObject canvasGO = new GameObject("Canvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Crear Image de fondo
        GameObject bgGO = new GameObject("Background");
        bgGO.transform.SetParent(canvasGO.transform, false);
        Image bgImage = bgGO.AddComponent<Image>();

        // Cargar el sprite desde Resources
        Sprite bgSprite = Resources.Load<Sprite>(backgroundImageName);
        if (bgSprite != null)
            bgImage.sprite = bgSprite;
        else
            Debug.LogWarning("No se encontró la imagen en Resources: " + backgroundImageName);

        // Ajustar tamaño de la imagen para cubrir toda la pantalla
        RectTransform rt = bgGO.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0, 0);
        rt.anchorMax = new Vector2(1, 1);
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
    }
}
