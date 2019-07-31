using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SphoidColorSheet
{
    public ColorType ColorType;
    public List<Sprite> BaseSprites = new List<Sprite>();
    public List<Sprite> SubTwoWaySprites = new List<Sprite>();
    public List<Sprite> SubThreeWaySprites = new List<Sprite>();
    public List<Sprite> SubFourWaySprites = new List<Sprite>();
}

[CreateAssetMenu(fileName = "SphoidTileSheet", menuName = "SphoidTileSheet")]
public class SphoidTileSheet : ScriptableObject
{
    public List<SphoidColorSheet> ColorSheet = new List<SphoidColorSheet>();

    private static SphoidTileSheet _instance = null;

    public static void SetInstance(SphoidTileSheet sphoidTileSheet)
    {
        _instance = sphoidTileSheet;
    }

    public static Sprite GetSprite(ColorType colorType, int tileType, int subTileType)
    {
        if (_instance == null)
        {
            return null;
        }
        return _instance._GetSprite(colorType, tileType, subTileType);
    }

    private Sprite _GetSprite(ColorType colorType, int tileType, int subTileType)
    {
        int colorIndex = (int)colorType;

        if (colorIndex >= ColorSheet.Count)
        {
            Debug.LogFormat("ColorType {0} too high, not in ColorSheet.", colorIndex);
            return null;
        }
        SphoidColorSheet colorSheet = ColorSheet[colorIndex];
        if (colorSheet.ColorType != colorType)
        {
            Debug.LogFormat("ColorType mismatch. Color {0} does not match colorSheet {1}.", colorType, colorSheet.ColorType);
            return null;
        }

        Sprite sprite = null;

        // this is a 'normal' tile type, no sub types
        if (subTileType == 0)
        {
            if (tileType >= colorSheet.BaseSprites.Count)
            {
                Debug.LogFormat("colorSheet.BaseSprites does not contain tileType[{0}]", tileType);
                return null;
            }
            return colorSheet.BaseSprites[tileType];
        }

        switch (tileType)
        {
            case 3:
                if(subTileType == 1)
                {
                    return colorSheet.SubTwoWaySprites[0];
                }
                break;
            case 6:
                if (subTileType == 2)
                {
                    return colorSheet.SubTwoWaySprites[1];
                }
                break;
            case 7:
                switch (subTileType)
                {
                    case 1:
                        return colorSheet.SubThreeWaySprites[0];
                    case 2:
                        return colorSheet.SubThreeWaySprites[1];
                    case 3:
                        return colorSheet.SubThreeWaySprites[2];
                }
                break;
            case 9:
                if (subTileType == 8)
                {
                    return colorSheet.SubTwoWaySprites[2];
                }
                break;
            case 11:
                switch (subTileType)
                {
                    case 1:
                        return colorSheet.SubThreeWaySprites[3];
                    case 8:
                        return colorSheet.SubThreeWaySprites[4];
                    case 9:
                        return colorSheet.SubThreeWaySprites[5];
                }
                break;
            case 12:
                if (subTileType == 4)
                {
                    return colorSheet.SubTwoWaySprites[3];
                }
                break;
            case 13:
                switch (subTileType)
                {
                    case 4:
                        return colorSheet.SubThreeWaySprites[6];
                    case 8:
                        return colorSheet.SubThreeWaySprites[7];
                    case 12:
                        return colorSheet.SubThreeWaySprites[8];
                }
                break;
            case 14:
                switch (subTileType)
                {
                    case 2:
                        return colorSheet.SubThreeWaySprites[9];
                    case 4:
                        return colorSheet.SubThreeWaySprites[10];
                    case 6:
                        return colorSheet.SubThreeWaySprites[11];
                }
                break;
            case 15:
                if (subTileType - 1 >= colorSheet.SubFourWaySprites.Count)
                {
                    Debug.LogFormat("colorSheet.SubFourWaySprites does not contain tileType[{0}]", subTileType - 1);
                    return null;
                }
                return colorSheet.SubFourWaySprites[subTileType - 1];

        }

        Debug.LogFormat("Tile [{0}][{1}] does not exist!", tileType, subTileType);
        return null;
    }
}