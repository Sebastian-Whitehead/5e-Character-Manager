using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dice_rolling
{
    public class DiceEngine: MonoBehaviour
    {
        
        /// <summary>
        /// Method <c>RollDice</c> rolls a number of dice of given size.
        /// </summary>
        /// <param name="count">number of dice</param>
        /// <param name="size">size of dice to roll</param>
        /// <returns> A roll total and list of results</returns>
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

        /// <summary>
        /// Method <c>RollDice</c> rolls a number of dice of given size and adds a bonus to the roll.
        /// </summary>
        /// <param name="count">number of dice</param>
        /// <param name="size">size of dice to roll</param>
        /// <param name="bonus">bonus to be added to roll total</param>
        /// <returns> A roll total and list of results</returns>
        public (int, List<int>) RollDice(int count, int size, int bonus)
        {
            (int total, List<int> rollList) = RollDice(count, size);
            total += bonus;
            return (total, rollList);
        }
        
        /*
        public (int, List<(int ,List<int>)>) RollDiceList(List<(int count, int size)> rolls, int bonus)
        {
            int total = 0;
            List<(int, List<int>)> resultList = new List<(int, List<int>)>();
            
            foreach (var roll in rolls)
            {
                (int resultTotal, List<int> returnedList) = RollDice(roll.count, roll.size);
                total += resultTotal;
                resultList.Add((roll.size, returnedList));
            }

            total += bonus;
            return (total, resultList);
        }
        
        public (int, List<(int ,List<int>)>) RollDiceListv2(List<(int count, int size, int bonus)> rolls)
        {
            int total = 0;
            List<(int, List<int>)> resultList = new List<(int, List<int>)>();
            
            foreach (var roll in rolls)
            {
                (int resultTotal, List<int> returnedList) = RollDice(roll.count, roll.size, roll.bonus);
                total += resultTotal;
                resultList.Add((roll.size, returnedList));
            }
            return (total, resultList);
        }
        */
    }
}
