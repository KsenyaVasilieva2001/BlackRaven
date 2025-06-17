using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
* Класс для обработки введенных клавиш
*/
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public event Action OnInteractKeyPressed;
    public event Action OnUseTablePressed;


    [SerializeField] private PlayerController playerController;
    [SerializeField] private Inventory inventory;
    [SerializeField] private ThirdPersonCamera camera;
    
    [SerializeField] private KeyCode useTable = KeyCode.F;
    [SerializeField] private KeyCode showInventory = KeyCode.I;
    [SerializeField] private KeyCode pickItem = KeyCode.E;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(useTable))
        {
            CameraSwitch.Instance.SwitchCamera();
            EnableOrDisablePlayer();
            ShowOrHidePlayer();
            OnUseTablePressed?.Invoke();
            if (!HairDyeMiniGameManager.Instance.IsInit)
            {
                HairDyeMiniGameManager.Instance.InitMiniGame();
            }
            else
            {
                HairDyeMiniGameManager.Instance.DisableMiniGame();
            }
        }
        if (Input.GetKeyDown(showInventory))
        {
            inventory.ShowOrHideInventory();
            EnableOrDisablePlayer(); //also move these methods to actions
        }
        if (Input.GetKeyDown(pickItem))
        {
            OnInteractKeyPressed?.Invoke();
        }
    }

    /*
     * Should move this method to PlayerController, with Action and Invoke. A
     * And also check Exit button (inventory)
     */
    public void EnableOrDisablePlayer()
    {
        playerController.enabled = !playerController.enabled;
        camera.enabled = !camera.enabled;
    }

    public void ShowOrHidePlayer()
    {
        playerController.gameObject.SetActive(!playerController.gameObject.active);
    }
    
}
