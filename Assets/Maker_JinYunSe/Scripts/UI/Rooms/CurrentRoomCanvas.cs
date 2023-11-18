using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    private RoomsCanvaes _roomsCanvases;

    public void FirstInitialize(RoomsCanvaes canvases)
    {
        _roomsCanvases = canvases;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
