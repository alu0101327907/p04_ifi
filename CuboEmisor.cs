using UnityEngine;

public class CuboEmisor : MonoBehaviour
{
    public static event System.Action OnCuboColisionaTipo2; // cubo toca humanoide tipo2
    public static event System.Action OnCuboColisionaTipo1; // cubo toca humanoide tipo1

    private void OnCollisionEnter(Collision collision)
    {
        HumanoideReceptor h = collision.gameObject.GetComponent<HumanoideReceptor>();
        if (h == null) return;

        if (h.tipo == HumanoideReceptor.TipoHumanoide.Tipo2)
            OnCuboColisionaTipo2?.Invoke();
        else
            OnCuboColisionaTipo1?.Invoke();
    }

    // Versión trigger por si el cubo se configura como trigger
    private void OnTriggerEnter(Collider other)
    {
        HumanoideReceptor h = other.GetComponent<HumanoideReceptor>();
        if (h == null) return;

        if (h.tipo == HumanoideReceptor.TipoHumanoide.Tipo2)
            OnCuboColisionaTipo2?.Invoke();
        else
            OnCuboColisionaTipo1?.Invoke();
    }
}