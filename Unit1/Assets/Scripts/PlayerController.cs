using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private float speed = 20.0f;

    [SerializeField]
    private float turnSpeed = 45.0f;


    [SerializeField]
    private float turboSpeed = 2.0f;

    public bool usingTurbo = false;

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
        usingTurbo = controls.Player.Turbo.IsPressed();
        turboSpeed = usingTurbo ? turboSpeed : 1;
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        transform.Translate(Vector3.forward * Time.deltaTime * speed * turboSpeed);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * moveInput.x);
        //Vector je up, protože rotojume kolem kolem osy Y
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveInput.x * turboSpeed);
        turboSpeed = 2;
    }
}
