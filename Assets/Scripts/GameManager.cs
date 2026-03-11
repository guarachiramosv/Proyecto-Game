using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Configuración de Colores")]
    public Camera camaraPrincipal;
    public Color colorInicialFondo;
    public Color colorMetaCélula;

    [Header("Aparición de Células")]
    public GameObject celulaPrefab;
    public float rangoX = 7f;
    public float rangoY = 4f;

    [Header("Interfaz")]
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoRonda; // <-- NUEVA VARIABLE PARA LA RONDA
    private int puntosTotales = 0;

    [Header("Lógica de Rondas")]
    private int rondaActual = 0;
    private int celulasRestantesRonda;
    public int rondasParaMimetismoTotal = 10;

    void Start()
    {
        if (camaraPrincipal != null)
            camaraPrincipal.backgroundColor = colorInicialFondo;

        // Iniciamos la primera ronda manualmente
        IniciarSiguienteRonda();
    }

    public void IniciarSiguienteRonda()
    {
        rondaActual++;

        // Actualizamos el texto de la ronda en pantalla
        if (textoRonda != null)
            textoRonda.text = "Ronda: " + rondaActual;

        int cantidadAcrear = 2 + rondaActual;
        celulasRestantesRonda = cantidadAcrear;

        float t = (float)rondaActual / rondasParaMimetismoTotal;
        camaraPrincipal.backgroundColor = Color.Lerp(colorInicialFondo, colorMetaCélula, t);

        for (int i = 0; i < cantidadAcrear; i++)
        {
            CrearNuevaCelula();
        }

        Debug.Log("Iniciando Ronda " + rondaActual + " con " + cantidadAcrear + " células.");
    }

    void CrearNuevaCelula()
    {
        if (celulaPrefab != null)
        {
            Vector3 posicionAleatoria = new Vector3(Random.Range(-rangoX, rangoX), Random.Range(-rangoY, rangoY), 0);
            GameObject nuevaCelula = Instantiate(celulaPrefab, posicionAleatoria, Quaternion.identity);

            float escalaAleatoria = Random.Range(0.4f, 1.6f);
            nuevaCelula.transform.localScale = new Vector3(escalaAleatoria, escalaAleatoria, 1);
        }
    }

    public void RegistrarMuerteCelula()
    {
        puntosTotales++;
        celulasRestantesRonda--;

        if (textoPuntos != null)
            textoPuntos.text = "Puntos: " + puntosTotales;

        if (celulasRestantesRonda <= 0)
        {
            Debug.Log("¡Ronda limpia! Siguiente nivel...");
            Invoke("IniciarSiguienteRonda", 1.2f);
        }
    }
}