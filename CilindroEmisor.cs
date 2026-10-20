using UnityEngine;

public class CilindroEmisor : MonoBehaviour
{
    public static event System.Action OnColisionCubo;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cubo"))
        {
            Debug.Log("Cilindro: colisión con cubo detectada");
            OnColisionCubo?.Invoke(); // Envía el mensaje a todos los suscriptores
        }
    }
}