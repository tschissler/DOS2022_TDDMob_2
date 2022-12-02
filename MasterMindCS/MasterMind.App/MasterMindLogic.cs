using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace MasterMind.App
{
    public class MasterMindLogic
    {
        public static string ReceiveCode(int level)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                sb.Append((char)('A' + new Random().Next(level + 2)));
            }

            string code = sb.ToString();
            return code;
        }

        public static string GetGuessFeedback(string code, string guess)
        {
            string result = "";

            string remainingGuess = "";
            string remainingCode = "";

            for (int i = 0; i < 4; i++)
            {
                char currentGuess = guess[i];
                if (code[i] == currentGuess)
                {
                    result += "P";
                }
                else
                {
                    remainingGuess += currentGuess;
                    remainingCode += code[i];
                }
            }

            for (int i = 0; i < remainingGuess.Length; i++)
            {
                if (remainingCode.Contains(remainingGuess[i]))
                {
                    result += "C";

                    remainingCode = remainingCode
                        .Remove(remainingCode.IndexOf(remainingGuess[i]), 1);
                }
            }

            return result;
        }
    }
}
