using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Dropdown worldsize;
    public Map map;
    List<string> worldSizes = new List<string>() {"Select WorldSize", "Small", "Medium", "Large"};
    public GameObject mainMenu, worldSettings, gameUI, pauseMenu;
    public CameraController cCamera;
    int toggleIncrement;
    bool canCreate = false;

    public void Dropdown_IndexChanged(int worldsize)
    {
        if (worldsize == 1)
        {
            map.width = 20;
            map.height = 20;
            print("worldsize = " + map.width + ", " + map.height);
            canCreate = true;
        }
        else if (worldsize == 2)
        {
            map.width = 30;
            map.height = 30;
            print("worldsize = " + map.width + ", " + map.height);
            canCreate = true;
        }
        else if (worldsize == 3)
        {
            map.width = 40;
            map.height = 40;
            print("worldsize = " + map.width + ", " + map.height);
            canCreate = true;
        }
        else if(worldsize == 0)
        {
            print("Worldsize must be selected");
            canCreate = false;
        }
    }

	void Start () {
        PopulateList();
        HidePanel(gameUI);
        HidePanel(worldSettings);
        HidePanel(pauseMenu);
	}

    void PopulateList()
    {
        worldsize.AddOptions(worldSizes);
    }
    public void HidePanel(GameObject panel)
    {
        panel.gameObject.SetActive(false);
    }
    public void ShowPanel(GameObject panel)
    {
        panel.gameObject.SetActive(true);
    }
    public void TogglePanel(GameObject panel)
    {
        toggleIncrement++;
        if(toggleIncrement % 2 == 1)
        {
            HidePanel(panel);
        }
        else
        {
            ShowPanel(panel);
        }
    }
    public void CreateWorld()
    {
        if (canCreate)
        {
            HidePanel(mainMenu);
            HidePanel(worldSettings);
            ShowPanel(gameUI);
            map.GenerateWorld();
            cCamera.WorldCreated();
        }
        else
        {
            print("You must choose a world size");
        }
    }
    public void GamePause()
    { 
        HidePanel(gameUI);
        ShowPanel(pauseMenu);
    }
    public void GameResume()
    {
        HidePanel(pauseMenu);
        ShowPanel(gameUI);
        
    }
}