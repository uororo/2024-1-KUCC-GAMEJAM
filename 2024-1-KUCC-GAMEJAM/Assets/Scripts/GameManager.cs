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
            playerCount.text = "내 당선가능성: " + playerScore.ToString();

        }
        else
        {
            opponentScore += amount;
            rivalCount.text = "상대방 당선가능성: " + opponentScore.ToString();
        }
    }
}
