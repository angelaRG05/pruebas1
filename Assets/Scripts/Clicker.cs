using UnityEngine;

public class Clicker : MonoBehaviour
{
    // !! Aqui se inicializan las variables para el inspector
    private void Awake()
    {
       // !! Aqui se inicializan las variables para el script
    }

    private void OnMouseEnter()
    {
       // Debug.Log("raton encima de la moneda");
    }

    private void OnMouseExit()
    {
       // Debug.Log("Raton salio de la moneda");
    }

    private void OnMouseOver()
    {
       // Debug.Log("Raton sobre la moenda");
    }

    private void OnMouseDown()
    {
        Debug.Log("Has soltado la moneda");
    }

    private void OnMouseUp()
    {
        Debug.Log("Has pulsado la moneda");
        // Destroy(gameObject);
        
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

}
