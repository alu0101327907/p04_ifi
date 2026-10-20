using UnityEngine;

public class HumanoideReceptor : MonoBehaviour
{
    public enum TipoHumanoide { Tipo1, Tipo2 }

    [Header("Configuración")]
    public TipoHumanoide tipo;
    public Transform escudoObjetivo;   // Se asigna en el Inspector
    public float velocidad = 3f;

    private bool moviendo = false;
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        // Cada humanoide se suscribe SOLO al evento que le corresponde
        if (tipo == TipoHumanoide.Tipo1)
            CuboEmisor.OnCuboColisionaTipo2 += CallbackTipo1;
        else
            CuboEmisor.OnCuboColisionaTipo1 += CallbackTipo2;
    }

    private void OnDisable()
    {
        if (tipo == TipoHumanoide.Tipo1)
            CuboEmisor.OnCuboColisionaTipo2 -= CallbackTipo1;
        else
            CuboEmisor.OnCuboColisionaTipo1 -= CallbackTipo2;
    }

    // Grupo 1: el cubo ha tocado un humanoide tipo2 -> van al escudo seleccionado
    private void CallbackTipo1() => moviendo = true;

    // Grupo 2: el cubo ha tocado un humanoide tipo1 -> van a los escudos tipo2 (físicos)
    private void CallbackTipo2() => moviendo = true;

    private void Update()
    {
        if (!moviendo || escudoObjetivo == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position, escudoObjetivo.position, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, escudoObjetivo.position) < 0.05f)
            moviendo = false;
    }

    // --- Colisión con un escudo: cambia de color ---
    private void OnCollisionEnter(Collision collision)
    {
        EscudoReceptor e = collision.gameObject.GetComponent<EscudoReceptor>();
        if (e != null) CambiarColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        EscudoReceptor e = other.GetComponent<EscudoReceptor>();
        if (e != null) CambiarColor();
    }

    private void CambiarColor()
    {
        if (rend == null) return;
        rend.material.color = Random.ColorHSV();
    }
}