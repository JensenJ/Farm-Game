using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour {

    public GameObject hexPrefab;

    //size of the map in hex tiles, not world space.
    public int width = 20;
    public int height = 20;

    float xOffset = 0.889f * 2;
    float zOffset = 1.55f;

    public void GenerateWorld()
    {
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xPos = x * xOffset;
                if (y % 2 == 1)
                {
                    xPos += xOffset / 2f;
                }
                GameObject hex_go = Instantiate(hexPrefab, new Vector3(xPos, 0, y * zOffset), Quaternion.identity);
                hex_go.name = "Hex_" + x + "_" + y;
                hex_go.transform.SetParent(this.transform);
                hex_go.isStatic = true;
            }
        }
    }
}
