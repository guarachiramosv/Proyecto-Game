using UnityEngine;

public class MovimientoCelula : MonoBehaviour
{
    public float velocidad = 2f;
    public float rangoX = 7f;
    public float rangoY = 4f;

    private Vector2 puntoDestino;

    void Start()
    {
        ElegirNuevoDestino();
    }

    void Update()
    {
        // Mover la célula hacia el destino
        transform.position = Vector2.MoveTowards(transform.position, puntoDestino, velocidad * Time.deltaTime);

        // Si llega al destino, elige otro
        if (Vector2.Distance(transform.position, puntoDestino) < 0.1f)
        {
            ElegirNuevoDestino();
        }
    }

    void ElegirNuevoDestino()
    {
        puntoDestino = new Vector2(Random.Range(-rangoX, rangoX), Random.Range(-rangoY, rangoY));
    }
}