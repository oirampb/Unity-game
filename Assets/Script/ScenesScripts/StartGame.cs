using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    ///<Sumary>
    /// Comprobamos en el Update si se pulsa alguna tecla para pasar la escena.
    ///</Sumary>

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(GameScene);
        }
    }

    [SerializeField]
    private string GameScene;
}
