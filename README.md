# Archer Aerospace Tech Tree

A full replacement technology tree for Kerbal Space Program designed around capability-driven progression, historical inspiration, and player choice.

## Overview

Archer Aerospace replaces the stock KSP tech tree with a custom progression system organized into parallel, independently investable branches. The tree prioritizes clarity over part spam, capability unlocks over arbitrary gating, and long-term gameplay feel over strict historical simulation.

### Key Features

- **Aircraft-First Progression**: Aircraft remain relevant throughout the entire tech tree
- **Parallel Branch Architecture**: Multiple independent progression paths instead of a single linear unlock
- **Historical Inspiration**: Tech tiers loosely correspond to real-world aerospace eras (1930s to speculative future)
- **Capability-Driven**: Unlocks focus on new mission capabilities rather than arbitrary scaling
- **Custom Agencies**: Includes Archer Aerospace as the player's private aerospace company, plus Soviet-style OKBs
- **Custom Space Center**: Includes "Archer Areospace Proving Grounds" via Kerbal Konstructs
- **Contract Support**: Custom contracts for launch services

## Installation

1. Download the latest release or clone this repository
2. Install all required dependencies (see below)
3. Place the entire `ArcherAreospace` folder into your KSP `GameData` directory
4. Ensure you have [ModuleManager](https://forum.kerbalspaceprogram.com/index.php?/topic/50533-*/) installed

### Required Dependencies

The following mods and DLC are required for full functionality:

- **ModuleManager** - Core dependency for patch system
- **Station Parts Expansion Redux** - Full integration across T3-T10 for station modules
- **ReStock+** - Additional part variants and visual improvements
- **SCANsat** - Mapping and scanning functionality
- **Kerbal Konstructs** - Required for custom space center (Archer Areospace Proving Grounds)
- **Kerbinside Remastered** - Additional launch sites and infrastructure
- **Contract Configurator** - Required for custom contracts
- **Kramax Autopilot** - Autopilot functionality

### Required DLC

- **Making History DLC** - Historical parts and mission support
- **Serenity DLC** - Science and exploration parts

## Tech Tree Structure

The tech tree is organized into 11 tiers (T0-T10), each representing different eras of aerospace development:

- **T0**: Early Jet & Experimental Flight (1930s-1940s)
- **T1**: Postwar Aviation & Early Research (mid-1940s)
- **T2**: Sounding Rockets & Pre-Orbital Research (late 1940s-mid-1950s)
- **T2.5**: Sputnik Era (1957)
- **T3**: Early Orbital Capability (late 1950s-early 1960s)
- **T3.5**: Vostok Era (early 1960s)
- **T4**: Mercury / Early Space Operations (early-mid 1960s)
- **T4.5**: Voskhod & Early Probe Expansion (mid-1960s)
- **T5**: Gemini / Rendezvous & Deep Space (mid-late 1960s)
- **T5.5**: Soyuz / Operational Crewed Spaceflight (late 1960s-1970s)
- **T6**: Apollo / Heavy Lift Era (late 1960s-early 1970s)
- **T6.5**: Salyut / Early Space Stations (1970s-1980s)
- **T7**: Shuttle / Reusability Era (1980s-2010s)
- **T8**: ISS / Modern Orbital Infrastructure (1990s-Present)
- **T9**: Near-Future Operations
- **T10**: Speculative / Post-Real-World Technology

### Branch Architecture

The tech tree consists of three main branch types:

1. **Core Spines** (Continuous Advancement)
   - Aircraft Branch: Atmospheric flight and spaceplane development
   - Archer Aerospace Rocketry: General-purpose 1.25m rocketry

2. **Program Overlays** (Optional Crewed Paths)
   - NASA Crewed Program: Heavy lift, milestones, large-scale missions
   - Soviet Crewed Program: Early crewed access, compact stations

3. **Support & Capability Branches**
   - Science, Electrical, Probe & Guidance, Rovers, Structural, Recovery, SRBs, Stations

## File Structure

```
ArcherAreospace/
├── Agencies/              # Custom agency definitions
├── Contracts/             # Contract Configurator contracts
├── Documentation/         # Reference documentation
├── Flags/                # Agency and manufacturer flags
├── KK/                   # Kerbal Konstructs space center
└── Patches/              # ModuleManager patches
    ├── Compatibility/    # Compatibility patches for other mods
    ├── Manufacturers/    # Manufacturer definitions
    └── TechTree/         # Tech tree node and part assignments
```

## Custom Agencies

- **Archer Areospace**: Player's private aerospace company (faction-agnostic)
- **Kerolev OKB**: Capsules and command modules (Korolev tribute)
- **Glushkeb KB**: Engines (Glushko tribute)
- **Kerushko Design Bureau**: Fuel tanks and structural parts (Chelomei tribute)
- **Energia**: Space stations (NPO Energia tribute)

## Compatibility

This mod uses ModuleManager patches and should be compatible with most part mods. Parts from supported mods (Station Parts Expansion Redux, ReStock+, etc.) will automatically be assigned to appropriate tech nodes.

### Additional Compatible Mods

- **MechJeb2** - Unlock patches included for tech tree integration

## Documentation

Detailed documentation is available in the `Documentation/` folder:

- `AA_TechTree_Reference.txt` - Complete tech tree design and implementation reference
- `AA_ContractConfigurator_Reference.txt` - Contract system documentation
- `AA_NamingConvention_Reference.txt` - Naming conventions used
- `ksp_parts_AATechTree.csv` - Part assignment reference spreadsheet

## License

This is a personal, single-player mod and is not intended for public release or stock balance parity.

## Credits

- Designed and maintained for personal KSP gameplay
- Inspired by historical aerospace programs (Mercury, Gemini, Apollo, Vostok, Soyuz, etc.)
- Integrates with community mods: Station Parts Expansion Redux, ReStock+, and others

## Version History

See git commit history for detailed changelog.
