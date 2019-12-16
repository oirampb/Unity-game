using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggernog : PerkBehaviour
{
    ///<Sumary>
    /// Se duplica la vida cuando la ventaja este activa
    ///</Sumary>

    public override void PerkActived()
    {
        _player._health *= 2;
        playerBehaviour.currentHealth = _player._health;
    }


    [SerializeField]
    private LifeManager _player;

    [SerializeField]
    private PlayerBehaviour playerBehaviour;
}
