using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    public float speed = 3.0f;

    private Rigidbody2D rigidbody2d;
    private Vector2 move;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        MoveAction.Enable();
    }

    void Update()
    {
        // ?????????? ????????? ?????? ????????? ? Update
        move = MoveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // ??????? ??????????? ????????? ? FixedUpdate
        Vector2 position = rigidbody2d.position + move * speed * Time.fixedDeltaTime;
        rigidbody2d.MovePosition(position);
    }
}