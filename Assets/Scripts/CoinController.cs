using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Para poder comunicarse con otro objeto de la escena --> creamos un objeto de ese tipo y recolectamos info
            LevelManager manager = FindFirstObjectByType<LevelManager>();

            if(manager != null)
            {
                manager.collectedCoin++;
            }
            else
            {
                Debug.LogError("No se pudo contar la moneda");
            }

            Destroy(this.gameObject);
        }
        
    }
}
