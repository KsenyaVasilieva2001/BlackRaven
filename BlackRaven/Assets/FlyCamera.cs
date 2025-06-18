using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraOrbitWithTilt : MonoBehaviour
{
    [SerializeField] private Transform target;     // Центр окружности
    [SerializeField] private float distance = 10f; // Радиус вращения
    [SerializeField] private float orbitSpeed = 10f;
    [SerializeField] private float tiltAngle = 30f; // Угол наклона вниз

    private float angle;

    void Update()
    {
        if (target == null) return;

        // Обновляем угол вращения
        angle += orbitSpeed * Time.deltaTime;

        // Вычисляем позицию камеры на окружности
        float radians = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(radians) * distance;
        float z = Mathf.Sin(radians) * distance;

        Vector3 orbitPosition = target.position + new Vector3(x, 0f, z);
        transform.position = orbitPosition + Vector3.up * Mathf.Tan(tiltAngle * Mathf.Deg2Rad) * distance;

        // Поворачиваем камеру в сторону центра, но с наклоном вниз
        Vector3 lookDir = (target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(lookDir);
        transform.rotation = targetRotation;
    }
}
