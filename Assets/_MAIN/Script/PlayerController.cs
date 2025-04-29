using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public static PlayerController i;
    
    [Header("Value")]
    [Space]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float rotationTorque = 2f;
    private float _moveInput;
    private float _inputVelocity;
    
    [Header("Components")]
    [Space]
    public Transform controllerTransform;
    public Rigidbody2D controllerRb;
    
    [Header("Ground Check")]
    [Space]
    public bool isGrounded;
    private float _groundCheckRadius = 0.2f;
    public Vector2 groundCheckOffset; // Смещение точки проверки земли
    [SerializeField] private LayerMask groundLayer; // Слой земли для проверки

    void Awake()
    {
        i = this;
    }
    
    void OnDrawGizmos() // Для визуальной отладки зоны проверки земли
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(GetGroundPosition(), _groundCheckRadius);
    }

    Vector2 GetGroundPosition()
    {
        Vector2 checkPos = (Vector2)controllerTransform.position + groundCheckOffset;
        return checkPos;
    }

    void Update()
    {
        // Проверка, на земле ли шар
        isGrounded = Physics2D.OverlapCircle(GetGroundPosition(), _groundCheckRadius, groundLayer);

        // Прыжок при нажатии пробела
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    
    void FixedUpdate()
    {
        // Горизонтальное движение
        float moveInput = Input.GetAxisRaw("Horizontal");
        controllerRb.AddForce(Vector2.right * moveInput * moveSpeed);

        // Добавление вращения при движении
        if (Mathf.Abs(moveInput) > 0)
        {
            Move(moveInput);
        }
    }
    
    public void Jump()
    {
        Debug.Log("_isGrounded = " + isGrounded);
        if(!isGrounded) return;
        controllerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    
    public void Move(float moveValue)
    {
        controllerRb.AddTorque(-moveValue * rotationTorque, ForceMode2D.Force);
    }
}
