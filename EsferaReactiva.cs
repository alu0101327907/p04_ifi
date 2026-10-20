using UnityEngine;

public class EsferaReactiva : MonoBehaviour
{
    public enum TipoEsfera { Tipo1, Tipo2 }

    [Header("Configuración")]
    public TipoEsfera tipo;
    public Transform esferaObjetivo;   // Esfera verde a la que persiguen las Tipo1
    public Transform cilindro;         // Referencia al cilindro
    public float velocidad = 3f;

    private bool moviendo = false;

    private void OnEnable()  => CilindroEmisor.OnColisionCubo += OnMensajeCilindro;
    private void OnDisable() => CilindroEmisor.OnColisionCubo -= OnMensajeCilindro;

    private void OnMensajeCilindro()
    {
        if (tipo == TipoEsfera.Tipo1)
            CallbackTipo1();
        else
            CallbackTipo2();
    }

    private void CallbackTipo1() => moviendo = true;   // perseguirá en cada Update
    private void CallbackTipo2() => moviendo = true;   // irá hacia el cilindro

    private void Update()
    {
        if (!moviendo) return;

        Vector3 destino;

        if (tipo == TipoEsfera.Tipo1)
        {
            if (esferaObjetivo == null) return;
            // Lee la posición ACTUAL de la verde -> persecución en tiempo real
            destino = esferaObjetivo.position;
        }
        else
        {
            if (cilindro == null) return;
            destino = cilindro.position;
        }

        transform.position = Vector3.MoveTowards(
            transform.position, destino, velocidad * Time.deltaTime);

        // Solo las Tipo2 paran al llegar (el cilindro es estático).
        // Las Tipo1 no paran porque su objetivo se mueve.
        if (tipo == TipoEsfera.Tipo2 &&
            Vector3.Distance(transform.position, destino) < 0.05f)
        {
            moviendo = false;
        }
    }
}