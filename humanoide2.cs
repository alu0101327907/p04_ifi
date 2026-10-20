using UnityEngine;

[DisallowMultipleComponent]
public class HumanoideTipo2 : MonoBehaviour
{
    [Header("Configuración de orientación")]
    [Tooltip("Si true, gira continuamente hacia el objetivo.")]
    public bool orientacionContinua = true;

    [Tooltip("Si true, solo gira en el plano horizontal (eje Y).")]
    public bool soloY = true;

    [Tooltip("Velocidad de giro en grados/segundo. 0 = instantáneo.")]
    public float velocidadGiro = 0f;

    [Tooltip("Offset angular en Y para ajustar el 'frente' del modelo.")]
    public float offsetY = 0f;

    private Transform _objetivoActual;

    void Update()
    {
        if (orientacionContinua && _objetivoActual != null)
            OrientarHacia(_objetivoActual);
    }

    /// <summary>
    /// Fija el objetivo y (si no es continuo) orienta una sola vez.
    /// </summary>
    public void OrientarHacia(Transform objetivo)
    {
        if (objetivo == null) return;

        _objetivoActual = objetivo;

        Vector3 dir = objetivo.position - transform.position;

        if (soloY)
        {
            dir.y = 0f;
            if (dir.sqrMagnitude < 0.0001f) return;
        }

        Quaternion rotObjetivo = Quaternion.LookRotation(dir) * Quaternion.Euler(0f, offsetY, 0f);

        if (velocidadGiro <= 0f)
        {
            transform.rotation = rotObjetivo;
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                rotObjetivo,
                velocidadGiro * Time.deltaTime
            );
        }
    }

    public void DejarDeOrientar()
    {
        _objetivoActual = null;
    }
}