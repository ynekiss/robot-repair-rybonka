using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance { get; private set; }

    private VisualElement m_Healthbar;
    private VisualElement m_DialogueWindow;
    private float m_TimerDisplay;

    // Елементи EndScreen
    private VisualElement m_EndScreen;
    private Label m_EndMessage;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;

        m_Healthbar = root.Q<VisualElement>("HealthBar");

        // Діалог
        m_DialogueWindow = root.Q<VisualElement>("NPCDialogue");
        if (m_DialogueWindow != null)
        {
            m_DialogueWindow.style.display = DisplayStyle.None;
        }

        // Вікно кіношного фіналу / Win/Lose
        m_EndScreen = root.Q<VisualElement>("EndScreen");
        m_EndMessage = root.Q<Label>("EndMessage");

        if (m_EndScreen != null)
        {
            m_EndScreen.style.display = DisplayStyle.None;
        }

        m_TimerDisplay = -1.0f;
    }

    private void Update()
    {
        if (m_TimerDisplay >= 0)
        {
            m_TimerDisplay -= Time.deltaTime;
            if (m_TimerDisplay < 0)
            {
                if (m_DialogueWindow != null)
                {
                    m_DialogueWindow.style.display = DisplayStyle.None;
                }
            }
        }
    }

    public void SetHealthValue(float percentage)
    {
        if (m_Healthbar != null)
        {
            m_Healthbar.style.width = Length.Percent(percentage * 100);
        }
    }

    public void DisplayDialogue()
    {
        if (m_DialogueWindow != null)
        {
            m_DialogueWindow.style.display = DisplayStyle.Flex;
            m_TimerDisplay = 4.0f;
        }
    }

    // Відображення екрана Win/Lose
    public void ShowEndScreen(string message)
    {
        if (m_EndScreen != null)
        {
            if (m_EndMessage != null)
            {
                m_EndMessage.text = message;
            }
            m_EndScreen.style.display = DisplayStyle.Flex;
        }
    }
}