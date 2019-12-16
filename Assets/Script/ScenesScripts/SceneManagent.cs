using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagent : MonoBehaviour
{

    ///<Sumary>
    /// Cambiamos la escena del juego a la escena del final de este.
    ///</Sumary>

    public void EndGame()
    {
        SceneManager.LoadScene(EndScene);

    }

    [SerializeField]
    private string EndScene;
    [SerializeField]
    private WeaveBehaviour weaveBehaviour = null;

}
