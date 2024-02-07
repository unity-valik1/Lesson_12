using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject transformSpawn;
    bool stopSpawn;
    Tower tower;
    //public Vector3 size1
    //;
    private void Start()
    {
        tower = FindObjectOfType<Tower>();
        Spawn();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndGame();

            if (stopSpawn == false)
            {
                FindObjectOfType<NewPlatformLength>().Metod();
                Spawn();
            }
        }
    }
    private void Spawn()
    {
        transformSpawn.transform.position += new Vector3(0, 1, 0);
        //Instantiate(platform, transformSpawn.transform.position, Quaternion.identity);

        GameObject newObj = Instantiate(platform, transformSpawn.transform.position, Quaternion.identity);

        //Renderer renderer = newObj.GetComponent<Renderer>();
        // Получаем границы (Bounds) объекта
        //Bounds bounds = renderer.bounds;
        // Находим размеры объекта
        /*size1 = bounds.size;
        size1 = tower.currentPlatformSize;
        Debug.Log(size1);*/
        newObj.transform.localScale = tower.currentPlatformSize;
    }

    void EndGame()
    {
        if(tower.currentPlatformSize.x <= 1)
        {
            stopSpawn = true;
        }
    }
}
