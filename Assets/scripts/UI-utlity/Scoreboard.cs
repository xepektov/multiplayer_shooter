using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Scoreboard : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform container;
    [SerializeField] GameObject scoreboardItemPrefab;
    [SerializeField] CanvasGroup canvasGroup;
    public Dictionary<Player,ScoreboardItem> scoreboardItemsDic = new Dictionary<Player,ScoreboardItem>();
    // Start is called before the first frame update
    void Start()
    {
        
        foreach(Player player in PhotonNetwork.PlayerList)
        {
            addScoreboardItem(player);
        }
    }

    void addScoreboardItem(Player player)
    {
        ScoreboardItem item = Instantiate(scoreboardItemPrefab, container).GetComponent<ScoreboardItem>();
        item.initialize(player);
        scoreboardItemsDic[player] = item;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        addScoreboardItem(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        removeScoreboardItem(otherPlayer);
    }

    void removeScoreboardItem(Player otherPlayer)
    {
        Destroy(scoreboardItemsDic[otherPlayer].gameObject);
        scoreboardItemsDic.Remove(otherPlayer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvasGroup.alpha = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            canvasGroup.alpha = 0;
        }
    }
}
