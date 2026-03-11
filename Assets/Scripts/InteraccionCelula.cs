using UnityEngine;

public class InteraccionCelula : MonoBehaviour
{
    // Esta es la función que conectamos al Event Trigger
    public void Matar()
    {
        // Buscamos el GameManager
        GameManager gm = Object.FindAnyObjectByType<GameManager>();

        if (gm != null)
        {
            gm.RegistrarMuerteCelula();
        }

        Debug.Log("¡Célula eliminada!");
        Destroy(gameObject);
    }

    // Mantenemos este por si usas el sistema antiguo o el Raycaster de la cámara
    private void OnMouseDown()
    {
        Matar();
    }
}