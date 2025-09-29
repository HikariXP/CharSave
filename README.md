# CharSave

[Chinese](README.md)
[English](README-EN.md)

叉存档

# 目的
独立游戏开发应当一切从简，直接用 PlayerPrefs 也够用。但稍微开放一些小功能，可以让后续的适配变得更轻松。  
调用方式完全遵循 PlayerPrefs 的那套模式，但开放了序列化格式的选择权，让你可以自由决定数据存储格式。  
没测试过性能，说不定比 PlayerPrefs 还要慢哈哈 😅，但代码结构明显更清晰易维护。  

# 功能
- 一个与 PlayerPrefs 接口相似的抽象类  
- 开箱即用的 JSON 序列化实现  