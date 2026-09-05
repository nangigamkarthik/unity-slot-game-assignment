using System.Collections.Generic;
using UnityEngine;
using SlotGame.Data;

namespace SlotGame.Controllers
{
    public class PaylineResult
    {
        public int PaylineIndex { get; set; }
        public bool IsWin { get; set; }
        public int WinAmount { get; set; }
        public SymbolType WinningSymbol { get; set; }
    }

    public class PaylineEvaluator : MonoBehaviour
    {
        private readonly int[][] paylineDefinitions = new int[][]
        {
            new int[] { 1, 1, 1 }, // Line 1: Middle Horizontal
            new int[] { 0, 0, 0 }, // Line 2: Top Horizontal
            new int[] { 2, 2, 2 }, // Line 3: Bottom Horizontal
            new int[] { 0, 1, 2 }, // Line 4: Diagonal TL-BR
            new int[] { 2, 1, 0 }  // Line 5: Diagonal BL-TR
        };

        public List<PaylineResult> EvaluateGrid(SymbolData[,] grid, int currentBet)
        {
            List<PaylineResult> results = new List<PaylineResult>();

            for (int i = 0; i < paylineDefinitions.Length; i++)
            {
                int[] line = paylineDefinitions[i];
                SymbolData s1 = grid[0, line[0]];
                SymbolData s2 = grid[1, line[1]];
                SymbolData s3 = grid[2, line[2]];

                if (CheckPaylineMatch(s1, s2, s3, out SymbolData winningSymbol))
                {
                    int winPayout = currentBet * winningSymbol.payoutMultiplier;
                    results.Add(new PaylineResult
                    {
                        PaylineIndex = i,
                        IsWin = true,
                        WinAmount = winPayout,
                        WinningSymbol = winningSymbol.type
                    });
                }
            }

            return results;
        }

        private bool CheckPaylineMatch(SymbolData s1, SymbolData s2, SymbolData s3, out SymbolData winSymbol)
        {
            winSymbol = null;
            if (s1 == null || s2 == null || s3 == null) return false;

            SymbolData baseSymbol = !s1.isWild ? s1 : (!s2.isWild ? s2 : s3);

            bool m1 = s1.isWild || s1.type == baseSymbol.type;
            bool m2 = s2.isWild || s2.type == baseSymbol.type;
            bool m3 = s3.isWild || s3.type == baseSymbol.type;

            if (m1 && m2 && m3)
            {
                winSymbol = baseSymbol;
                return true;
            }

            return false;
        }
    }
}
