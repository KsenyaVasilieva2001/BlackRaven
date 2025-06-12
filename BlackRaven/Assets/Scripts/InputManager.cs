using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
* ����� ��� ��������� ��������� ������
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
