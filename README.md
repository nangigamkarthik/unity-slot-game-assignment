# 🎮 Unity Slot Machine Game — Assignment Submission

A modular, performant, and extensible 3D/2D Slot Machine Game built with **Unity 2022/2023** and **C#**, featuring weighted Random Number Generation (RNG), smooth physics-based reel spinning with bounce easing, 5 active paylines, wild symbol substitutions, custom sound manager, NUnit unit test suite, and a WebGL build.

---

## 📄 Table of Contents
1. [Game Overview](#-game-overview)
2. [Playable WebGL Build & Instructions](#-playable-webgl-build--instructions)
3. [Bonus Features](#-bonus-features)
4. [Automated Unit Testing & Build Pipeline](#-automated-unit-testing--build-pipeline)
5. [Thought Process & Architectural Approach](#-thought-process--architectural-approach)
6. [Project Folder Structure](#-project-folder-structure)

---

## 🕹️ Game Overview

The **Unity Slot Machine Game** simulates an authentic casino 3x3 slot machine with realistic reel mechanics and payline evaluations. Players start with a credit balance, place bets, and spin the reels to align matching symbols or Wilds across active paylines.

### Key Gameplay Mechanics:
- **3x3 Reel Matrix**: 3 independent reels spinning vertically with staggered stopping sequences.
- **5 Active Paylines**: Evaluates horizontal top, middle, and bottom rows plus 2 diagonal lines.
- **Weighted RNG**: Uses a mathematical probability distribution table (`rngWeight`) to guarantee fair outcome frequencies.
- **Dynamic Betting Engine**: Allows player bet adjustments (Step ±5, Max Bet, Auto Spin) and tracks credit balance.

---

## 🌐 Playable WebGL Build & Instructions



### ⚙️ How to Run the WebGL Build Locally:
1. Locate the `/Build/WebGL` folder inside this repository.
2. Open `index.html` inside `/Build/WebGL` in any modern web browser.
3. Alternatively, launch a simple local HTTP server:
   ```bash
   python -m http.server 8000
   ```
4. Navigate to `http://localhost:8000/Build/WebGL` in your browser.

---

## 🎁 Bonus Features Included

- **🃏 Wild Symbol (`WILD`)**: Substitutes for any standard symbol (Cherry, Lemon, Seven, Diamond, etc.) to complete winning paylines.
- **⚡ Auto Spin Mode**: Allows continuous spinning until toggled off or balance runs out.
- **🏆 Win Celebration Modal**: Displays animated popups, credit score count-up animations, and highlighted paylines on Big Wins.
- **🔊 Custom Audio Manager**: Dedicated `SlotSoundManager.cs` handling spin loops, stop thuds, button clicks, and win fanfare SFX.
- **🎯 Bounce Easing Animation**: Easing curves applied when reels stop via `ReelAnimationController.cs`.

---

## 🧪 Automated Unit Testing & Build Pipeline

### 1. NUnit Unit Test Suite (`PaylineEvaluatorTests.cs`)
Located under `Assets/Core/Scripts/Tests/`, evaluating core game logic:
- `EvaluateGrid_ThreeMatchingSymbols_ReturnsWinningPayline`: Verifies 3x symbol payline detection & payout calculation.
- `EvaluateGrid_WildSubstitution_ReturnsWinningPayline`: Tests Wild symbol substitution logic across paylines.

### 2. Editor One-Click Build Pipeline (`BuildScript.cs`)
Located under `Assets/Core/Editor/`, providing 1-click WebGL compilation via Unity menu (`SlotGame ➔ Build WebGL`) or CLI command:
```bash
Unity.exe -batchmode -quit -projectPath . -executeMethod SlotGame.Editor.BuildScript.BuildWebGL
```

---

## 🧠 Thought Process & Architectural Approach

### Object-Oriented & Decoupled Design (SOLID Principles)
- **Data Layer (`SymbolData.cs`)**: ScriptableObjects defining symbol metadata.
- **Physics Layer (`ReelController.cs`)**: Coroutine-driven physics reel spinning & bounce snap animation.
- **Testing Layer (`PaylineEvaluatorTests.cs`)**: NUnit automated testing.
- **State Machine (`SlotMachineController.cs`)**: Finite State Machine handling spin lifecycle safely.

---

## 📁 Project Folder Structure

```text
Assets/
├── Core/
│   ├── Scripts/
│   │   ├── Data/
│   │   │   └── SymbolData.cs
│   │   ├── Controllers/
│   │   │   ├── ReelController.cs
│   │   │   ├── SlotMachineController.cs
│   │   │   ├── PaylineEvaluator.cs
│   │   │   ├── BetManager.cs
│   │   │   └── UIManager.cs
│   │   ├── Enums/
│   │   │   └── SlotState.cs
│   │   └── Tests/
│   │       └── PaylineEvaluatorTests.cs
│   ├── Editor/
│   │   └── BuildScript.cs
│   ├── Prefabs/
│   ├── ScriptableObjects/
│   └── Sprites/
├── WebGLTemplates/
├── .gitignore
└── README.md
```
