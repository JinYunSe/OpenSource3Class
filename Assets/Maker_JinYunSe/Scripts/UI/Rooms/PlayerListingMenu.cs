using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;

    [SerializeField]
    private PlayerListing _playerListing;

    private List<PlayerListing> _listings = new List<PlayerListing>();

    private void Awake()
    {
        GetCurrentRoomPlayers();
    }

    private void GetCurrentRoomPlayers()
    {
        foreach(KeyValuePair<int,Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    private void AddPlayerListing(Player player)
    {
        PlayerListing listing = Instantiate(_playerListing, _content);
        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            _listings.Add(listing);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }
}
