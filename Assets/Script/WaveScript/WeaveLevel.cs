using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaveLevel : MonoBehaviour
{

    public abstract void Spawn();

    public abstract void Setup();

    public abstract void Begining();

    public abstract void Run();

    public abstract void End();

    public int _rounds = 1;
}
