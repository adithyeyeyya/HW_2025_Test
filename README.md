# HW_2025_Test: Doofus Adventure Game

**Assignment Submission for Hitwicket Game Developer Role (VIT 2026)**

This project is a 3D procedural platformer built in **Unity 6**. The player controls "Doofus," a character who must navigate an endless path of disappearing platforms ("Pulpits") to achieve the highest score.

## 🎮 Gameplay Overview
* **Goal:** Survive as long as possible by jumping onto new Pulpits before the current one self-destructs.
* **Mechanic:** Only two Pulpits exist at any given time. As one spawns, the previous one starts a self-destruct timer.
* **Scoring:** Score increases by +1 for every new platform reached.
* **Game Over:** The game ends if Doofus falls off the edge or stays on a platform too long.

## 🕹️ Controls
* **Move:** `W`, `A`, `S`, `D` or `Arrow Keys`
* **Start Game:** Click "Start Game" on the UI.
* **Restart:** Click "Restart" on the Game Over screen.

## ⚙️ Configuration (JSON)
The game logic is driven by an external JSON file as per the "Doofus Diary" requirement. You can modify game parameters without changing code.

**File Location:** `Assets/StreamingAssets/doofus_diary.json`

```json
{
  "player_data": {
    "speed": 5.0
  },
  "pulpit_data": {
    "min_pulpit_destroy_time": 4.0,
    "max_pulpit_destroy_time": 6.0,
    "pulpit_spawn_time": 2.5
  }
}
