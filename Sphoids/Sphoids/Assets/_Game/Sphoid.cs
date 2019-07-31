using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphoid
{
    public GameObject GameObject;
    public Image Image;
    public RectTransform Transform;
    public Cell Cell;

    public ColorType ColorType = ColorType.Default;

    public int TileType = 0;
    public int SubTileType = 0;

    public void SetSphoidSprite(Sprite sprite)
    {
        this.Image.sprite = sprite;
    }

    public void SetCell(Cell cell)
    {
        this.Cell = cell;
    }

    public void SetPosition(Vector3 vector3)
    {
        this.Transform.localPosition = vector3;
    }

    public void UpdateListeners()
    {
        if (Cell.SphoidListeners[this.Cell] != null)
        {
            Cell.SphoidListeners[this.Cell].Invoke(this.Cell);
        }
    }
}

public enum ColorType
{
    Default,
    Red,
    Blue,
    Green,
}
