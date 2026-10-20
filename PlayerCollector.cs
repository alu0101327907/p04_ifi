using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerCollector : MonoBehaviour
{
    private void Start()
    {
        // Asegurar que el collider sea trigger
        Collider col = GetComponent<Collider>();
        if (col != null) col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que chocamos es un escudo
        Shield shield = other.GetComponent<Shield>();
        
        if (shield != null)
        {
            Debug.Log($"¡Colisión detectada con: {other.gameObject.name}!");
            shield.Collect();
        }
    }
}