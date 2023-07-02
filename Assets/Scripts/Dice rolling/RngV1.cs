using System.Collections.Generic;
using UnityEngine;

namespace Dice_rolling
{
    public class RngV1 : MonoBehaviour
    {

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
    }
}
