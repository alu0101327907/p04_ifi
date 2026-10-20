using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float speed = 5f;

    private void Update()
    {
        // Leer input del teclado (WASD o flechas)
        float horizontal = Input.GetAxis("Horizontal"); // A/D o ←/→
        float vertical = Input.GetAxis("Vertical");     // W/S o ↑/↓

        // Crear el vector de dirección
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        // Mover el personaje
        transform.Translate(direction * speed * Time.deltaTime);
    }
}