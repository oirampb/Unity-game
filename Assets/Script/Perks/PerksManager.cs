using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerksManager : MonoBehaviour
{


    ///<Sumary>
    /// Desactivamos del canvas la imagen de la ventaja y obtenemos el script de la ventaja que vamos a usar
    ///</Sumary>
    private void Awake()
    {
        _perk.SetActive(false);
        perk = this.gameObject.GetComponent<PerkBehaviour>();
        _costPerk.gameObject.SetActive(false);
    }

    ///<Sumary>
    /// Este es el metodo por el que se consiguen las ventajas
    ///</Sumary>

    public void GetPerk()
    {
        perk.PerkActived();
        _perk.SetActive(true);
        _costPerk.gameObject.SetActive(false);
        Destroy(this);
    }

    ///<Sumary>
    /// Si entras en el collider se te activa el texto de cuanto cuesta la ventaja.
    ///</Sumary>

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("PlayerCanvas"))
        {
            _costPerk.text = "Buy: Press F. Cost: " + _cost + " $";
            _costPerk.gameObject.SetActive(true);
        }
    }

    ///<Sumary>
    /// Si sales del collider se  desactiva el texto de cuanto cuesta la ventaja.
    ///</Sumary>

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag.Equals("PlayerCanvas"))
            _costPerk.gameObject.SetActive(false);
    }

    public int _cost = 2500;

    [SerializeField]
    private Text _costPerk;

    [SerializeField]
    private GameObject _perk;
    private PerkBehaviour perk = null;
}
