using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class NewPlatformLength : MonoBehaviour
{
    Tower tower;
    MoveObject moveObject;
    Vector3 newPlatformSize;
    Vector3 newPlatformCenter;
    Vector3 newPlatformSizeCrush;
    Vector3 newPlatformCenterCrush;
    Vector3 minus;

    void Start()
    {
        tower = FindObjectOfType<Tower>();
        moveObject = GetComponent<MoveObject>();
        newPlatformSize = tower.currentPlatformSize;
        newPlatformCenter = tower.currentPlatformCenter;
    }

    public void Metod()
    {
        moveObject.Pause();
        NewPlatform();
        Destroy(gameObject);
    }
    void NewPlatform()
    {
        // �������� ��������� Renderer �������� �������
        Renderer renderer = GetComponent<Renderer>();
        // �������� ������� (Bounds) �������
        Bounds bounds = renderer.bounds;
        // ������� ����� �������
        Vector3 center = bounds.center;
        // ������� ������� �������
        Vector3 size = bounds.size;

        if (center.x > tower.currentPlatformCenter.x)//���� ����� ����� ��������� ������ �������
        {
            minus.x = center.x - tower.currentPlatformCenter.x;//������� �������� ������
            newPlatformCenter = new Vector3(newPlatformCenter.x + (minus.x / 2), center.y, center.z);//������� ����� ����� ���������
            newPlatformSize = new Vector3(newPlatformSize.x - minus.x, size.y, size.z);//������� ������ ������ ���������
        }
        else if(center.x < tower.currentPlatformCenter.x)//���� ����� ����� ��������� ������ �������
        {
            minus.x = tower.currentPlatformCenter.x -center.x;//������� �������� ������ 
            newPlatformCenter = new Vector3(newPlatformCenter.x - (minus.x / 2), center.y, center.z);//������� ����� ����� ���������
            newPlatformSize = new Vector3(newPlatformSize.x - minus.x, size.y, size.z);//������� ������ ������ ���������
        }

        //������� ������ �����������
        GameObject newRectangle = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newRectangle.transform.position = newPlatformCenter;
        newRectangle.transform.localScale = newPlatformSize;


        if (center.x > tower.currentPlatformCenter.x)//���� ����� ����� ��������� ������ �������
        {
            minus.x = center.x - tower.currentPlatformCenter.x;//������� �������� ������
            newPlatformCenterCrush = new Vector3(tower.currentPlatformCenter.x + tower.currentPlatformSize.x / 2.0f + (minus.x / 2), center.y, center.z);//������� ����� �������� ���������
            newPlatformSizeCrush = new Vector3(newPlatformSize.x - tower.currentPlatformSize.x, size.y, size.z);//������� ������ �������� ���������
        }
        else if (center.x < tower.currentPlatformCenter.x)//���� ����� ����� ��������� ������ �������
        {
            print("������");
            minus.x = tower.currentPlatformCenter.x - center.x;//������� �������� ������ 
            newPlatformCenterCrush = new Vector3(tower.currentPlatformCenter.x - tower.currentPlatformSize.x / 2.0f - (minus.x / 2), center.y, center.z);//������� ����� �������� ���������
            newPlatformSizeCrush = new Vector3(tower.currentPlatformSize.x - newPlatformSize.x, size.y, size.z);//������� ������ �������� ���������
        }

        //������� ������ ��������
        GameObject newRectangleCrush = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newRectangleCrush.transform.position = newPlatformCenterCrush;
        newRectangleCrush.transform.localScale = newPlatformSizeCrush;
        newRectangleCrush.AddComponent<Rigidbody>();

        tower.currentPlatformCenter = newRectangle.transform.position;
        tower.currentPlatformSize = newRectangle.transform.localScale;
        tower.currentPlatform = newRectangle.gameObject;
    }
}
