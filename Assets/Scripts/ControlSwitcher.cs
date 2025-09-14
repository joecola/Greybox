using UnityEngine;
using Cinemachine; // Required for camera control

public class ControlSwitcher : MonoBehaviour
{
    public GameObject playerCharacter;
    public GameObject car;
    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera carCamera; // Add a reference for the new camera

    private bool isControllingCar = false;
    private CarController carController;
    private StarterAssets.ThirdPersonController playerController; 

    void Start()
    {
        carController = car.GetComponent<CarController>();
        playerController = playerCharacter.GetComponent<StarterAssets.ThirdPersonController>();

        // Set initial state: Player is active, car is not
        playerController.enabled = true;
        carController.enabled = false;
        
        // Set camera priorities: Player camera is active, car camera is not
        playerCamera.Priority = 11;
        carCamera.Priority = 10;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton3)) // E key or Y button
        {
            // Optional: Proximity check
            if (!isControllingCar && Vector3.Distance(playerCharacter.transform.position, car.transform.position) > 5f)
            {
                return;
            }
            
            ToggleControl();
        }
    }

    void ToggleControl()
    {
        isControllingCar = !isControllingCar;

        if (isControllingCar)
        {
            // Switch to Car
            playerController.enabled = false;
            carController.enabled = true;
            // Make the car camera active by giving it a higher priority
            playerCamera.Priority = 10;
            carCamera.Priority = 11;
        }
        else
        {
            // Switch back to Player
            playerController.enabled = true;
            carController.enabled = false;
            // Make the player camera active again
            playerCamera.Priority = 11;
            carCamera.Priority = 10;
        }
    }
}