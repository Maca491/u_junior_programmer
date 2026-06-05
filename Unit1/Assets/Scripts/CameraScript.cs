using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    [SerializeField] private GameObject firstPersonCamera;

    
    [SerializeField] private GameObject thirdPersonCamera;

    private GameObject activeCamera;

    
    private Vector3 thirdPersonOffset = new Vector3(0, 5, -7); 

    private Vector3 firstPersonOffset = new Vector3(0, 2.12f, 0.6f);

    private Vector3 activeOffset;

    private bool isFirstPerson = false;

    private InputSystem_Actions controls;

    // Awake se volá dříve než Start, ideální pro inicializaci
    private void Awake() 
    {
        controls = new InputSystem_Actions();
        
        controls.Player.ChangeCamera.performed += OnCameraSwap;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstPersonCamera = GameObject.Find("First Person Camera");
        thirdPersonCamera = GameObject.Find("Third Person Camera");
        firstPersonCamera.SetActive(false);
        activeOffset = thirdPersonOffset;
        activeCamera = thirdPersonCamera;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        activeCamera.transform.position = player.transform.position + activeOffset;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void OnCameraSwap(InputAction.CallbackContext context)  
    {
        if (isFirstPerson)
        {
            firstPersonCamera.SetActive(false);
            thirdPersonCamera.SetActive(true);
            isFirstPerson = false;
            activeOffset = thirdPersonOffset;
            activeCamera = thirdPersonCamera;
        }
        else
        {
            thirdPersonCamera.SetActive(false);
            firstPersonCamera.SetActive(true);
            isFirstPerson = true;
            activeOffset = firstPersonOffset;
            activeCamera = firstPersonCamera;
        }
    }
}
