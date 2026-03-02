using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public Image[] hearts;       
    public Sprite corazonRojo;    
    public Sprite corazonGris;

    void Update()
    {
        int vida = GameManager.salut; 
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < vida ? corazonRojo : corazonGris;
        }
    }
}