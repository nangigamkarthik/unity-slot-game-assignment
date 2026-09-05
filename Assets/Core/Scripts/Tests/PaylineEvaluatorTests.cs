using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using SlotGame.Data;
using SlotGame.Controllers;

namespace SlotGame.Tests
{
    public class PaylineEvaluatorTests
    {
        private GameObject testContainer;
        private PaylineEvaluator evaluator;

        [SetUp]
        public void SetUp()
        {
            testContainer = new GameObject("TestContainer");
            evaluator = testContainer.AddComponent<PaylineEvaluator>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(testContainer);
        }

        [Test]
        public void EvaluateGrid_ThreeMatchingSymbols_ReturnsWinningPayline()
        {
            // Arrange
            SymbolData cherry = ScriptableObject.CreateInstance<SymbolData>();
            cherry.type = SymbolType.Cherry;
            cherry.payoutMultiplier = 10;
            cherry.isWild = false;

            SymbolData[,] grid = new SymbolData[3, 3];
            grid[0, 1] = cherry; // Middle Horizontal Row
            grid[1, 1] = cherry;
            grid[2, 1] = cherry;

            int betAmount = 10;

            // Act
            List<PaylineResult> results = evaluator.EvaluateGrid(grid, betAmount);

            // Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0, "Payline evaluation should detect 3 matching cherries.");
            Assert.AreEqual(100, results[0].WinAmount, "Payout should equal Bet (10) * Multiplier (10) = 100.");
        }

        [Test]
        public void EvaluateGrid_WildSubstitution_ReturnsWinningPayline()
        {
            // Arrange
            SymbolData seven = ScriptableObject.CreateInstance<SymbolData>();
            seven.type = SymbolType.Seven;
            seven.payoutMultiplier = 50;
            seven.isWild = false;

            SymbolData wild = ScriptableObject.CreateInstance<SymbolData>();
            wild.type = SymbolType.Wild;
            wild.isWild = true;

            SymbolData[,] grid = new SymbolData[3, 3];
            grid[0, 1] = seven;
            grid[1, 1] = wild;  // Wild substitutes for Seven
            grid[2, 1] = seven;

            int betAmount = 10;

            // Act
            List<PaylineResult> results = evaluator.EvaluateGrid(grid, betAmount);

            // Assert
            Assert.IsTrue(results.Count > 0, "Wild symbol should substitute to form winning payline.");
            Assert.AreEqual(500, results[0].WinAmount, "Payout should equal Bet (10) * Multiplier (50) = 500.");
        }
    }
}
