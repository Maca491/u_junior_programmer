using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private float speedMultiplier = 5.0f;

    [SerializeField]
    private float turnSpeed;

    private InputSystem_Actions controls;
    private Vector2 moveInput;

    //min. barebones for new input system
    private void Awake()
    {
        controls = new InputSystem_Actions();
        controls.Player.Enable();
    }

    void Update()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        transform.Translate(Vector3.forward * Time.deltaTime * speedMultiplier * moveInput.y);
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * moveInput.x);
    }
}
