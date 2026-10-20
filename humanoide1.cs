using UnityEngine;

[DisallowMultipleComponent]
public class HumanoideTipo1 : MonoBehaviour
{
    [Header("Configuración de teletransporte")]
    [Tooltip("Offset respecto al escudo para no solaparse.")]
    public Vector3 offsetEscudo = Vector3.zero;

    [Tooltip("Si true, copia la rotación del escudo al teletransportar.")]
    public bool copiarRotacion = true;

    [Tooltip("Efecto opcional al teletransportarse (partículas, sonido...).")]
    public GameObject efectoTeletransporte;

    private bool _teletransportado = false;

    /// <summary>
    /// Teletransporta al humanoide a la posición del escudo indicado.
    /// </summary>
    public void TeletransportarA(Transform escudo)
    {
        if (escudo == null)
        {
            Debug.LogWarning($"[{name}] Escudo nulo, no se teletransporta.");
            return;
        }

        // Efecto en la posición original
        if (efectoTeletransporte != null)
            Instantiate(efectoTeletransporte, transform.position, transform.rotation);

        transform.position = escudo.position + offsetEscudo;

        if (copiarRotacion)
            transform.rotation = escudo.rotation;

        // Efecto en la nueva posición
        if (efectoTeletransporte != null)
            Instantiate(efectoTeletransporte, transform.position, transform.rotation);

        _teletransportado = true;
    }

    public bool YaTeletransportado => _teletransportado;

    public void Reiniciar()
    {
        _teletransportado = false;
    }
}