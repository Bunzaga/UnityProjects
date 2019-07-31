namespace FirstAttemptP
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BasicDungeonGenerator : MonoBehaviour
    {

        public GameObject TempRoom;

        public int Length;
        public int Width;
        public int Count;

        List<Room> rooms;

        // Start is called before the first frame update
        void Start()
        {
            rooms = DunGen.GenerateRooms(Length, Width, Count, TempRoom);
            StartCoroutine(SeparateRooms());
        }

        private IEnumerator SeparateRooms()
        {
            while (DunGen.SeparateRooms(rooms))
            {
                yield return new WaitForEndOfFrame();
            }
            Debug.Log("Done");
        }
    }
}