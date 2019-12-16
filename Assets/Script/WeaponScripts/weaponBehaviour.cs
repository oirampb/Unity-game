using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class weaponBehaviour : MonoBehaviour
{
    public abstract void Shoot();
    public abstract void Recharge();
    public abstract void MostrarMunicion();
}
