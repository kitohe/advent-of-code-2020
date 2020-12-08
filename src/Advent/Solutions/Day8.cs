using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advent.Solutions.Helper;

namespace Advent.Solutions
{
    public class Day8 : ISolution
    {
        private const string FilePath = "../../../../../data/day8_data.txt";

        private int _accumulator;
        private int _programCounter;
        private readonly HashSet<int> _instructionsExecuted;
        public Day8()
        {
            _instructionsExecuted = new HashSet<int>();
        }

        public async Task Solve()
        {
            var lines = await FileOperations.ReadAllLines(FilePath);
            
            RunProgram(lines);
            Console.WriteLine($"[DAY 8] Answer for part 1 is: {_accumulator}");
            
            BruteForce(lines);
            Console.WriteLine($"[DAY 8] Answer for part 2 is:: {_accumulator}");
        }

        private void BruteForce(string[] instructions)
        {
            string[] localInstructions = new string[instructions.Length];
            for (int i = 0; i < instructions.Length; i++)
            {
                instructions.CopyTo(localInstructions, 0);
                _instructionsExecuted.Clear();
                _accumulator = 0;
                _programCounter = 0;
                
                if (localInstructions[i].StartsWith("nop"))
                    localInstructions[i] = "jmp" + localInstructions[i].Substring(3);
                else if (localInstructions[i].StartsWith("jmp"))
                    localInstructions[i] = "nop" + localInstructions[i].Substring(3);
                else
                    continue;
                
                if (RunProgram(localInstructions))
                    return;
            }
        }
        
        private bool RunProgram(string[] instructions)
        {
            if (instructions.Length == 0)
                return false;

            while(_programCounter < instructions.Length)
            {
                var instruction = instructions[_programCounter].Split(" ")[0];
                var operand = int.Parse(instructions[_programCounter].Split(" ")[1].Substring(1));
                var sign = instructions[_programCounter].Split(" ")[1].Substring(0, 1);

                if (_instructionsExecuted.Contains(_programCounter))
                    return false;

                _instructionsExecuted.Add(_programCounter);
                
                ProcessInstruction(instruction, operand, sign);
            }
            
            return true;
        }

        private void ProcessInstruction(string instruction, int operand, string sign)
        {
            switch (instruction)
            {
                case "nop":
                {
                    _programCounter++;
                    break;
                }
                case "jmp":
                {
                    if (sign == "+")
                        _programCounter += operand;
                    else
                        _programCounter -= operand;
                    break;
                }
                case "acc":
                {
                    if (sign == "+")
                        _accumulator += operand;
                    else
                        _accumulator -= operand;

                    _programCounter++;
                    break;
                }
            }
        }
    }
}
