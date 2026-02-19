using UnityEngine;

public class DoorGlow : MonoBehaviour
{
    public SpriteRenderer outline; // Arrastra aquí tu DoorOutline
    public float glowSpeed = 2f;   // Velocidad del resplandor
    public float maxAlpha = 1f;    // Máxima opacidad del resplandor
    private bool playerNearby = false;
    private float alpha = 0f;
    private bool increasing = true;

    // Cacheamos el material para no crear instancias nuevas cada frame
    private Material outlineMaterial;
    private Color baseColor;

    void Start()
    {
        // Creamos una instancia para no afectar otros objetos que compartan el material
        outlineMaterial = Instantiate(outline.material);
        outline.material = outlineMaterial;

        // Guardamos el color base (amarillo) para modificar solo la alpha
        baseColor = outlineMaterial.GetColor("_Color");
    }

    void Update()
    {
        if (playerNearby)
        {
            // Hacer el resplandor tipo “pulso”
            if (increasing)
            {
                alpha += Time.deltaTime * glowSpeed;
                if (alpha >= maxAlpha)
                {
                    alpha = maxAlpha;
                    increasing = false;
                }
            }
            else
            {
                alpha -= Time.deltaTime * glowSpeed;
                if (alpha <= 0f)
                {
                    alpha = 0f;
                    increasing = true;
                }
            }
        }
        else
        {
            // Fade out cuando el jugador se va
            alpha -= Time.deltaTime * glowSpeed;
            if (alpha < 0f) alpha = 0f;
        }

        // Actualizamos el color del material con la alpha modificada
        Color c = baseColor;
        c.a = alpha;
        outlineMaterial.SetColor("_Color", c);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
