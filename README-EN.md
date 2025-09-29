# Char Save
> This en readme use DeepSeek-V3 to translate

[Chinese](README.md)
[English](README-EN.md)

CharSave

# Purpose
For solo devs, keeping things simple is key. PlayerPrefs works fine for basic needs, but adding a few small features can make future adaptations much easier.  
The API follows the same pattern as PlayerPrefs, but gives you the flexibility to choose your serialization format.  
Haven't done performance testing - might actually be slower than PlayerPrefs lol 😅, but the code is definitely cleaner and more maintainable.  

# Features
- An abstract class with PlayerPrefs-like interface
- A JSON-based implementation out of the box