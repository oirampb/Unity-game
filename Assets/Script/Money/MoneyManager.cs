using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{

    ///<Sumary>
    /// Iniciamos las variables del script y se muestra en el canvas el dinero del jugador.
    ///</Sumary>

    private void Awake()
    {
        // _money = 0;
        _moneyManager = this;
        moneyText.text = "$ " + _money.ToString();
    }

    ///<Sumary>
    /// En el Update llamamos al metodo de comprar ventajas y cambiamos el texto del dinero
    ///</Sumary>

    private void Update()
    {
        moneyText.text = "$ " + _money.ToString();
        BuyPerks();
    }

    ///<Sumary>
    /// En este meto se aumenta el dienro del personaje al dar a un enemigo
    ///</Sumary>

    public void GetMoney(int money)
    {
        _money += money;
    }

    ///<Sumary>
    /// En este metodo se realiza la accion de comprar las ventajas si se tiene dinero
    ///</Sumary>

    public void BuyPerks()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(_positionRaycast.transform.position, _positionRaycast.transform.forward, out _raycastHit, _distanceLookAt))
            {
                Debug.Log("ray");
                _perksManager = _raycastHit.transform.GetComponent<PerksManager>();
                if (_perksManager != null)
                {
                    int cost = _perksManager._cost;
                    if (_money >= cost)
                    {
                        _money -= cost;
                        _perksManager.GetPerk();
                    }
                    else
                    {
                        Debug.Log("no money");
                    }
                }
                else
                {
                    Debug.Log("null");
                    return;
                }
            }
        }
    }

    [SerializeField]
    private int _money;
    [SerializeField]
    private Transform _positionRaycast;

    public static MoneyManager moneyManager
    {
        get { return _moneyManager; }
    }

    private static MoneyManager _moneyManager;

    [SerializeField]
    private Text moneyText;

    private RaycastHit _raycastHit;
    private PerksManager _perksManager;

    [SerializeField]
    private float _distanceLookAt = 5f;

}
