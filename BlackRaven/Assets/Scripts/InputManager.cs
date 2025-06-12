using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
* Класс для обработки введенных клавиш
*/
public class InputManager : MonoBehaviour
{
    [SerializeField] private KeyCode useTable;
    private void Update()
    {
        if (Input.GetKeyDown(useTable))
        {
            Debug.Log("Using Table");
            CameraSwitch.Instance.SwitchCamera();
        }
    }
}
