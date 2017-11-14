using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 2f;
    public float minY = 2f;
    public float maxY = 20f;
    public bool isMoveable = false;
    public float transitionDuration = 0.5f;
    public Transform GameTransform, MenuTransform;
    public Map map;
    public Menu menu;
    
    IEnumerator Transition(Transform target)
    {
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);

            transform.position = Vector3.Lerp(startingPos, target.position, t);
            yield return 0;
        }
    }

    void Start()
    {
        isMoveable = false;
    }
    void Update()
    {
        if(isMoveable)
        {
            Vector3 pos = transform.position;
            
            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                pos.z += panSpeed * Time.deltaTime;
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            {
                pos.z -= panSpeed * Time.deltaTime;
                pos.x -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                pos.z -= panSpeed * Time.deltaTime;
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            {
                pos.z += panSpeed * Time.deltaTime;
                pos.x -= panSpeed * Time.deltaTime;
            }
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            pos.y -= scroll * scrollSpeed * 100 * Time.deltaTime;
            pos.x = Mathf.Clamp(pos.x, -5, map.width * 1.35f);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            pos.z = Mathf.Clamp(pos.z, -5, map.height * 1.35f);
            transform.position = pos;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GamePause();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameResume();
            }
        }
    }
    public void WorldCreated()
    {
        StartCoroutine(Transition(GameTransform));
        isMoveable = true;
        RenderSettings.fogEndDistance = 100;
    }
    public void GamePause()
    {
        menu.GamePause();
        isMoveable = false;
        StartCoroutine(Transition(MenuTransform));
        RenderSettings.fogEndDistance = 50;
    }
    public void GameResume()
    {
        menu.GameResume();
        StartCoroutine(Transition(GameTransform));
        isMoveable = true;
        RenderSettings.fogEndDistance = 100;
    }
}