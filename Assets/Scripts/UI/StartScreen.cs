using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            SceneManager.LoadScene(1);
    }
}
