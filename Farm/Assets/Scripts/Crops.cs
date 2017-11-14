using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour {

    GameObject prefab_go;
    public GameObject[] prefab;

    public void ReplaceCrops(GameObject hexInstance)
    {
        GameObject[] Crops1 = GameObject.FindGameObjectsWithTag("Crop1");
        GameObject[] Crops2 = GameObject.FindGameObjectsWithTag("Crop2");
        GameObject[] Crops3 = GameObject.FindGameObjectsWithTag("Crop3");
        GameObject[] Crops4 = GameObject.FindGameObjectsWithTag("Crop4");
        for (int i = 0; i < Crops1.Length; i++)
        {
            int id = 1;
            float x = Crops1[i].transform.position.x;
            float y = Crops1[i].transform.position.y;
            float z = Crops1[i].transform.position.z;

            prefab_go = Instantiate(prefab[id], new Vector3(x, y, z), Quaternion.identity);
            prefab_go.name = "Prefab_";
            prefab_go.transform.SetParent(hexInstance.transform);
            Destroy(Crops1[i]);
        }
        for (int i = 0; i < Crops2.Length; i++)
        {
            int id = 2;
            float x = Crops2[i].transform.position.x;
            float y = Crops2[i].transform.position.y;
            float z = Crops2[i].transform.position.z;

            prefab_go = Instantiate(prefab[id], new Vector3(x, y, z), Quaternion.identity);
            prefab_go.name = "Prefab_";
            prefab_go.transform.SetParent(hexInstance.transform);
            Destroy(Crops2[i]);
        }
        for (int i = 0; i < Crops3.Length; i++)
        {
            int id = 3;
            float x = Crops3[i].transform.position.x;
            float y = Crops3[i].transform.position.y;
            float z = Crops3[i].transform.position.z;

            prefab_go = Instantiate(prefab[id], new Vector3(x, y, z), Quaternion.identity);
            prefab_go.name = "Prefab_";
            prefab_go.transform.SetParent(hexInstance.transform);
            Destroy(Crops3[i]);
        }
        for (int i = 0; i < Crops4.Length; i++)
        {
            int id = 0;
            float x = Crops4[i].transform.position.x;
            float y = Crops4[i].transform.position.y;
            float z = Crops4[i].transform.position.z;

            prefab_go = Instantiate(prefab[id], new Vector3(x, y, z), Quaternion.identity);
            prefab_go.name = "Prefab_";
            prefab_go.transform.SetParent(hexInstance.transform);
            Destroy(Crops4[i]);
        }

    }
}
