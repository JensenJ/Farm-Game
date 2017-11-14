using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    MeshRenderer mr;
    public Material[] mats;
    public int buildingId;
    bool isPlacing = false;
    GameObject ourHitObject;
    public GameObject hex;
    public GameObject[] prefab;
    float xOffset = -0.7f;
    float yOffset = 0f;
    float zOffset = 0.45f;
    GameObject prefab_go;
    int prefabId = 0;
    public Crops crops;


    // Update is called once per frame
    void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            ourHitObject = hitInfo.collider.transform.gameObject;
            //Debug.Log("Raycast hit: " + ourHitObject.name);
            if (Input.GetMouseButtonDown(0) && ourHitObject.tag == "Hex" && isPlacing == true)
            {
                mr = ourHitObject.GetComponentInChildren<MeshRenderer>();
                mr.material = mats[1];
                PlacePrefab(buildingId, ourHitObject);
                isPlacing = false;

            }
        }
	}

    public void ChangePrefabId(int idToChangeto)
    {
        buildingId = idToChangeto;
        isPlacing = true;
    }

    public void PlacePrefab(int id, GameObject hexInstance)
    {
        float x = hexInstance.transform.position.x;
        float y = hexInstance.transform.position.y;
        float z = hexInstance.transform.position.z;
        float xPos = x + xOffset;
        float yPos = y + yOffset;
        float zPos = z + zOffset;

        if (hexInstance.transform.childCount <= 0)
        {
            prefab_go = Instantiate(prefab[id], new Vector3(xPos, yPos, zPos), Quaternion.identity);
            prefab_go.name = "Prefab_" + buildingId + "_" + prefabId;
            prefab_go.transform.SetParent(hexInstance.transform);
            print(hexInstance.transform.parent.name); 
        }
        else
        {
            print("obstruction");
        }
    }
    public void EndTurn()
    {
        isPlacing = false;
        crops.ReplaceCrops(ourHitObject);
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ExitGame()
    {
        Application.Quit();
        print("exit");
    }
}