using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    [Header("Scene names")]
    public string titleSceneName = "Title Screen";
    public string level1 = "IntroLevel";
    public string level2 = "AdvancedLevel";

    [Header("UI References")]
    [SerializeField]
    GameObject pausePanel;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    GameObject savePanel;

    [Header("Player references")]
    [SerializeField]
    GameObject spherePlayer;

    [SerializeField]
    GameObject cubePlayer;

    [SerializeField]
    SO_SaveData saveDataObject;

    private void Awake()
    {
        gameManagerInstance = this;
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetPlayersInScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausePanel.gameObject.activeSelf)
        {
            Time.timeScale = 0;
            showPausePanel();
        }
    }

    void SetPlayersInScene()
    {
        if (saveDataObject.shouldLoad)
        {
            print("Loading saved player poses");
            cubePlayer.transform.position = saveDataObject.cubePlayerPosition;
            spherePlayer.transform.position = saveDataObject.spherePose.spherePlayerPosition;
            spherePlayer.transform.localEulerAngles = saveDataObject.spherePose.spherePlayerRotation;
        }
    }

    void GetCurrentStateOfPlayers()
    {
        print("Saving player poses");
        ShowSavePrompt();

        //saveDataObject.cubePlayerPosition = cubePlayer.transform.localPosition;
        //saveDataObject.spherePose.spherePlayerPosition= spherePlayer.transform.localPosition;

        saveDataObject.cubePlayerPosition = cubePlayer.transform.position;
        saveDataObject.spherePose.spherePlayerPosition = spherePlayer.transform.position;

        saveDataObject.spherePose.spherePlayerRotation = spherePlayer.transform.localEulerAngles;

        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == level1)
        {
            saveDataObject.currentLevel = LevelLocator.currentLevel.Level1;
        }
        else if(sceneName == level2)
        {
            saveDataObject.currentLevel = LevelLocator.currentLevel.Level2;
        }
        else
        {
            Debug.LogError("Scene names are not Set properly - Aditya");
        }
      
        saveDataObject.shouldLoad = true;
    }


    public void AutoSaveCheckpoint() //Archit call this for checkpoint triggers
    {
        GetCurrentStateOfPlayers();
    }

    public void showPausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void showGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    // Pause Panel
    public void ResumeGame()
    {
        Time.timeScale = 1;

    }

    public void SaveQuit()
    {
        GetCurrentStateOfPlayers();
        ExitGame();
    }
    //


    //Game Over Panel
    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    //

    public void ExitGame()
    {
        SceneManager.LoadScene(titleSceneName);
    }

    private void ShowSavePrompt()
    {
        StartCoroutine(ShowSaveCoroutine());
    }

    IEnumerator ShowSaveCoroutine()
    {
        savePanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        savePanel.gameObject.SetActive(false);

        yield break;
    }
}
