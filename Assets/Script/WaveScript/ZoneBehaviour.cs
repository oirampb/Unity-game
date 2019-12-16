using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBehaviour : MonoBehaviour
{

    ///<Sumary>
    /// En este metodo se selecciona un sitio aleatorio dentro de varios que elegamos e instanciamos al enemigo desde el prefab.
    ///</Sumary>

    public void Spawnzone()
    {
        GameObject.Instantiate(_zombie, _spawn[Random.Range(0, 3)].position, Quaternion.identity);
    }


    [SerializeField]
    private GameObject _zombie = null;      // Prefab de el enemigo que instanciamos.

    [SerializeField]
    private Transform[] _spawn;     // Array de puntos de spawn de los enemigos.
}
