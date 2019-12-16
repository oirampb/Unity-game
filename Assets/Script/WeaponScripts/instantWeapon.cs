using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class instantWeapon : weaponBehaviour
{

    ///<Sumary>
    /// Igualamos el cargadorCapacidad al cargador.
    /// cogemos el AudioSource y lo igualamos a la variable _source.
    ///</Sumary>
    private void Awake()
    {
        _cargador = _cargadorCapacidad;
        _source = GetComponent<AudioSource>();
        MostrarMunicion();
    }

    ///<Sumary>
    /// Metodo de disparar en el que se comprueba la frecuencia de tiro para que comprobar que el tiempo entre cada bala es 0.
    /// Despues se comprueba si se ha pulsado el boton de disparar configurado desde los Axes de unity.
    /// Tambien se comprueba que el cargador no sea 0 ni que se encuentre recargando.
    ///</Sumary>

    public override void Shoot()
    {
        if (_frecuencyShoot > 0f)
            _frecuencyShoot -= Time.deltaTime;
        if (Input.GetButton("Fire1") && _cargador > 0 && _recargar == false && _frecuencyShoot <= 0f)
        {
            // Igualamos la frecuencia de tiro a la frecuencia por defecto. 
            _frecuencyShoot = _frecuencyShootDefault;

            // Lanzamos un raycast  
            if (Physics.Raycast(_positionRaycast.transform.position, _positionRaycast.transform.forward, out _raycastHit, _distanceLookAt))
            {
                // Ejecutamos el sonido del disparo.
                _source.PlayOneShot(_shootSound);
                // Quitamos una bala del cargador.
                _cargador--;
                MostrarMunicion();

                // Realizamos el prefab del agujero de bala.
                GameObject impactobject = Instantiate(_impactPrefab, _raycastHit.point, Quaternion.identity);
                impactobject.transform.forward = _raycastHit.normal;
                impactobject.transform.SetParent(_raycastHit.transform, true);
                //Destruimos el prefab del agujero de la bala.
                Destroy(impactobject, 10f);
                //Comprobamos si el prefab tiene life controler si lo tiene le enviamos el daño que hace el arma
                _lifeController = _raycastHit.transform.GetComponent<LifeController>();
                if (_lifeController != null)
                    _lifeController.ReciveDmg(_dmg);
            }
        }
    }
    ///<Sumary>
    /// Metodo de recargar se comprueba que se pueda recargar,
    /// Se usa un tiempo entre la recarga y el disparo.
    ///</Sumary>

    public override void Recharge()
    {
        //Comprobamos que el cargador no este al maximo ya  y que se pulsa la tecla o el boton en caso de ser un mando. 
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            if (_cargador < _cargadorCapacidad)
            {
                // Se ejecuta el sonido de recargar.
                _source.PlayOneShot(_rechargeSound);
                // Se cambia el valor de recargar a true.
                _recargar = true;
                //igualamos el cargador al maximo de municion posible
                _cargador = _cargadorCapacidad;
                //Mostramos el cargador en la pantalla.
                MostrarMunicion();
            }
        }

        // Comprobamos si es posible recargar en caso de ser lo iniciamos un contador.
        if (_recargar == true)
            _timeRecharge += Time.deltaTime;
        // Comprobamos que el contador iniciado antes es mayor o igual que el tiempo que tarda en recargar el arma.

        if (_timeRecharge >= _rechargeTime)
        {
            //igualamos el contador a 0 y cambiamos la variable recargar a false.
            _timeRecharge = 0;
            _recargar = false;
        }
    }

    ///<Sumary>
    /// Metodo en el que se muestra la municion del arma.
    ///</Sumary>

    public override void MostrarMunicion()
    {
        _municion.text = _cargador.ToString() + "/" + _cargadorCapacidad.ToString();
    }

    public float _dmg = 11f;       // Daño que hace el arma.

    [SerializeField]
    private GameObject _impactPrefab;       // Prefab del agujero de bala.

    [SerializeField]
    private float _distanceLookAt = 500f;       // Distancia maxima de la bala.

    [SerializeField]
    private int _cargadorCapacidad = 25;        // Maxima capacidad del cargador.

    private int _cargador;      // Cargador del arma.

    public float _rechargeTime = 0.6f;     // Tiempo de recarga del arma.

    [SerializeField]
    private Transform _positionRaycast;     // Posicion desde la que se lanza el raycast.

    private float _timeRecharge;        // Tiempo que dura la recarga.

    private float _frecuencyShoot;      // Tiempo entre cada disparo.

    [SerializeField]
    private float _frecuencyShootDefault;       // Tiempo entre cada disparo por defecto.

    private bool _recargar = false;     // Booleano de no se esta recargando el arma, y se puede disparar.

    private RaycastHit _raycastHit;

    private LifeController _lifeController;     // Script de la vida de los jugadores.

    [SerializeField]
    private Text _municion;     // Municion mostrada en pantalla.

    [SerializeField]
    private AudioClip _shootSound;      // Sonido del disparo.

    [SerializeField]
    private AudioClip _rechargeSound;       // Sonido de recargar.

    private AudioSource _source;        // AudioSource.

}
