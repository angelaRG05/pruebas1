using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class LevelManager : MonoBehaviour
{
    [Header("Datos del nivel")]
    [TextArea(1,4)]
    public string levelName = "Nivel 1 \n\"Ve a casa de la abuela\"";
    public float time;
    [Tooltip("Veces que el jugdor a muerto")]
    public int deathCounter = 0;
    public int totalCoin;
    public int collectedCoin;
    [SerializeField]
    private bool isComplete;

    [Header("Referencias")]
    public TextMeshProUGUI txt_time;
    public TextMeshProUGUI txt_levelName;
    //public TextMeshProUGUI txt_deathCount;
    public TextMeshProUGUI txt_coinCounter;
    [Tooltip("Monedas recogidas del jugador del CoinManager")]
    public int playercoin;

    private string timeCounter()
    {
       time += Time.deltaTime;
       TimeSpan ts = TimeSpan.FromSeconds(time);
       string counter = ts.ToString(@"mm\:ss");
       return counter;
    }

    private void spawnPlayer()
    {
        throw new NotImplementedException();
    }

    void Start()
    {
        // Establecemos nombre del nivel
        txt_levelName.text = levelName;

        // Cuento las monedas totales --> contar todos los CoinManager
        totalCoin = FindObjectsByType<CoinController>(FindObjectsSortMode.None).Length;

        // Spawn player
        spawnPlayer();
        
    }
       

    void Update()
    {
        txt_time.text = timeCounter();
        txt_coinCounter.text = $"{collectedCoin} / {totalCoin}";
        //txt_deathCount.text = deathCounter.ToString();
    }
}
