using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Put exact scene name here")]
    [SerializeField]
    private string level1 = "IntroLevel";
    [SerializeField]
    private string level2 = "AdvancedLevel";

    [Header("Scriptable Object")]
    [SerializeField]
    private SO_SaveData saveDataObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGamePlay()
    {
        saveDataObject.shouldLoad = false;
        SceneManager.LoadScene(level1);
    }

    public void loadGamePlay()
    {
        saveDataObject.shouldLoad = true; //to make sure that bool is set and any data from previous save can be picked


        LevelLocator.currentLevel levelCurr = saveDataObject.currentLevel;

        if (levelCurr == LevelLocator.currentLevel.Level1)
        {
            SceneManager.LoadScene(level1);
        }
        else if(levelCurr == LevelLocator.currentLevel.Level2)
        {
            SceneManager.LoadScene(level2);
        }
        else
        {
            Debug.LogError("Scene names are not Set properly - Aditya");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
