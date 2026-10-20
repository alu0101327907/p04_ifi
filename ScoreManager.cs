using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int totalScore = 0;

    private void Awake()
    {
        // Patrón Singleton para acceso global
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddScore(int points)
    {
        totalScore += points;
        Debug.Log($"[PUNTUACIÓN] +{points} puntos | Total: {totalScore}");
    }

    public int GetScore() => totalScore;
}