using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/*
* Класс для обработки введенных клавиш
*/
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public event Action OnInteractKeyPressed;
    public event Action OnUseTablePressed;
    [SerializeField] private List<MiniGameManager> miniGames;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private Inventory inventory;
    [SerializeField] private ThirdPersonCamera camera;

    [SerializeField] private Camera tableCamera;
    [SerializeField] private Camera mirrorCamer;

    [SerializeField] private KeyCode use = KeyCode.F;
    [SerializeField] private KeyCode showInventory = KeyCode.I;
    [SerializeField] private KeyCode pickItem = KeyCode.E;
    [SerializeField] private KeyCode exit = KeyCode.X;

    [SerializeField] private GameObject doorPanel;
    [SerializeField] private GameObject text;

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
        if (Input.GetKeyDown(use))
        {
            Debug.Log("Use");
            if (playerController.currentTrigger.CompareTag("Table"))
            {
                Debug.Log("Table!");
                UseTable();
            }
            else if (playerController.currentTrigger.CompareTag("Mirror")) 
            {
                UseMirror();
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
        if (Input.GetKeyDown(exit))
        {
            if (miniGames[1].IsFinished)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                doorPanel.SetActive(true);
            }
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

    public void UseTable()
    {
        CameraSwitch.Instance.SwitchCamera(tableCamera);
        EnableOrDisablePlayer();
        ShowOrHidePlayer();
        OnUseTablePressed?.Invoke();
        ShowOrHideText();
        if (!GameManager.Instance.IsInit)
        {
            GameManager.Instance.ActivateMiniGame(miniGames[0]);
            miniGames[0].InitMiniGame();
        }
        else
        {
            GameManager.Instance.DeactivateMiniGame(miniGames[0]);
            miniGames[0].DisableMiniGame();
        }
    }

    public void UseMirror()
    {
        CameraSwitch.Instance.SwitchCamera(mirrorCamer);
        EnableOrDisablePlayer();
        OnUseTablePressed?.Invoke();
        DragItem.Instance.enabled = true;
        DragItem.Instance.SetCamera(mirrorCamer);
        ShowOrHideText();
        if (!GameManager.Instance.IsInit)
        {
            GameManager.Instance.ActivateMiniGame(miniGames[1]);
            miniGames[1].InitMiniGame();
        }
        else
        {
            GameManager.Instance.DeactivateMiniGame(miniGames[1]);
            miniGames[1].DisableMiniGame();
        }
    }

    
    public void ShowOrHidePlayer()
    {
        playerController.gameObject.SetActive(!playerController.gameObject.active);
    }

    public void ShowOrHideText()
    {
        text.SetActive(!text.active);
    }

}
