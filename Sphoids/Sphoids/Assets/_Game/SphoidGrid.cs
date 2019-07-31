using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphoidGrid : MonoBehaviour
{
    public GameObject SphoidPrefab;

    // Grid[ROW][COL]
    public List<List<Cell>> Grid = new List<List<Cell>>();

    public int ColCount = 10;
    public int RowCount = 20;
    public int CellSize = 1;

    private Vector3 _v3Helper = new Vector3();

    private Queue<Sphoid> _sphoidQueue = new Queue<Sphoid>();
    private List<Sphoid> _activeSphoid = new List<Sphoid>();

    public SphoidTileSheet SphoidTileSheet;

    public Button RegenerateButton;
    public Button PlayDownButton;

    private Coroutine _playDown = null;

    private float _bottomLine = 0.0f;

    private void Start()
    {
        SphoidTileSheet.SetInstance(SphoidTileSheet);

        GenerateCells();
        RegenerateButton.onClick.AddListener(GenerateRandomSphoids);
        PlayDownButton.onClick.AddListener(StartStopPlayDown);
    }

    private void GenerateRandomSphoids()
    {
        // populate cells with random sphoids
        for (int row = 0, rowLen = Grid.Count; row < rowLen; row++)
        {
            for (int col = 0, colLen = Grid[row].Count; col < colLen; col++)
            {
                Sphoid sphoid = Grid[row][col].Sphoid;
                if (sphoid != null)
                {
                    RecycleSphoid(sphoid);
                }
            }
        }

        for (int row = 0, rowLen = Grid.Count; row < rowLen; row++)
        {
            for (int col = 0, colLen = Grid[row].Count; col < colLen; col++)
            {

                Sphoid sphoid = GetSphoid();
                Grid[row][col].Sphoid = sphoid;

                sphoid.GameObject.name = string.Format("Sphoid [{0},{1}]", row, col);

                GetCellPosition(col, row, ref _v3Helper);
                sphoid.SetPosition(_v3Helper);

                float rnd = Random.Range(0f, 1.0f);
                if (rnd < 0.333f)
                {
                    sphoid.ColorType = ColorType.Red;
                }
                else if (rnd < 0.666f)
                {
                    sphoid.ColorType = ColorType.Blue;
                }
                else
                {
                    sphoid.ColorType = ColorType.Green;
                }

                sphoid.SetCell(Grid[row][col]);



                sphoid.GameObject.SetActive(true);
            }
        }
        for (int row = 0, rowLen = Grid.Count; row < rowLen; row++)
        {
            for (int col = 0, colLen = Grid[row].Count; col < colLen; col++)
            {
                Sphoid sphoid = Grid[row][col].Sphoid;
                sphoid.UpdateListeners();
            }
        }
        _bottomLine = Grid[0][0].Sphoid.Transform.localPosition.y - CellSize;
    }

    private void StartStopPlayDown()
    {
        if (_playDown != null)
        {
            StopCoroutine(_playDown);
            _playDown = null;
            return;
        }
        _playDown = StartCoroutine(PlayDownLoop());
    }

    private IEnumerator PlayDownLoop()
    {
        Sphoid sphoid = null;

        while (true)
        {
            for (int row = 0, rowLen = RowCount; row < rowLen; row++)
            {
                for (int col = 0, colLen = ColCount; col < colLen; col++)
                {
                    sphoid = Grid[row][col].Sphoid;
                    if (sphoid != null)
                    {
                        _v3Helper = sphoid.Transform.localPosition;
                        _v3Helper.y -= Time.deltaTime * 400f;
                        Grid[row][col].Sphoid.Transform.localPosition = _v3Helper;
                    }
                }
            }

            if (Grid[0][0].Sphoid.Transform.localPosition.y <= _bottomLine)
            {
                // move all rows down, and generate new sphoids for top
                float topY = Grid[RowCount - 1][0].Sphoid.Transform.localPosition.y + CellSize;
                for (int col = 0, colLen = Grid[0].Count; col < colLen; col++)
                {
                    sphoid = Grid[0][col].Sphoid;
                    if (sphoid != null)
                    {
                        RecycleSphoid(sphoid);
                        sphoid.UpdateListeners();
                    }
                }

                int lastRow = lastRow = Grid.Count - 1;
                for (int row = 0, rowLen = Grid.Count; row < rowLen; row++)
                {
                    if (row < lastRow)
                    {
                        for (int col = 0, colLen = Grid[row].Count; col < colLen; col++)
                        {
                            Grid[row][col].Sphoid = Grid[row + 1][col].Sphoid;
                            Grid[row][col].Sphoid.SetCell(Grid[row][col]);
                        }
                    }
                }

                for (int col = 0, colLen = Grid[lastRow].Count; col < colLen; col++)
                {
                    sphoid = Grid[lastRow][col].Sphoid;
                    Grid[lastRow][col].Sphoid = null;
                    sphoid.UpdateListeners();
                }

                for (int col = 0, colLen = Grid[lastRow].Count; col < colLen; col++)
                {
                    sphoid = GetSphoid();
                    Grid[lastRow][col].Sphoid = sphoid;

                    GetCellPosition(col, lastRow, ref _v3Helper);
                    _v3Helper.y = topY;
                    sphoid.SetPosition(_v3Helper);

                    float rnd = Random.Range(0f, 1.0f);
                    if (rnd < 0.333f)
                    {
                        sphoid.ColorType = ColorType.Red;
                    }
                    else if (rnd < 0.666f)
                    {
                        sphoid.ColorType = ColorType.Blue;
                    }
                    else
                    {
                        sphoid.ColorType = ColorType.Green;
                    }

                    sphoid.SetCell(Grid[lastRow][col]);

                    sphoid.UpdateListeners();

                    sphoid.GameObject.SetActive(true);
                }

                for (int col = 0, colLen = Grid[lastRow].Count; col < colLen; col++)
                {
                    sphoid = Grid[lastRow][col].Sphoid;
                    sphoid.UpdateListeners();
                }

            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void GenerateCells()
    {
        for (int row = 0, rowLen = RowCount; row < rowLen; row++)
        {
            Grid.Add(new List<Cell>());
            for (int col = 0, colLen = ColCount; col < colLen; col++)
            {
                Grid[row].Add(new Cell { Grid = Grid, X = col, Y = row });
            }
        }
    }

    private Sphoid GetSphoid()
    {
        Sphoid sphoid = null;

        if (_sphoidQueue.Count > 0)
        {
            sphoid = _sphoidQueue.Dequeue();
        }
        else
        {
            sphoid = GenerateSphoid();
        }
        return sphoid;
    }

    private Sphoid GenerateSphoid()
    {
        GameObject sphoidGO = Instantiate(SphoidPrefab);
        Sphoid sphoid = new Sphoid
        {
            ColorType = ColorType.Default,
            Cell = null,
            GameObject = sphoidGO,
            Image = sphoidGO.GetComponent<Image>(),
            Transform = sphoidGO.GetComponent<RectTransform>()
        };

        _v3Helper.x = 96f;
        _v3Helper.y = 96f;
        _v3Helper.z = 0f;

        sphoid.Transform.sizeDelta = _v3Helper;

        sphoid.Transform.SetParent(transform, false);
        sphoid.Transform.localScale = Vector3.one;
        sphoid.GameObject.name = "Sphoid";
        sphoid.GameObject.SetActive(false);

        return sphoid;
    }

    private void RecycleSphoid(Sphoid sphoid)
    {
        _activeSphoid.Remove(sphoid);
        sphoid.GameObject.SetActive(false);
        _v3Helper.x = -100000f;
        _v3Helper.y = -100000f;
        _v3Helper.z = 0f;
        sphoid.TileType = 0;
        sphoid.SubTileType = 0;
        sphoid.Transform.localPosition = _v3Helper;
        sphoid.Cell.Sphoid = null;
        sphoid.ColorType = ColorType.Default;
        Sprite sprite = SphoidTileSheet.GetSprite(ColorType.Default, 0, 0);
        sphoid.SetSphoidSprite(sprite);
        _sphoidQueue.Enqueue(sphoid);
    }

    private void GetCellPosition(int x, int y, ref Vector3 pos)
    {
        pos.x = Mathf.RoundToInt(CellSize + (x * CellSize));
        pos.y = Mathf.RoundToInt(CellSize + (y * CellSize));
        pos.z = 0;
    }
}

public class Cell
{
    public List<List<Cell>> Grid = null;
    public Sphoid Sphoid = null;
    public int X; // col
    public int Y; // row

    public static Dictionary<Cell, System.Action<Cell>> SphoidListeners = new Dictionary<Cell, System.Action<Cell>>();

    // grid [row][col]
    public void SetCellListeners()
    {
        int row = Y;
        int col = X;
        int dirsToCheck = 0;

        // less than highest row
        if (row < Grid.Count - 1)
        {
            dirsToCheck |= 1;
        }
        // greater than lowest row
        if (row > 0)
        {
            dirsToCheck |= 4;
        }
        // less than farthest right
        if (col < Grid[row].Count - 1)
        {
            dirsToCheck |= 2;
        }
        // greater than farthest left
        if (col > 0)
        {
            dirsToCheck |= 8;
        }

        if ((dirsToCheck & 1) == 1)
        {
            Cell cell = Grid[row + 1][col];
            System.Action<Cell> cellAction = null;
            SphoidListeners.TryGetValue(cell, out cellAction);
            if (cellAction == null)
            {
                SphoidListeners.Add(cell, cellAction);
            }
            SphoidListeners[cell] += CheckCell_1;
        }

        if ((dirsToCheck & 2) == 2)
        {
            Cell cell = Grid[row][col + 1];
            System.Action<Cell> cellAction = null;
            SphoidListeners.TryGetValue(cell, out cellAction);
            if (cellAction == null)
            {
                SphoidListeners.Add(cell, cellAction);
            }
            SphoidListeners[cell] += CheckCell_2;
        }

        if ((dirsToCheck & 3) == 3)
        {
            Cell cell = Grid[row + 1][col + 1];
            System.Action<Cell> cellAction = null;
            SphoidListeners.TryGetValue(cell, out cellAction);
            if (cellAction == null)
            {
                SphoidListeners.Add(cell, cellAction);
            }
            SphoidListeners[cell] += CheckCell_3;
        }

        if ((dirsToCheck & 4) == 4)
        {
            Cell cell = Grid[row - 1][col];
            System.Action<Cell> cellAction = null;
            SphoidListeners.TryGetValue(cell, out cellAction);
            if (cellAction == null)
            {
                SphoidListeners.Add(cell, cellAction);
            }
            SphoidListeners[cell] += CheckCell_4;
        }

        if ((dirsToCheck & 6) == 6)
        {
            Cell cell = Grid[row - 1][col + 1];
            System.Action<Cell> cellAction = null;
            SphoidListeners.TryGetValue(cell, out cellAction);
            if (cellAction == null)
            {
                SphoidListeners.Add(cell, cellAction);
            }
            SphoidListeners[cell] += CheckCell_6;
        }

        if ((dirsToCheck & 8) == 8)
        {
            Cell cell = Grid[row][col - 1];
            System.Action<Cell> cellAction = null;
            SphoidListeners.TryGetValue(cell, out cellAction);
            if (cellAction == null)
            {
                SphoidListeners.Add(cell, cellAction);
            }
            SphoidListeners[cell] += CheckCell_8;
        }

        if ((dirsToCheck & 9) == 9)
        {
            Cell cell = Grid[row + 1][col - 1];
            System.Action<Cell> cellAction = null;
            SphoidListeners.TryGetValue(cell, out cellAction);
            if (cellAction == null)
            {
                SphoidListeners.Add(cell, cellAction);
            }
            SphoidListeners[cell] += CheckCell_9;
        }

        if ((dirsToCheck & 12) == 12)
        {
            Cell cell = Grid[row - 1][col - 1];
            System.Action<Cell> cellAction = null;
            SphoidListeners.TryGetValue(cell, out cellAction);
            if (cellAction == null)
            {
                SphoidListeners.Add(cell, cellAction);
            }
            SphoidListeners[cell] += CheckCell_12;
        }
    }

    private void CheckCell_1(Cell cell)
    {
        if (this.Sphoid == null)
        {
            if (cell.Sphoid != null)
            {
                cell.Sphoid.TileType &= ~4;
            }
            return;
        }

        if (cell.Sphoid == null)
        {
            if (this.Sphoid != null)
            {
                this.Sphoid.TileType &= ~1;
            }
        }
        else
        {
            if (this.Sphoid.ColorType == cell.Sphoid.ColorType)
            {
                this.Sphoid.TileType |= 1;
                cell.Sphoid.TileType |= 4;
            }
        }

        this.Sphoid.SubTileType = 0;
        CheckSubType(ref this.Sphoid);

        Sprite sprite = SphoidTileSheet.GetSprite(this.Sphoid.ColorType, this.Sphoid.TileType, this.Sphoid.SubTileType);
        this.Sphoid.SetSphoidSprite(sprite);

    }

    private void CheckCell_2(Cell cell)
    {
        if (this.Sphoid == null)
        {
            if (cell.Sphoid != null)
            {
                cell.Sphoid.TileType &= ~8;
            }
            return;
        }

        if (cell.Sphoid == null)
        {
            if (this.Sphoid != null)
            {
                this.Sphoid.TileType &= ~2;
            }
        }
        else
        {
            if (this.Sphoid.ColorType == cell.Sphoid.ColorType)
            {
                this.Sphoid.TileType |= 2;
                cell.Sphoid.TileType |= 8;
            }
        }

        this.Sphoid.SubTileType = 0;
        CheckSubType(ref this.Sphoid);

        Sprite sprite = SphoidTileSheet.GetSprite(this.Sphoid.ColorType, this.Sphoid.TileType, this.Sphoid.SubTileType);
        this.Sphoid.SetSphoidSprite(sprite);

    }

    private void CheckCell_3(Cell cell)
    {
        if (this.Sphoid == null) { return; }

        this.Sphoid.SubTileType = 0;
        CheckSubType(ref this.Sphoid);

        Sprite sprite = SphoidTileSheet.GetSprite(this.Sphoid.ColorType, this.Sphoid.TileType, this.Sphoid.SubTileType);
        this.Sphoid.SetSphoidSprite(sprite);
    }

    private void CheckCell_4(Cell cell)
    {
        if (this.Sphoid == null)
        {
            if (cell.Sphoid != null)
            {
                cell.Sphoid.TileType &= ~1;
            }
            return;
        }

        if (cell.Sphoid == null)
        {
            if (this.Sphoid != null)
            {
                this.Sphoid.TileType &= ~4;
            }
        }
        else
        {
            if (this.Sphoid.ColorType == cell.Sphoid.ColorType)
            {
                this.Sphoid.TileType |= 4;
                cell.Sphoid.TileType |= 1;
            }
        }

        this.Sphoid.SubTileType = 0;
        CheckSubType(ref this.Sphoid);

        Sprite sprite = SphoidTileSheet.GetSprite(this.Sphoid.ColorType, this.Sphoid.TileType, this.Sphoid.SubTileType);
        this.Sphoid.SetSphoidSprite(sprite);
    }

    private void CheckCell_6(Cell cell)
    {
        if (this.Sphoid == null) { return; }

        this.Sphoid.SubTileType = 0;
        CheckSubType(ref this.Sphoid);

        Sprite sprite = SphoidTileSheet.GetSprite(this.Sphoid.ColorType, this.Sphoid.TileType, this.Sphoid.SubTileType);
        this.Sphoid.SetSphoidSprite(sprite);
    }

    private void CheckCell_8(Cell cell)
    {
        if (this.Sphoid == null)
        {
            if (cell.Sphoid != null)
            {
                cell.Sphoid.TileType &= ~2;
            }
            return;
        }

        if (cell.Sphoid == null)
        {
            if (this.Sphoid != null)
            {
                this.Sphoid.TileType &= ~8;
            }
        }
        else
        {
            if (this.Sphoid.ColorType == cell.Sphoid.ColorType)
            {
                this.Sphoid.TileType |= 8;
                cell.Sphoid.TileType |= 2;
            }
        }

        this.Sphoid.SubTileType = 0;
        CheckSubType(ref this.Sphoid);

        Sprite sprite = SphoidTileSheet.GetSprite(this.Sphoid.ColorType, this.Sphoid.TileType, this.Sphoid.SubTileType);
        this.Sphoid.SetSphoidSprite(sprite);

    }

    private void CheckCell_9(Cell cell)
    {
        if (this.Sphoid == null) { return; }

        this.Sphoid.SubTileType = 0;
        CheckSubType(ref this.Sphoid);

        Sprite sprite = SphoidTileSheet.GetSprite(this.Sphoid.ColorType, this.Sphoid.TileType, this.Sphoid.SubTileType);
        this.Sphoid.SetSphoidSprite(sprite);
    }

    private void CheckCell_12(Cell cell)
    {
        if (this.Sphoid == null) { return; }

        this.Sphoid.SubTileType = 0;
        CheckSubType(ref this.Sphoid);

        Sprite sprite = SphoidTileSheet.GetSprite(this.Sphoid.ColorType, this.Sphoid.TileType, this.Sphoid.SubTileType);
        this.Sphoid.SetSphoidSprite(sprite);
    }

    private void CheckSubType(ref Sphoid sphoidSelf)
    {
        switch (sphoidSelf.TileType)
        {
            case 3: // aboveRight
                CheckAndSetAboveRight(ref sphoidSelf);
                break;
            case 6: // belowRight
                CheckAndSetBelowRight(ref sphoidSelf);
                break;
            case 7:
                // aboveRight
                CheckAndSetAboveRight(ref sphoidSelf);
                // belowRight
                CheckAndSetBelowRight(ref sphoidSelf);
                break;
            case 9: // aboveLeft
                CheckAndSetAboveLeft(ref sphoidSelf);
                break;
            case 11:
                // aboveRight
                CheckAndSetAboveRight(ref sphoidSelf);
                // aboveLeft
                CheckAndSetAboveLeft(ref sphoidSelf);
                break;
            case 12: // belowLeft
                CheckAndSetBelowLeft(ref sphoidSelf);
                break;
            case 13:
                // belowLeft
                CheckAndSetBelowLeft(ref sphoidSelf);
                // aboveLeft
                CheckAndSetAboveLeft(ref sphoidSelf);
                break;
            case 14:
                // belowRight
                CheckAndSetBelowRight(ref sphoidSelf);
                // belowLeft
                CheckAndSetBelowLeft(ref sphoidSelf);
                break;
            case 15:
                // aboveRight
                CheckAndSetAboveRight(ref sphoidSelf);
                // belowRight
                CheckAndSetBelowRight(ref sphoidSelf);
                // belowLeft
                CheckAndSetBelowLeft(ref sphoidSelf);
                // aboveLeft
                CheckAndSetAboveLeft(ref sphoidSelf);
                break;
        }
    }
    //1
    private void CheckAndSetAboveRight(ref Sphoid self)
    {
        if (self.Cell.Y < Grid.Count - 1 && self.Cell.X < Grid[self.Cell.Y].Count - 1)
        {
            Sphoid other = Grid[self.Cell.Y + 1][self.Cell.X + 1].Sphoid;
            if (other != null)
            {
                if (other.ColorType == self.ColorType)
                {
                    self.SubTileType |= 1;
                }
            }
        }
    }
    //2
    private void CheckAndSetBelowRight(ref Sphoid self)
    {
        if (self.Cell.Y > 0 && self.Cell.X + 1 < Grid[self.Cell.Y].Count)
        {
            Sphoid other = Grid[self.Cell.Y - 1][self.Cell.X + 1].Sphoid;
            if (other != null)
            {
                if (other.ColorType == self.ColorType)
                {
                    self.SubTileType |= 2;
                }
            }
        }
    }
    //4
    private void CheckAndSetBelowLeft(ref Sphoid self)
    {
        if (self.Cell.Y > 0 && self.Cell.X > 0)
        {
            Sphoid other = Grid[self.Cell.Y - 1][self.Cell.X - 1].Sphoid;
            if (other != null)
            {
                if (other.ColorType == self.ColorType)
                {
                    self.SubTileType |= 4;
                }
            }
        }
    }
    //8
    private void CheckAndSetAboveLeft(ref Sphoid self)
    {
        if (self.Cell.Y + 1 < Grid.Count && self.Cell.X > 0)
        {
            Sphoid other = Grid[self.Cell.Y + 1][self.Cell.X - 1].Sphoid;
            if (other != null)
            {
                if (other.ColorType == self.ColorType)
                {
                    self.SubTileType |= 8;
                }
            }
        }
    }
}

public enum TileMask
{
    None = 0,
    Above = 1,
    Right = 2,
    Below = 4,
    Left = 8,
}

public enum SubTileMask
{
    None = 0,
    AboveRight = 1,
    BelowRight = 2,
    BelowLeft = 4,
    AboveLeft = 8
}