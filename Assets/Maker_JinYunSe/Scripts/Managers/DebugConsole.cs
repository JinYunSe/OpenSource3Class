using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour
{
    [SerializeField]
    private GameObject _textFrame;
    [SerializeField]
    private int _maxLength = 500;
    [SerializeField]
    private Text _text;

    private void Awake()
    {
        AddText("Debug console is runnig.");
    }

    public void AddText(string text, UnityEngine.Object obj = null)
    {
        Debug.Log(text, obj);
        _text.text = text + Environment.NewLine + _text.text;
        if(_text.text.Length > _maxLength)
            _text.text = _text.text.Substring(0, _maxLength / 2);
    }
    public void OnClick_Button()
    {
        _textFrame.SetActive(!_textFrame.activeSelf);
    }
}
