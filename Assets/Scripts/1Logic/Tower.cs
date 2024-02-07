using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject currentPlatform;

    public Vector3 currentPlatformSize;
    public Vector3 currentPlatformCenter;

    private void Start()
    {
        // Получаем компонент Renderer текущего объекта
        Renderer renderer = GetComponent<Renderer>();

        // Получаем границы (Bounds) объекта
        Bounds bounds = renderer.bounds;

        // Находим центр объекта
        Vector3 center = bounds.center;

        Debug.Log("Центр стартового объекта: " + center);

        // Находим размеры объекта
        Vector3 size = bounds.size;

        Debug.Log("Размеры стартового объекта: " + size);

        currentPlatformSize = size;
        currentPlatformCenter = center;
    }
}
