using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    private float timerDisplay;
    private bool isDisplaying;

    private void Start()
    {
        timerDisplay = -1.0f;
    }

    private void Update()
    {
        if (isDisplaying)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                isDisplaying = false;
            }
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        isDisplaying = true;

        // Викликаємо відображення діалогу в UI
        if (UIHandler.instance != null)
        {
            UIHandler.instance.DisplayDialogue();
        }
    }
}