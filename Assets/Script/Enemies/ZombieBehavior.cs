using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieBehavior : MonoBehaviour
{

    ///<Sumary>
    /// Metodo en el que se configura la velocidad del zombie y se obtiene la posicion del jugador.
    ///</Sumary>

    private void Awake()
    {
        _agent.speed = _speed;
        _target = PlayerBehaviour.Player;
    }

    ///<Sumary>
    /// Ejecutamos siempre el movimiento del zombie.
    ///</Sumary>

    private void Update()
    {
        ZombieMove();
    }

    ///<Sumary>
    /// Pasamos la localizacion del player como el target del zombie. 
    ///</Sumary>

    private void ZombieMove()
    {
        _agent.SetDestination(_target.position);
    }

    private Transform _target;

    [SerializeField]
    private NavMeshAgent _agent;

    [SerializeField]
    private float _speed = 0.5f;

}
