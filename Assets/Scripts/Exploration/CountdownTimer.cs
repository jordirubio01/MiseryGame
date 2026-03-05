using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI timerText;

    [Header("Tiempo")]
    public int startMinutes = 5;

    public LevelExit levelexit;

    private float remainingTime;

    void Start()
    {
        remainingTime = startMinutes * 60f;
        UpdateTimerUI();
    }

    void Update()
    {
        if (remainingTime <= 0f) return;

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            TimerEnded();
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerEnded()
    {
        Debug.Log("Tiempo terminado!");
        levelexit.ExitLevel();
    }
}