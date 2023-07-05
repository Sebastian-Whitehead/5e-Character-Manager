using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using NUnit.Framework;
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
            (int total, List<int> rollList) = RollDice(count, size);
            total += bonus;
            return (total, rollList);
        }

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
    
        // Example formatting: 2d20,4d8,1d4+8
        // TODO: check to see if this function works as expected
        public (int, List<(int ,List<int>)>) StringToRolls(string inputString)
        {
            string[] rolls = inputString.Split('+');
            int bonus = Int32.Parse(rolls[1]);
            print($"bonus: {bonus}");
            
            inputString = rolls[0];
            rolls = inputString.Split(',');
            print($"rolls: {rolls}");
            
            List<(int, int)> rollOrder = new List<(int, int)>();
            foreach (var roll in rolls)
            {
                string[] processing = roll.Split('d');
                rollOrder.Add((Int32.Parse(processing[0]), Int32.Parse(processing[1])));
                print($"count: {Int32.Parse(processing[0])}, size: {Int32.Parse(processing[1])}");
            }
            (int, List<(int ,List<int>)>) result = RollDiceList(rollOrder, bonus);
            return (result);
        }
        
        // Includes individual bonus rolls
        // TODO: check to see if this function works as expected
        public (int, List<(int ,List<int>)>) StringToRollsv2(string inputString)
        {
            string[] rolls = inputString.Split(',');
            print($"rolls: {rolls}");
            
            List<(int, int, int)> rollOrder = new List<(int, int, int)>();
            foreach (var roll in rolls)
            {
                string[] i = roll.Split('+');
                int bonus = Int32.Parse(i[1]);
                if (!roll.Contains('+')) bonus = 0;


                string[] dice = i[0].Split('d');
                rollOrder.Add((Int32.Parse(dice[0]), Int32.Parse(dice[1]), bonus));
                print($"count: {Int32.Parse(dice[0])}, size: {Int32.Parse(dice[1])}, bonus: {bonus}");
            }
            (int, List<(int ,List<int>)>) result = RollDiceListv2(rollOrder);
            return (result);
        }
        
        //TODO: Allow for roll math in formula (/,*,-,+,'()')
       
    }
}
