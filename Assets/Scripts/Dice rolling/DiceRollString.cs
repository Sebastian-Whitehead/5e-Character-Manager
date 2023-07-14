using System;
using System.Collections.Generic;
using UnityEngine;
using Dice_rolling;

namespace Dice_rolling
{
    
    public class DiceRollString : DiceEngine
    {
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

                //Packing value for roll list function.
                string[] dice = i[0].Split('d');
                rollOrder.Add((Int32.Parse(dice[0]), Int32.Parse(dice[1]), bonus));
                print($"count: {Int32.Parse(dice[0])}, size: {Int32.Parse(dice[1])}, bonus: {bonus}");
            }
            (int, List<(int ,List<int>)>) result = RollDiceListv2(rollOrder);
            return (result);
        }
        
        /*TODO: Implement a math expression engine
         (https://medium.com/@toptensoftware/writing-a-simple-math-expression-engine-in-c-d414de18d4ce)
          - include dice rolling implementation with □d□
          - include min[val1:val2] max[val1:val2]
          on top of standard ()+-*÷ operators
        */
    }
}
