# Hunter RPG

A simple, text-based console RPG built with C# and .NET 8 that simulates the daily life of a hunter in the wilderness.

## 🎮 Game Overview

Hunter RPG is a beginner-friendly console application where you play as a hunter trying to survive in the wilderness. Explore different locations, hunt animals, gather resources, and manage your health, energy, and hunger to survive as long as possible.

## ✨ Features

- **Survival Gameplay**: Manage health, energy, and hunger to stay alive
- **Exploration**: Navigate between different locations (Camp, Forest, River, Clearing, Cave)
- **Hunting System**: Hunt various animals (Deer, Rabbit, Wolf, Bear) for food and materials
- **Resource Management**: Gather and use items to aid survival
- **Day/Night Cycle**: Experience the passage of time as energy depletes
- **Text-Based Interface**: Easy-to-understand console interface with clear commands

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later

### Installation

1. Clone this repository or download the source code
```bash
git clone https://github.com/haibeu2901/HunterRPG.git
```

2. Navigate to the project directory
```bash
cd hunter-rpg
```

3. Build the project
```bash
dotnet build
```

4. Run the game
```bash
dotnet run
```

## 🎯 How to Play

1. **Character Creation**: Enter your name when prompted
2. **Navigation**: Move between locations using directional commands
   - `north`, `south`, `east`, `west`
3. **Actions**:
   - `hunt [animal name]` - Hunt an animal in your current location
   - `gather [item name]` - Collect an item from your current location
   - `rest` - Recover energy (increases hunger)
   - `eat [food name]` - Consume food to reduce hunger
   - `quit` - Exit the game

## 📋 Game Tips

- Rest at your camp when low on energy
- Hunt animals for food to manage hunger
- Be careful when hunting dangerous animals like wolves and bears
- Explore all locations to find useful items
- Remember that energy depletes with most actions
- A new day begins when your energy is depleted
- Animals respawn at the beginning of each day

## 🏗️ Project Structure

```
HunterRPG/
├── Program.cs                 # Entry point for the application
├── Models/                    # Contains all domain models/entities
│   ├── Player.cs              # Player character model
│   ├── Item.cs                # Base class for all items
│   ├── Animal.cs              # Base class for all animals
│   └── Location.cs            # Represents game locations
├── Managers/                  # Contains game management classes
│   ├── GameManager.cs         # Main game loop and state management
│   ├── UserInterface.cs       # Handles user interface
├── Enums/                     # Contains enumeration types
│   ├── AnimalType.cs          # Types of animals
│   ├── ItemType.cs            # Types of items
│   └── LocationType.cs        # Types of locations
└── Utils/                     # Utility classes
    └── RandomGenerator.cs     # Random number generation utilities
```


## 🧠 Learning Focus

This project is designed to teach and reinforce several C# and OOP concepts:

- **C# Fundamentals**: Working with variables, loops, conditionals, and methods
- **Object-Oriented Design**: Classes, objects, encapsulation, inheritance
- **Collections**: Using Lists and Dictionaries to manage game entities
- **Enumerations**: Type-safe constants for categorization
- **Properties**: C# property syntax and access control
- **Game Loop Pattern**: Implementing a basic game loop
- **Console I/O**: Reading input and formatting output

## 🛠️ Possible Enhancements

- Add a crafting system to create tools and weapons
- Implement a weather system that affects gameplay
- Add more locations, animals, and items
- Create a skill system for the player
- Add a quest/mission system
- Implement saving and loading game progress
- Add more complex combat mechanics

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🤝 Contributing

Contributions are welcome! Feel free to fork the repository and submit pull requests.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/amazing-feature`)
3. Commit your Changes (`git commit -m 'Add some amazing feature'`)
4. Push to the Branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📧 Contact

Your Name - your.email@example.com

Project Link: [https://github.com/haibeu2901/HunterRPG](https://github.com/haibeu2901/HunterRPG)

---

Happy hunting! 🏹🌲