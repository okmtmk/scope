using System.Collections.Generic;
using UnityEngine;

namespace src.positions
{
    public class MovingKey
    {
        /*
         * 静的要素
         */

        private static readonly Dictionary<KeyCode, MovingKey> Dictionary
            = new Dictionary<KeyCode, MovingKey>();

        public static readonly MovingKey Forward = new MovingKey(KeyCode.W, 0, 1);
        public static readonly MovingKey Right = new MovingKey(KeyCode.D, 1, 0);
        public static readonly MovingKey Left = new MovingKey(KeyCode.A, -1, 0);
        public static readonly MovingKey Back = new MovingKey(KeyCode.S, 0, -1);

        /*
         * 動的要素
         */

        public readonly KeyCode KeyCode;
        private readonly Vector2 _vector2;

        private MovingKey(KeyCode keyCode, float x, float y)
        {
            KeyCode = keyCode;
            _vector2 = new Vector2(x, y);

            Dictionary.Add(keyCode, this);
        }

        /*
         * キャラクターを動かすキー入力を受け取る
         */
        public static List<MovingKey> Get()
        {
            var list = new List<MovingKey>();

            if (Input.GetKey(Forward.KeyCode))
            {
                list.Add(Forward);
            }

            if (Input.GetKey(Right.KeyCode))
            {
                list.Add(Right);
            }

            if (Input.GetKey(Back.KeyCode))
            {
                list.Add(Back);
            }

            if (Input.GetKey(Left.KeyCode))
            {
                list.Add(Left);
            }

            return list;
        }

        /*
         * 動く座標量を算出する
         */
        public static Vector2 GetMovingDirection()
        {
            var list = Get();

            var vector2 = new Vector2();

            list.ForEach(key => { vector2 += key._vector2; });

            return vector2;
        }
    }
}