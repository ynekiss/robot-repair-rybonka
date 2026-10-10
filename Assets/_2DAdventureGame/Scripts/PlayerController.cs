using UnityEngine;
using UnityEngine.InputSystem; // Використовуємо нову Input System

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;

    // Система здоров'я
    public int maxHealth = 5;
    private int currentHealth;
    public int health { get { return currentHealth; } }

    // Невразливість
    public float timeInvincible = 2.0f;
    private bool isInvincible;
    private float invincibleTimer;

    private Rigidbody2D rigidbody2d;
    private Vector2 move;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        Vector2 moveInput = Vector2.zero;

        // Зчитуємо клавіатуру прямо через нову Input System
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moveInput.y += 1;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moveInput.y -= 1;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveInput.x -= 1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveInput.x += 1;
        }

        move = moveInput.normalized;

        // Таймер невразливості
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position + move * speed * Time.fixedDeltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log("Health: " + currentHealth + "/" + maxHealth);
    }
}