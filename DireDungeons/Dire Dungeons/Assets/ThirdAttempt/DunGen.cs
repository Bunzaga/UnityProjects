using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

namespace DunGen
{
    public class EnumFlagsAttribute : PropertyAttribute
    {
        public EnumFlagsAttribute() { }
    }

    [CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
    public class EnumFlagsAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            _property.intValue = EditorGUI.MaskField(_position, _label, _property.intValue, _property.enumNames);
        }
    }

    public static class DoorDirection
    {
        public static readonly Vector3[] Direction = new Vector3[4] {
        new Vector3(0, 0, 1),
        new Vector3(0, 0, -1),
        new Vector3(1, 0, 0),
        new Vector3(-1, 0, 0)
    };

        public static readonly Vector3[] NegDirection = new Vector3[4] {
        new Vector3(0, 0, -1),
        new Vector3(0, 0, 1),
        new Vector3(-1, 0, 0),
        new Vector3(1, 0, 0)
    };

        public static Vector3 OppositeDirection(Vector3 direction, Vector3 opposite = new Vector3())
        {
            int index = -1;
            for (int i = 0, ilen = Direction.Length; i < ilen; i++)
            {
                if (Direction[i] == direction)
                {
                    index = i;
                    break;
                }
            }

            opposite = NegDirection[index];

            return opposite;
        }
    }

    [System.Flags]
    public enum ConnectionType
    {
        Inward = 1,
        Outward = 2
    }

    public enum DungeonNodeType
    {
        Room,
        Cooridor
    }

    public enum DungeonLayout
    {
        Default,
        Straight,
        Labrynth,
        Mixed
    }

    public static class CorridorWalker
    {
        private static int _maxCorridorLength;
        private static int _currentCorridorLength;
        private static Vector3 _randomDirection;
        private static Vector3 _lastTurn;
        private static List<Vector3> _lastDirection;

        private static void BuildCorridor(Vector3 startPosition, Vector3 startDirection)
        {

        }
    }

    public static class DunGen
    {

    }
}