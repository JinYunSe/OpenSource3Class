using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;
    [SerializeField]
    private RoomListingsMenu _roomListingsMenu;

    private RoomsCanvaes _roomCanvas;

    public void FirstInitialize(RoomsCanvaes canvases)
    {
        _roomCanvas = canvases;
        _createRoomMenu.FirstInitialize(canvases);
        _roomListingsMenu.FirstInitialize(canvases);
    }
}
