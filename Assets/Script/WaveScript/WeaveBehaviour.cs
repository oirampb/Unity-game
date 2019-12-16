using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaveBehaviour : WeaveLevel
{

    ///<Sumary>
    /// Usamos el Awake para que se iniciamos los enemigos de las oleadas
    ///</Sumary>
    private void Awake()
    {
        _lifeManager._health = 100;
        _roundsZombies = 8;
        _livesZombies = 0;
        _restRoundsZombies = 8;
        _prefabZombies = 0;
        _reset = true;
    }
    ///<Sumary>
    /// En el start mostramos el número de rondas en pantalla he igualamos reset a true 
    ///</Sumary>

    private void Start()
    {
        _roundsText.text = _rounds.ToString();
        _reset = true;
    }

    ///<Sumary>
    /// En el Update mostramos en consola las variables que queremos ver.
    /// También comprobamos que se cumplen los parametros para que se ejecuten los estados de la ronda.
    ///</Sumary>

    private void Update()
    {
        Debug.Log("_rounds" + _rounds + "_prefabZombies " + _prefabZombies + "_livesZombies " + _livesZombies + "_roundsZombies " + _roundsZombies + "_restRoundsZombies " + _restRoundsZombies);
        if (_reset == true)
        {
            _reset = false;
            Setup();
        }
        if (_timeToNextRound > 0f && _restRoundsZombies == 0)
            End();
        else
        {
            Run();
        }
    }

    ///<Sumary>
    /// Metodo que se usa para que se reinicien las oleadas al reiniciar despues de morir
    ///</Sumary>

    public void ResetGame()
    {
        _rounds = 1;
        _reset = true;
    }

    ///<Sumary>
    /// En el Setup cambiamos el número de la ronda al actual. 
    /// Se aumenta el número de los zombies en la ronda.
    /// Se iguala el número de zombies que quedan y al número de zombies de la ronda.
    /// Se iguala el número de zombies instanciados a 0.
    /// Al terminar el proceso se llama al Begining para que se realice el siguiente estado.
    ///</Sumary>

    public override void Setup()
    {
        Debug.Log("setup");
        //configurar ronda
        if (_rounds > 1)
        {
            _roundsText.text = _rounds.ToString();
            _roundsZombies = _roundsZombies + _roundsZombies;
            _lifeManager._health += 50f;
            Debug.Log(_lifeManager._health);
        }
        _restRoundsZombies = _roundsZombies;
        _prefabZombies = 0;

        Begining();
    }

    ///<Sumary>
    /// Se realiza el spawn de los zombies. 
    ///</Sumary>

    public override void Begining()
    {
        Debug.Log("Begining");
        //Empezar ronda
        Spawn();
    }

    ///<Sumary>
    /// Se ejecuta el estado de run y se llama al spawn para que si mueren los zombies sigan saliendo siempre que queden zombies por spawnear en esa ronda.
    ///</Sumary>

    public override void Run()
    {
        Debug.Log("run");
        //jugar hasta que se acaben los enemigos de esa ronda 
        Spawn();

    }

    ///<Sumary>
    /// Se ejecuta si no quedan zombies en la ronda.
    /// Se espera un tiempo de 5 segundos para que pase a la siguiente ronda.
    /// Antes de que termine la ronda se suma una ronda a la que estabamos. 
    /// Se devuelve el maximo de la vida al jugador.
    ///</Sumary>

    public override void End()
    {
        //Terminar la ronda
        Debug.Log("end");
        _timeToNextRound -= Time.deltaTime;
        if (_timeToNextRound <= 0f)
        {
            _rounds++;
            _timeToNextRound = 5f;
            _playerBehaviour.Health();
            _reset = true;
        }
    }

    ///<Sumary>
    /// Se spawnean zombies siempre que queden zombies en esa ronda y no haya mas de 24 zombies en la escena.
    ///</Sumary>

    public override void Spawn()
    {
        while (_prefabZombies < _roundsZombies && _livesZombies < 24)
        {
            //Spawn de los zombies
            _zoneBehaviour.Spawnzone();
            _prefabZombies++;
            _livesZombies++;
        }
    }

    ///<Sumary>
    /// Usamos este metodo para que cuando mueran los zombies se reste de los zombies vivos y que quedan en la ronda.
    ///</Sumary>

    public void DeadEnemies()
    {
        _livesZombies--;
        _restRoundsZombies--;
    }

    [SerializeField]
    private Text _roundsText;       // Número de la ronda actual mostrado en la pantalla. 

    private static int _prefabZombies = 0, _livesZombies = 0, _roundsZombies = 8, _restRoundsZombies;       // Número de zombies que usamos para poder cambiar de estados.

    private static float _timeToNextRound = 5f;     // Tiempo que hay entre las rondas.

    private static bool _reset = true;      // Booleano que se usa para reiniciar el ciclo de los estados.

    [SerializeField]
    private PlayerBehaviour _playerBehaviour = null;        // Script del player que usamos para reiniciar la vida.

    [SerializeField]
    private ZoneBehaviour _zoneBehaviour = null;        // Script de las zonas de spawn.

    [SerializeField]
    private LifeManager _lifeManager = null;

}
