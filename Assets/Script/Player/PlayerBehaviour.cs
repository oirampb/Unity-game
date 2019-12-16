using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    ///<Sumary>
    /// Configuramos las variables del script
    ///</Sumary>

    private void Awake()
    {
        // Igualamos el arma 1 al arma que se esta usando.
        _weaponBehaviour = _weaponBehaviour1;
        // Pasamos la posicion del player
        _player = this.transform;
        _lifeManager = _lifeManager.GetComponent<LifeManager>();
        // Se desactiva el render de la segunda arma 
        _gameObject2.SetActive(false);
        _healthtext.text = _lifeManager._health.ToString() + "%";
    }

    ///<Sumary>
    /// En el update conprobamos el cambio de arma.
    /// Y llamamos al resto de metodos.
    ///</Sumary>

    private void Update()
    {
        //comprobamos que se ha hecho el cambio de arma y creamos un contador.
        if (_change == false)
            _time += Time.deltaTime;
        // Comprobamos que el contador anterior supera al tiempo de cambio de arma para poder poder disparar o recargar.
        if (_time >= _timeToChange)
            _change = true;
        // Llamamos al metodo de cambiar de arma
        ChangeGun();
        // Comprobamos si ya se ha hecho el cambio de arma y llamamos al metodo de disparar y recargar del arma. 
        if (_change == true)
        {
            _weaponBehaviour.Shoot();
            _weaponBehaviour.Recharge();
        }
        // Llamamos al metodo perder.
        LoseGame();
        _healthtext.text = _lifeManager._health.ToString() + "%";
    }

    ///<Sumary>
    /// Metodo en el que cambiamos de un arma a otra.
    ///</Sumary>

    private void ChangeGun()
    {
        // Comprobamos que se pulsa la tecla o el boton de cambiar a la primera arma (1 o triangulo)
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            //Igualamos el arma que se esta usando al arma 1.
            _weaponBehaviour = _weaponBehaviour1;
            // Desactivamos el render del arma 2.
            _gameObject2.SetActive(false);
            // Activamos el render del arma 1.
            _gameObject1.SetActive(true);
            // Se muestra la municion del arma al la que se cambia.
            _weaponBehaviour.MostrarMunicion();
            _time = 0;
            _change = false;
        }
        // Comprobamos que se pulsa la tecla o el boton de cambiar a la sugunda arma (1 o circulo)
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Joystick1Button1) && _weaponBehaviour2 != null)
        {
            //Igualamos el arma que se esta usando al arma 2.
            _weaponBehaviour = _weaponBehaviour2;
            // Desactivamos el render del arma 1.
            _gameObject1.SetActive(false);
            // Activamos el render del arma 2.
            _gameObject2.SetActive(true);
            // Se muestra la municion del arma al la que se cambia.
            _weaponBehaviour.MostrarMunicion();
            _time = 0;
            _change = false;
        }
    }

    ///<Sumary>
    /// Metodo con el que se devuelve la vida a 100 al usuario al terminar cada ronda.
    ///</Sumary>

    public void Health()
    {
        _lifeManager._health = currentHealth;
        _healthtext.text = _lifeManager._health.ToString() + "%";
    }

    ///<Sumary>
    /// Metodo en el que si la vida del jugador es menor que 0 se cambia de escena y se termina la partida. 
    ///</Sumary>

    private void LoseGame()
    {
        if (_lifeManager._health <= 0f)
            _sceneManagent.EndGame();
    }

    ///<Sumary>
    /// Comprobamos si un la cabeza de los zombies estan dentro de nuestro area de recivir daño y si lo esta le restamos vida.
    ///</Sumary>

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag.Equals("Head"))
        {
            // Creamos un contador para que el jugador no reciva daño constantemente.
            _timeToReciveDamage -= Time.deltaTime;
            if (_timeToReciveDamage <= 0)
            {
                // Enviamos el daño que recive al LifeController
                _lifeController.ReciveDmg(25f);
                _healthtext.text = _lifeManager._health.ToString() + "%";
                // Igualamos el tiempo entre recivir daño al tiempo entre golpes.
                _timeToReciveDamage = 0.25f;
            }
        }
    }

    ///<Sumary>
    /// 
    ///</Sumary>

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag.Equals("Head"))
        {
            _timeToReciveDamage = 0.35f;
        }
    }

    ///<Sumary>
    /// Comprobamos si se entra en una zona de muerte
    ///</Sumary>

    private void OnTriggerEnter(Collider collider)
    {
        // Comprobamos si el jugador entra en el collider de muerte y cambiamos termina la partida
        if (collider.tag.Equals("Dead"))
        {
            weaveBehaviour.ResetGame();
            _sceneManagent.EndGame();
        }
    }

    private float _timeToChange = 0.5f;

    private float _time;

    public float currentHealth = 100;

    private bool _change = true;

    [SerializeField]
    private weaponBehaviour _weaponBehaviour1 = null;

    [SerializeField]
    private weaponBehaviour _weaponBehaviour2 = null;

    private weaponBehaviour _weaponBehaviour;

    [SerializeField]
    private GameObject _gameObject1 = null;

    [SerializeField]
    private GameObject _gameObject2 = null;

    private float _timeToReciveDamage = 0.35f;
    [SerializeField]
    private LifeController _lifeController = null;
    [SerializeField]
    private LifeManager _lifeManager = null;

    ///<Sumary>
    /// Pasamos la posicion del player con el singelton.
    ///</Sumary>
    public static Transform Player
    {
        get { return _player; }
    }

    private static Transform _player;

    [SerializeField]
    private SceneManagent _sceneManagent = null;

    [SerializeField]
    private WeaveBehaviour weaveBehaviour = null;

    [SerializeField]
    private Text _healthtext = null;

}
