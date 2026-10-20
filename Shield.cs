using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Configuración del Escudo")]
    [Tooltip("Tipo 1 = 5 puntos, Tipo 2 = 10 puntos")]
    [Range(1, 2)]
    public int shieldType = 1;

    private int pointValue;

    private void Start()
    {
        // Asignar valor según el tipo
        pointValue = (shieldType == 1) ? 5 : 10;
    }

    public int GetPointValue() => pointValue;

    // Método que se llama cuando el jugador recoge el escudo
    public void Collect()
    {
        Debug.Log($"Escudo tipo {shieldType} recolectado (+{pointValue} pts)");
        ScoreManager.Instance.AddScore(pointValue);
        Destroy(gameObject);
    }
}