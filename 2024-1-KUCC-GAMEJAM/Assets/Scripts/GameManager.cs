using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int playerScore = 0;
    private int opponentScore = 100;

    public TextMeshProUGUI playerCount;
    public TextMeshProUGUI rivalCount;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AdjustScore(bool isPlayer, int amount)
    {
        if (isPlayer)
        {
            playerScore += amount;
            playerCount.text = "³» ´ç¼±°¡´É¼º: " + playerScore.ToString();

        }
        else
        {
            opponentScore += amount;
            rivalCount.text = "±èºÀÆÈ ´ç¼±°¡´É¼º: " + opponentScore.ToString();
        }
    }
}
