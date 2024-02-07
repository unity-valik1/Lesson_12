using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject transformSpawn;
    MeshGenerator meshGenerator;
    TowerFromPlatform towerFromPlatform;
    void Start()
    {
        meshGenerator = FindObjectOfType<MeshGenerator>();
        SpawnObj();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<NewPlatform>().Metod();
            SpawnObj();
        }
    }
    private void SpawnObj()
    {
        transformSpawn.transform.position += new Vector3(0, 1, 0); 
        
        GameObject newObj = Instantiate(meshGenerator.obj, transformSpawn.transform.position, Quaternion.identity);

        newObj.GetComponent<MoveObject>().moveDistance.x = -15;
        newObj.GetComponent<NewPlatform>();
    }
}
