using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    bool isCubeTriggered, isSphereTriggered;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
            SceneManager.LoadScene(GameManager.gameManagerInstance.level2);
        }
        else
        {
            GameManager.gameManagerInstance.showGameOverPanel();
        }
        

       
    }
}
