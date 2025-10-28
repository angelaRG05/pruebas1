using UnityEngine;

public class CuentaTiempo : MonoBehaviour
{
    public int frames = 0;
    public int fixedFrames = 0;
    public int lateFrames = 0;
    public float health;
    private void Update()
    {
        // Debug.Log("Tiempo desde el fotograma anterior: " + Time.deltaTime);
        frames++;
    }
    private void FixedUpdate()
    {
        Debug.Log("Tiempo desde el fotograma anterior: " + Time.fixedDeltaTime);
        fixedFrames++;
    }

    private void LateUpdate()
    {
        lateFrames++;
    }

    private void OnTriggerStay2D(Collider other)
    {
        health = health -1*Time.deltaTime; // resta 1pto de vida por segunda --> DeltaTime

    }


}
