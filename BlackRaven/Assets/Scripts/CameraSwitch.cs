using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public static CameraSwitch Instance { get; private set; }
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Camera otherCamera;

    private bool isPlayerCameraActive = true;

    void Awake()
    {
        Instance = this;
    }

    public void SwitchCamera(Camera otherCamera)
    {
        isPlayerCameraActive = !isPlayerCameraActive;
        playerCamera.enabled = isPlayerCameraActive;
        otherCamera.enabled = !isPlayerCameraActive;
    }

    //добавить затемнение или другой эффект, переход по времени
}
