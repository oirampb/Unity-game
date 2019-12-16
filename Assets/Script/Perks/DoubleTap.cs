using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTap : PerkBehaviour
{

    ///<Sumary>
    /// En este metodo se da mas daño a las armas cuando este activa la ventaja
    ///</Sumary>

    public override void PerkActived()
    {
        _instantWeapon1._dmg *= 2;
        _instantWeapon2._dmg *= 2;
    }

    [SerializeField]
    private instantWeapon _instantWeapon1 = null;
    [SerializeField]
    private instantWeapon _instantWeapon2 = null;
}
