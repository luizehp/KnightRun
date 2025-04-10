using UnityEngine;
using UnityEngine.SceneManagement;


public class UImanager : MonoBehaviour
{
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (GameConstroller.GameOver)
        {
            SceneManager.LoadScene(2);
        }
    }
}

