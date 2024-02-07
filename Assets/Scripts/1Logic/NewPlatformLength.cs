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
        // Получаем компонент Renderer текущего объекта
        Renderer renderer = GetComponent<Renderer>();
        // Получаем границы (Bounds) объекта
        Bounds bounds = renderer.bounds;
        // Находим центр объекта
        Vector3 center = bounds.center;
        // Находим размеры объекта
        Vector3 size = bounds.size;

        if (center.x > tower.currentPlatformCenter.x)//Если центр новой платформы больше текущей
        {
            minus.x = center.x - tower.currentPlatformCenter.x;//находим ненужный размер
            newPlatformCenter = new Vector3(newPlatformCenter.x + (minus.x / 2), center.y, center.z);//находим центр новой платвормы
            newPlatformSize = new Vector3(newPlatformSize.x - minus.x, size.y, size.z);//находим нужный размер платформы
        }
        else if(center.x < tower.currentPlatformCenter.x)//Если центр новой платформы меньше текущей
        {
            minus.x = tower.currentPlatformCenter.x -center.x;//находим ненужный размер 
            newPlatformCenter = new Vector3(newPlatformCenter.x - (minus.x / 2), center.y, center.z);//находим центр новой платвормы
            newPlatformSize = new Vector3(newPlatformSize.x - minus.x, size.y, size.z);//находим нужный размер платформы
        }

        //Создаем объект статический
        GameObject newRectangle = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newRectangle.transform.position = newPlatformCenter;
        newRectangle.transform.localScale = newPlatformSize;


        if (center.x > tower.currentPlatformCenter.x)//Если центр новой платформы больше текущей
        {
            minus.x = center.x - tower.currentPlatformCenter.x;//находим ненужный размер
            newPlatformCenterCrush = new Vector3(tower.currentPlatformCenter.x + tower.currentPlatformSize.x / 2.0f + (minus.x / 2), center.y, center.z);//находим центр падающей платвормы
            newPlatformSizeCrush = new Vector3(newPlatformSize.x - tower.currentPlatformSize.x, size.y, size.z);//находим размер падающей платвормы
        }
        else if (center.x < tower.currentPlatformCenter.x)//Если центр новой платформы меньше текущей
        {
            print("меньше");
            minus.x = tower.currentPlatformCenter.x - center.x;//находим ненужный размер 
            newPlatformCenterCrush = new Vector3(tower.currentPlatformCenter.x - tower.currentPlatformSize.x / 2.0f - (minus.x / 2), center.y, center.z);//находим центр падающей платвормы
            newPlatformSizeCrush = new Vector3(tower.currentPlatformSize.x - newPlatformSize.x, size.y, size.z);//находим размер падающей платвормы
        }

        //Создаем объект падающий
        GameObject newRectangleCrush = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newRectangleCrush.transform.position = newPlatformCenterCrush;
        newRectangleCrush.transform.localScale = newPlatformSizeCrush;
        newRectangleCrush.AddComponent<Rigidbody>();

        tower.currentPlatformCenter = newRectangle.transform.position;
        tower.currentPlatformSize = newRectangle.transform.localScale;
        tower.currentPlatform = newRectangle.gameObject;
    }
}
