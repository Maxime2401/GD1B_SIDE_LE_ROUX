using UnityEngine;
using UnityEngine.UI;


public class Inventaire : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    public static Inventaire instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddCoins(int count) // permet d'ajouter les goutes en UI
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }
    
}