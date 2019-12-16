using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    ///<Sumary>
    /// Metodo que recibe el daño y el multiplicador de daño y se lo resta a la vida.
    ///</Sumary>

    public void Dmg(float dmg, float dmgRecive)
    {
        _health -= dmg * dmgRecive;
        MoneyManager.moneyManager.GetMoney((int)(dmgRecive * 10));

    }

    ///<Sumary>
    /// Update se compruba que la vida sea menor de cero, y si tiene _weaveBehaviour (ya que si lo tiene seria un enemigo).
    ///</Sumary>

    private void Update()
    {
        // Debug.Log("Health " + _health);
        if (_health <= 0 && _weaveBehaviuor != null)
        {
            // Se llama al metodo DeadEnemies para contablizar la muerte de los zombies.
            _weaveBehaviuor.DeadEnemies();
            MoneyManager.moneyManager.GetMoney(10);
            // Destruye al enemigo.
            Destroy(gameObject);
        }
    }

    public float _health = 100;

    [SerializeField]
    private WeaveBehaviour _weaveBehaviuor = null;
}
