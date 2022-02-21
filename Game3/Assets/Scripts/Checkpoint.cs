using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    bool isCubeTriggered, isSphereTriggered;

    [SerializeField]
    GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CubePlayer") && !isCubeTriggered)
        {
            isCubeTriggered = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("SpherePlayer") && !isSphereTriggered)
        {
            isSphereTriggered = true;
            Destroy(other.gameObject);
        }

        if (isCubeTriggered && isSphereTriggered)
        {
            TriggerCheckpoint();
        }
    }

    private void TriggerCheckpoint()
    {

        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == GameManager.gameManagerInstance.level1)
        {
            gameManager.ResetPosLev2();
            SceneManager.LoadScene(GameManager.gameManagerInstance.level2);
        }
        else
        {
            gameManager.ResetPosLev1();
            GameManager.gameManagerInstance.showGameOverPanel();
        }
        

       
    }
}
