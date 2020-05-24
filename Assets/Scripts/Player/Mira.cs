using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    public Texture2D CrosshairTexture;
    public float tamanhoMira;
    private Rect Position;

    private void OnGUI()
    {
        Position = new Rect(Screen.width / 2 - (CrosshairTexture.width * tamanhoMira * 0.5f), Screen.height / 2 - (CrosshairTexture.height * tamanhoMira * 0.5f), CrosshairTexture.width * tamanhoMira, CrosshairTexture.height * tamanhoMira);
        GUI.DrawTexture(Position, CrosshairTexture);
    }
    // Update is called once per frame
    public void SetTamMira(float Spread)
    {
        tamanhoMira = Spread / 20;
    }
}
