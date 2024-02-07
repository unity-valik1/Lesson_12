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
        // �������� ��������� Renderer �������� �������
        Renderer renderer = GetComponent<Renderer>();

        // �������� ������� (Bounds) �������
        Bounds bounds = renderer.bounds;

        // ������� ����� �������
        Vector3 center = bounds.center;

        Debug.Log("����� ���������� �������: " + center);

        // ������� ������� �������
        Vector3 size = bounds.size;

        Debug.Log("������� ���������� �������: " + size);

        currentPlatformSize = size;
        currentPlatformCenter = center;
    }
}
