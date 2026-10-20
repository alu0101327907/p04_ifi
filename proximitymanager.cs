using System.Collections.Generic;
using UnityEngine;

public class CubeProximityManager : MonoBehaviour
{
    [Header("Detección de proximidad (3D)")]
    [Tooltip("El cubo que se aproxima / cae.")]
    public Transform cubo;

    [Tooltip("Cilindro usado como objeto de referencia.")]
    public Transform cilindro;

    [Tooltip("Distancia 3D a la que se dispara todo.")]
    public float umbralDistancia = 1.5f;

    [Tooltip("Si true, solo se dispara una vez.")]
    public bool dispararUnaSolaVez = true;

    [Header("Grupo 1 — Teletransporte")]
    public List<HumanoideTipo1> grupo1 = new List<HumanoideTipo1>();
    public Transform escudoObjetivo;

    [Header("Grupo 2 — Orientación")]
    public List<HumanoideTipo2> grupo2 = new List<HumanoideTipo2>();
    public Transform objetoTarget;

    private bool _yaDisparado = false;

    void Update()
    {
        if (cubo == null || cilindro == null) return;

        float dist = Vector3.Distance(cubo.position, cilindro.position);

        if (dist <= umbralDistancia && (!dispararUnaSolaVez || !_yaDisparado))
            Disparar();
    }

    void Disparar()
    {
        _yaDisparado = true;
        Debug.Log($"[Manager] Disparo a distancia {Vector3.Distance(cubo.position, cilindro.position):F2}");

        if (escudoObjetivo != null)
        {
            foreach (var h in grupo1)
                if (h != null) h.TeletransportarA(escudoObjetivo);
        }
        else Debug.LogWarning("[Manager] Falta escudoObjetivo.");

        if (objetoTarget != null)
        {
            foreach (var h in grupo2)
                if (h != null) h.OrientarHacia(objetoTarget);
        }
        else Debug.LogWarning("[Manager] Falta objetoTarget.");
    }

    public void Reiniciar()
    {
        _yaDisparado = false;
        foreach (var h in grupo1) if (h != null) h.Reiniciar();
        foreach (var h in grupo2) if (h != null) h.DejarDeOrientar();
    }

    // Gizmo para ver el radio de 1.5 en la Scene view
    void OnDrawGizmosSelected()
    {
        if (cilindro == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(cilindro.position, umbralDistancia);
    }
}