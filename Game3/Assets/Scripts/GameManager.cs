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

    

    private void Awake()
    {
        gameManagerInstance = this;
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void ResumeGame()
    {
        Time.timeScale = 1;

    }

    public void showPausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void showGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(titleSceneName);
    }
}
