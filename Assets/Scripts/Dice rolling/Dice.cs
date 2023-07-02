using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Random = UnityEngine.Random;

namespace Dice_rolling
{
    public class Dice : MonoBehaviour
    {
        // Normal Dice roll
        public (int, List<int>) RollDice(int count, int size)
        {
            int total = 0;
            List<int> rollList = new List<int>();

            for (int i = 0; i < count; i++)
            {
                int roll = Random.Range(1, size);
                total += roll;
                rollList.Add(roll);
            }

            return (total, rollList);
        }

        // Normal Dice roll - bonus
        public (int, List<int>) RollDice(int count, int size, int bonus)
        {
            int total = 0;
            List<int> rollList = new List<int>();

            for (int i = 0; i < count; i++)
            {
                int roll = Random.Range(1, size);
                total += roll;
                rollList.Add(roll);
            }

            total += bonus;
            return (total, rollList);
        }
    }
}
