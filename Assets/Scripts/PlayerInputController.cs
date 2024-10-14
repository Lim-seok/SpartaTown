using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;
    public Text nameText;
    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownController _controller;
    private void Awake()
    {
        camera = Camera.main;
        _controller = GetComponent<TopDownController>();
    }
    private void Start()
    {
        _controller.OnLookEvent += OnAim;
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        nameText.text = playerName;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        TurnPlayer(newAimDirection);
    }
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
        // 실제 우믹이는 처리는 여기서하는게 아니라 PlayerMovement에서 함
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

    private void TurnPlayer(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}
