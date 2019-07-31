namespace SecondAttempt
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public static class DunGen
    {

        public static Dictionary<string, List<List<int>>> DungeonLayout = new Dictionary<string, List<List<int>>>{
        { "Box", new List<List<int>> { new List<int>{1,1,1}, new List<int>{1,0,1}, new List<int>{1,1,1} } },
        { "Cross", new List<List<int>> { new List<int>{0,1,0}, new List<int> { 1, 1, 1 }, new List<int>{0,1,0} } }
    };

        public static Dictionary<string, float> CorridorLayout = new Dictionary<string, float>() {
        { "Labyrinth", 0.0f },
        { "Bent", 50.0f },
        { "Straight", 100.0f }
    };

        public static Dictionary<string, Dictionary<string, Color>> MapStyle = new Dictionary<string, Dictionary<string, Color>>{
        { "Standard", new Dictionary<string, Color>{ { "fill", Color.black }, { "open", Color.white }, { "open_grid", Color.grey } } }
    };

        public const uint None = 0x00000000;
        public const uint Blocked = 0x00000001;
        public const uint Room = 0x00000002;
        public const uint Corridor = 0x00000004;

        public const uint Perimeter = 0x00000010;
        public const uint Entrance = 0x00000020;
        public const uint Room_Id = 0x0000FFC0;

        public const uint Arch = 0x00010000;
        public const uint Door = 0x00020000;
        public const uint Locked = 0x00040000;
        public const uint Trapped = 0x00080000;
        public const uint Secret = 0x00100000;
        public const uint Portc = 0x00200000;
        public const uint Stair_Dn = 0x00400000;
        public const uint Stair_Up = 0x00800000;

        public const uint Label = 0xFF000000;

        public const uint OpenSpace = Room | Corridor;
        public const uint DoorSpace = Arch | Door | Locked | Trapped | Secret | Portc;
        public const uint EntranceSpace = Entrance | DoorSpace | Label;
        public const uint Stairs = Stair_Dn | Stair_Up;

        public const uint BlockRoom = Blocked | Room;
        public const uint BlockCorr = Blocked | Perimeter | Corridor;
        public const uint BlockDoor = Blocked | DoorSpace;

        public static Dictionary<string, int> DI = new Dictionary<string, int> { { "north", -1 }, { "south", 1 }, { "west", 0 }, { "east", 0 } };
        public static Dictionary<string, int> DJ = new Dictionary<string, int> { { "north", 0 }, { "south", 0 }, { "west", -1 }, { "east", 1 } };
        //public static Dictionary<string, int> DJDirs = (Dictionary<string, int>)(from pair in DJ orderby pair.Key ascending select pair) as Dictionary<string, int>;
        public static Dictionary<string, string> Opposite = new Dictionary<string, string> { { "north", "south" }, { "south", "north" }, { "west", "east" }, { "east", "west" } };

        public static Dictionary<string, Dictionary<string, List<List<int>>>> StairEnd = new Dictionary<string, Dictionary<string, List<List<int>>>> {
        { "north", new Dictionary<string, List<List<int>>>{
            { "walled", new List<List<int>> {
                new List<int> { 1, -1 },
                new List<int> { 0, -1 },
                new List<int> { -1, -1 },
                new List<int> { -1, 0 },
                new List<int> { -1, 1 },
                new List<int> { 0, 1 },
                new List<int> { 1, 1 } }
            },
            { "corridor", new List<List<int>>{
                new List<int>{ 0, 0 },
                new List<int>{ 1, 0 },
                new List<int>{ 2, 0 } }
            },
            { "stair", new List<List<int>>{
                new List<int> { 0, 0} }
            },
            { "next", new List<List<int>>{
                new List<int> { -1, 0} }
            } } },
        { "south", new Dictionary<string, List<List<int>>>{
            { "walled", new List<List<int>> {
                new List<int> { -1, -1 },
                new List<int> { 0, -1 },
                new List<int> { 1, -1 },
                new List<int> { 1, 0 },
                new List<int> { 1, 1 },
                new List<int> { 0, 1 },
                new List<int> { -1, 1 } }
            },
            { "corridor", new List<List<int>>{
                new List<int>{ 0, 0 },
                new List<int>{ -1, 0 },
                new List<int>{ -2, 0 } }
            },
            { "stair", new List<List<int>>{
                new List<int> { 0, 0} }
            },
            { "next", new List<List<int>>{
                new List<int> { -1, 0} }
            } } },
        { "west", new Dictionary<string, List<List<int>>>{
            { "walled", new List<List<int>> {
                new List<int> { -1, 1 },
                new List<int> { -1, 0 },
                new List<int> { -1, -1 },
                new List<int> { 0, -1 },
                new List<int> { 1, -1 },
                new List<int> { 1, 0 },
                new List<int> { 1, 1 } }
            },
            { "corridor", new List<List<int>>{
                new List<int>{ 0, 0 },
                new List<int>{ 0, 1 },
                new List<int>{ 0, 2 } }
            },
            { "stair", new List<List<int>>{
                new List<int> { 0, 0} }
            },
            { "next", new List<List<int>>{
                new List<int> { 0, 1} }
            } } },
        { "east", new Dictionary<string, List<List<int>>>{
            { "walled", new List<List<int>> {
                new List<int> { -1, -1 },
                new List<int> { -1, 0 },
                new List<int> { -1, 1 },
                new List<int> { 0, 1 },
                new List<int> { 1, 1 },
                new List<int> { 1, 0 },
                new List<int> { 1, -1 } }
            },
            { "corridor", new List<List<int>>{
                new List<int>{ 0, 0 },
                new List<int>{ 0, -1 },
                new List<int>{ 0, -2 } }
            },
            { "stair", new List<List<int>>{
                new List<int> { 0, 0} }
            },
            { "next", new List<List<int>>{
                new List<int> { 0, -1} }
            } } }
    };

        public static Dictionary<string, Dictionary<string, List<List<int>>>> CloseEnd = new Dictionary<string, Dictionary<string, List<List<int>>>> {
        { "north", new Dictionary<string, List<List<int>>>{
            { "walled", new List<List<int>> {
                new List<int> { 0, -1 },
                new List<int> { 1, -1 },
                new List<int> { 1, 0 },
                new List<int> { 1, 1 },
                new List<int> { 0, 1 } }
            },
            { "close", new List<List<int>>{
                new List<int>{ 0, 0 } }
            },
            { "recurse", new List<List<int>>{
                new List<int> { -1, 0 } }
            } } },
        { "south", new Dictionary<string, List<List<int>>>{
            { "walled", new List<List<int>> {
                new List<int> { 0, -1 },
                new List<int> { -1, -1 },
                new List<int> { -1, 0 },
                new List<int> { -1, 1 },
                new List<int> { 0, 1 } }
            },
            { "close", new List<List<int>>{
                new List<int>{ 0, 0 } }
            },
            { "recurse", new List<List<int>>{
                new List<int> { 1, 0 } }
            } } },
        { "west", new Dictionary<string, List<List<int>>>{
            { "walled", new List<List<int>> {
                new List<int> { -1, 0 },
                new List<int> { -1, 1 },
                new List<int> { 0, 1 },
                new List<int> { 1, 1 },
                new List<int> { 1, 0 } }
            },
            { "close", new List<List<int>>{
                new List<int>{ 0, 0 } }
            },
            { "recurse", new List<List<int>>{
                new List<int> { 0, -1 } }
            } } },
        { "east", new Dictionary<string, List<List<int>>>{
            { "walled", new List<List<int>> {
                new List<int> { -1, 0 },
                new List<int> { -1, -1 },
                new List<int> { 0, -1 },
                new List<int> { 1, -1 },
                new List<int> { 1, 0 } }
            },
            { "close", new List<List<int>>{
                new List<int>{ 0, 0 } }
            },
            { "recurse", new List<List<int>>{
                new List<int> { 0, 1 } }
            } } }
    };

        public static Dictionary<string, string> ColorChain = new Dictionary<string, string>{
        { "door", "fill" },
        { "label", "fill" },
        { "stair", "wall" },
        { "wall", "fill" },
        { "fill", "black" },
    };

        [System.Serializable]
        public class DungeonOptions
        {
            public int Seed = (int)DateTime.Now.Ticks;
            public int NRows = 39; // odd number
            public int NCols = 39; // odd number
            public string DungeonLayout = "None";
            public int RoomMin = 3; // min room size
            public int RoomMax = 9; // max room size
            public string RoomLayout = "Scattered"; // Packed, Scattered
            public string CorridorLayout = "Bent";
            public float RemoveDeadEnds = 50.0f; // percentage
            public int AddStairs = 2; // number of stairs
            public string MapStyle = "Standard";
            public float CellSize = 3.0f; // size of each cell
        }

        [System.Serializable]
        public class Dungeon
        {
            public float CellSize;
            public int NI;
            public int NJ;
            public int NRows;
            public int NCols;
            public int MaxRow;
            public int MaxCol;
            public int NRooms;
            public int RoomBase;
            public int RoomRadix;
            public string DungeonLayout;
            public List<List<uint>> Cell;
        }

        public static Dungeon CreateDungeon(DungeonOptions options)
        {
            Dungeon dungeon = new Dungeon { };

            dungeon.CellSize = options.CellSize;
            dungeon.NI = options.NRows / 2;
            dungeon.NJ = options.NCols / 2;
            dungeon.NRows = dungeon.NI * 2;
            dungeon.NCols = dungeon.NJ * 2;
            dungeon.MaxRow = dungeon.NRows - 1;
            dungeon.MaxCol = dungeon.NCols - 1;
            dungeon.NRooms = 0;

            int max = options.RoomMax;
            int min = options.RoomMin;

            dungeon.RoomBase = (min + 1) / 2;
            dungeon.RoomRadix = ((max - min) / 2) + 1;

            dungeon.DungeonLayout = options.DungeonLayout;

            dungeon = InitCells(dungeon);

            return dungeon;
        }

        /*
            my $opts = &get_opts();
            my $dungeon = &create_dungeon($opts);
            &image_dungeon($dungeon);
       */


        /*
            sub get_opts
            {
                my $opts = {
                    'seed'              => time(),
                    'n_rows'            => 39,          # must be an odd number
                    'n_cols'            => 39,          # must be an odd number
                    'dungeon_layout'    => 'None',
                    'room_min'          => 3,           # minimum room size
                    'room_max'          => 9,           # maximum room size
                    'room_layout'       => 'Scattered', # Packed, Scattered
                    'corridor_layout'   => 'Bent',
                    'remove_deadends'   => 50,          # percentage
                    'add_stairs'        => 2,           # number of stairs
                    'map_style'         => 'Standard',
                    'cell_size'         => 18,          # pixels
                  };
                return $opts;
            }
        */

        /*
            sub create_dungeon
            {
                my ($dungeon) = @_;
                dungeon->{'n_i'} = int($dungeon->{'n_rows'} / 2);
                $dungeon->{'n_j'} = int($dungeon->{'n_cols'} / 2);
                $dungeon->{'n_rows'} = $dungeon->{'n_i'} * 2;
                $dungeon->{'n_cols'} = $dungeon->{'n_j'} * 2;
                $dungeon->{'max_row'} = $dungeon->{'n_rows'} - 1;
                $dungeon->{'max_col'} = $dungeon->{'n_cols'} - 1;
                $dungeon->{'n_rooms'} = 0;

                my $max = $dungeon->{'room_max'};
                my $min = $dungeon->{'room_min'};
                $dungeon->{'room_base'} = int(($min + 1) / 2);
                $dungeon->{'room_radix'} = int(($max - $min) / 2) + 1;

                $dungeon = &init_cells($dungeon);
                $dungeon = &emplace_rooms($dungeon);
                $dungeon = &open_rooms($dungeon);
                $dungeon = &label_rooms($dungeon);
                $dungeon = &corridors($dungeon);
                $dungeon = &emplace_stairs($dungeon) if ($dungeon->{'add_stairs'});
                $dungeon = &clean_dungeon($dungeon);
                return $dungeon;
            }
        */



        //Rooms and corridors always fall along odd-numbered columns and rows, and rooms are always odd numbers in width and height.

        public static Dungeon InitCells(Dungeon dungeon)
        {
            dungeon.Cell = new List<List<uint>>();

            for (int r = 0, rlen = dungeon.NRows; r <= rlen; r++)
            {
                dungeon.Cell.Add(new List<uint>());
                for (int c = 0, clen = dungeon.NCols; c <= clen; c++)
                {
                    dungeon.Cell[r].Add(None);
                }
            }

            if (dungeon.DungeonLayout != "None")
            {
                if (DungeonLayout.ContainsKey(dungeon.DungeonLayout))
                {
                    dungeon = MaskCells(dungeon, DungeonLayout[dungeon.DungeonLayout]);
                }
                else
                {
                    if (dungeon.DungeonLayout == "Round")
                    {

                    }
                }
            }

            return dungeon;
        }


        // Masks the available dungeon cells to be 'blocked' if using a shape mask, such as
        // a Cross, or other such grid type mask
        public static Dungeon MaskCells(Dungeon dungeon, List<List<int>> mask)
        {
            // 1. Determine r_x and c_x based on mask size and dungeon rows and columns
            // 2. Set the cell to blocked, unless it is inside the masked grid.

            float rx = (mask.Count * (1.0f / (dungeon.NRows + 1)));
            float cx = (mask[0].Count * (1.0f / (dungeon.NCols + 1)));

            for (int r = 0, rlen = dungeon.NRows; r <= rlen; r++)
            {
                for (int c = 0, clen = dungeon.NCols; c <= clen; c++)
                {
                    dungeon.Cell[r][c] = Blocked;
                    if (mask[Mathf.FloorToInt(r * rx)][Mathf.FloorToInt(c * cx)] != 0)
                    {
                        dungeon.Cell[r][c] = None;
                    }
                }
            }

            /*

              my $r_x = (scalar @{ $mask } * 1.0 / ($dungeon->{'n_rows'} + 1));
              my $c_x = (scalar @{ $mask->[0] } * 1.0 / ($dungeon->{'n_cols'} + 1));
              my $cell = $dungeon->{'cell'};

              my $r; for ($r = 0; $r <= $dungeon->{'n_rows'}; $r++) {
                my $c; for ($c = 0; $c <= $dungeon->{'n_cols'}; $c++) {
                  $cell->[$r][$c] = $BLOCKED unless ($mask->[$r * $r_x][$c * $c_x]);
                }
              }
              return $dungeon;
            }
             * */
            return dungeon;
        }

        // Similar to MaskCells, but uses a circle, instead of a shape grid
        public static void MaskCellsRound(/*Dungeon*/)
        {
            // 1. get the center row and column
            // 2. get the radius of the row/col and if it is greater than the target radius, set it to blocked.

            /*
             sub round_mask
             {
              my ($dungeon) = @_;
              my $center_r = int($dungeon->{'n_rows'} / 2);
              my $center_c = int($dungeon->{'n_cols'} / 2);
              my $cell = $dungeon->{'cell'};

              my $r; for ($r = 0; $r <= $dungeon->{'n_rows'}; $r++) {
                my $c; for ($c = 0; $c <= $dungeon->{'n_cols'}; $c++) {
                  my $d = sqrt((($r - $center_r) ** 2) + (($c - $center_c) ** 2));
                  $cell->[$r][$c] = $BLOCKED if ($d > $center_c);
                }
              }
              return $dungeon;
            }
             * */
        }

        public static float CellSize = 3.0f;
    }
}