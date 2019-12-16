using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{

    ///<Sumary>
    /// Metodo que recive el daño y le pasa el multiplicador de daño.
    ///</Sumary>

    public void ReciveDmg(float dmg)
    {
        _lifeManager.Dmg(dmg, _dmgRecive);
    }

    [SerializeField]
    private LifeManager _lifeManager = null;

    [SerializeField]
    private float _dmgRecive = 1f;      // Multiplicador de daño.


}
