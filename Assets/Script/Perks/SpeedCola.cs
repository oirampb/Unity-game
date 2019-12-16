using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCola : PerkBehaviour
{

    ///<Sumary>
    /// En este metodo se hace que la ventaja cuando este activa de mayor velocidad al recargar el arma
    ///</Sumary>

    public override void PerkActived()
    {
        _instantWeapon1._rechargeTime /= 2;
        _instantWeapon2._rechargeTime /= 2;
    }

    [SerializeField]
    private instantWeapon _instantWeapon1 = null;
    [SerializeField]
    private instantWeapon _instantWeapon2 = null;
}
