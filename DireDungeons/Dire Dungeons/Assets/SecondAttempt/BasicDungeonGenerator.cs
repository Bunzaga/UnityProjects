namespace SecondAttempt
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BasicDungeonGenerator : MonoBehaviour
    {
        public DunGen.DungeonOptions DungeonOptions;

        public GameObject NoneTile;
        public GameObject BlockedTile;

        public Transform DungeonRoot;

        private void Start()
        {
            DunGen.Dungeon dungeon = DunGen.CreateDungeon(DungeonOptions);

            Vector3 posHelper = new Vector3();
            GameObject newTile = null;

            for (int r = 0, rlen = dungeon.Cell.Count; r < rlen; r++)
            {
                for (int c = 0, clen = dungeon.Cell[r].Count; c < clen; c++)
                {
                    posHelper.x = r * dungeon.CellSize;
                    posHelper.z = c * dungeon.CellSize;
                    posHelper.y = 0;

                    switch (dungeon.Cell[r][c])
                    {
                        case DunGen.None:
                            newTile = Instantiate(NoneTile, posHelper, Quaternion.identity, DungeonRoot);

                            break;

                        case DunGen.Blocked:
                            newTile = Instantiate(BlockedTile, posHelper, Quaternion.identity, DungeonRoot);
                            break;
                    }

                    newTile.name = string.Format("Cell [{0}][{1}]", r, c);
                }
            }
        }
    }
}