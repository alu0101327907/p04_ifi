using UnityEngine;

public class EscudoReceptor : MonoBehaviour
{
    public enum TipoEscudo { Tipo1, Tipo2 }
    public TipoEscudo tipo;

    [Header("Físico")]
    public bool esFisico = false;   // true para escudos tipo2

    private void Awake()
    {
        if (esFisico)
        {
            var rb = GetComponent<Rigidbody>();
            if (rb == null) rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = true;          // los escudos tipo2 son físicos
        }
    }
}