namespace FirstAttemptP
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Room
    {
        public int Length;
        public int Width;
        public GameObject RoomGO;
    }

    public static class DunGen
    {
        public static float CellSize = 3.0f;

        public static List<Room> GenerateRooms(int length, int width, int count, GameObject roomGO)
        {
            List<Room> rooms = new List<Room>();

            Vector3 hVector = new Vector3();

            for (int i = 0, ilen = count; i < count; i++)
            {
                Room room = new Room
                {
                    Width = Random.Range(2, width + 1),
                    Length = Random.Range(2, length + 1),
                    RoomGO = GameObject.Instantiate(roomGO)
                };

                room.RoomGO.transform.position = GetRandomPointInCircle(10.0f);

                hVector.x = room.Width;
                hVector.y = 1.0f;
                hVector.z = room.Length;

                room.RoomGO.transform.localScale = hVector;

                rooms.Add(room);
            }
            return rooms;
        }

        public static bool SeparateRooms(List<Room> rooms)
        {
            int overlapping = 0;

            for (int i = rooms.Count; i-- > 0;)
            {
                Room a = rooms[i];

                for (int j = rooms.Count; j-- > 0;)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    Room b = rooms[j];

                    Vector3 aPos = a.RoomGO.transform.position;
                    Vector3 bPos = b.RoomGO.transform.position;

                    // this is a positive number, the 1/2 dimension of the distance between the two objects
                    float xBuffer = (a.Width + b.Width) * CellSize;
                    float zBuffer = (a.Length + b.Length) * CellSize;

                    // this is a positive number, the raw distance between the two rooms
                    float xDistance = Mathf.Abs(aPos.x - bPos.x) * 2f;
                    float zDistance = Mathf.Abs(aPos.z - bPos.z) * 2f;

                    // if 0 or negative, they are not overlapping. positive, they are overlapping
                    float xOverlap = xBuffer - xDistance;
                    float zOverlap = zBuffer - zDistance;

                    if (xOverlap > 0 /*&& xOverlap > zOverlap*/)
                    {
                        if (Mathf.Abs(aPos.x) > Mathf.Abs(bPos.x))
                        {
                            aPos.x = RoundM((aPos.x > 0 ? bPos.x + xBuffer : bPos.x - xBuffer) * 0.5f, CellSize);
                        }
                        else
                        {
                            bPos.x = RoundM((bPos.x > 0 ? aPos.x + xBuffer : aPos.x - xBuffer) * 0.5f, CellSize);
                        }

                        overlapping++;

                        a.RoomGO.transform.position = aPos;
                        b.RoomGO.transform.position = bPos;
                    }

                    /*else if(zOverlap > 0 && zOverlap > xOverlap)
                    {
                        if (aPos.z > bPos.z)
                        {
                            aPos.z = RoundM(aPos.z - zOverlap * 0.5f, CellSize);
                            bPos.z = RoundM(bPos.z + zOverlap * 0.5f, CellSize);
                        }
                        else
                        {
                            aPos.z = RoundM(aPos.z + zOverlap * 0.5f, CellSize);
                            bPos.z = RoundM(bPos.z - zOverlap * 0.5f, CellSize);
                        }
                        overlapping++;

                        a.RoomGO.transform.position = aPos;
                        b.RoomGO.transform.position = bPos;
                    }*/
                }
            }
            if (overlapping > 0)
            {
                return true;
            }
            return false;
        }

        public static Vector3 GetRandomPointInCircle(float radius)
        {
            float t = 2f * Mathf.PI * Random.Range(0.001f, 1.0f);
            float u = Random.Range(0.001f, 1.0f) + Random.Range(0.001f, 1.0f);
            float r = 0.0f;
            r = u > 1.0f ? 2.0f - u : u;
            return new Vector3(RoundM(radius * r * Mathf.Cos(t), CellSize), 1.0f, RoundM(radius * r * Mathf.Sin(t), CellSize));
        }

        public static float RoundM(float n, float m)
        {
            return Mathf.Floor(((n + m - 1) / m)) * m;
        }
    }
}