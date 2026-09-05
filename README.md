# 🎮 Unity Slot Machine Game — Assignment Submission

A modular, performant, and extensible 3D/2D Slot Machine Game built with **Unity 2022/2023** and **C#**, featuring weighted Random Number Generation (RNG), smooth physics-based reel spinning with bounce easing, 5 active paylines, wild symbol substitutions, custom sound manager, and a WebGL build.

---

## 📄 Table of Contents
1. [Game Overview](#-game-overview)
2. [Playable WebGL Build & Instructions](#-playable-webgl-build--instructions)
3. [Bonus Features](#-bonus-features)
4. [Thought Process & Architectural Approach](#-thought-process--architectural-approach)
5. [Project Folder Structure](#-project-folder-structure)

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

### 🔗 Live WebGL Demo Link
👉 **[Click Here to Play the Live WebGL Build](https://pawpulse-deploy.vercel.app/slot_game.html)**

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
- **🎯 Bounce Easing Animation**: Easing curves applied when reels stop.

---

## 🧠 Thought Process & Architectural Approach

### 1. Object-Oriented & Decoupled Design (SOLID Principles)
To ensure clean code maintainability and scalability, the architecture separates data, physics, evaluation logic, and user interface into distinct components:
- **Data Layer (`SymbolData.cs`)**: Utilizes Unity **ScriptableObjects** under `Assets/Core/Scripts/Data/` to define symbol properties without hardcoding values in scripts.
- **Physics Layer (`ReelController.cs`)**: Manages individual reel scrolling, symbol wrap-around looping, and bounce easing curves upon stopping under `Assets/Core/Scripts/Controllers/`.
- **Evaluation Layer (`PaylineEvaluator.cs`)**: Decoupled matrix evaluation engine that checks 3x3 symbol combinations against paylines and calculates total payouts.
- **State Machine (`SlotMachineController.cs`)**: Manages state transitions using `SlotState.cs` under `Assets/Core/Scripts/Enums/`.

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
│   │   └── Enums/
│   │       └── SlotState.cs
│   ├── Prefabs/
│   │   ├── Reel.prefab
│   │   └── SymbolItem.prefab
│   ├── ScriptableObjects/
│   │   ├── Cherry.asset
│   │   ├── Lemon.asset
│   │   ├── Seven.asset
│   │   └── Wild.asset
│   └── Sprites/
└── WebGLTemplates/
```
