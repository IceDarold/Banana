using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NicnemeGenerator
{
    private static List<string> prefixes = new List<string> { "Dark", "Light", "Fire", "Ice", "Shadow", "Thunder", "Storm", "Silver", "Golden", "Mighty" };
    private static List<string> suffixes = new List<string> { "Warrior", "Mage", "Rogue", "Hunter", "Knight", "Lord", "Master", "Sage", "Seeker", "Guardian" };
    private static List<string> middleParts = new List<string> { "Blade", "Strike", "Flame", "Frost", "Wing", "Heart", "Soul", "Moon", "Star", "Shadow" };

    public static string GenerateNickname()
    {
        string prefix = prefixes[Random.Range(0, prefixes.Count)];
        string middle = middleParts[Random.Range(0, middleParts.Count)];
        string suffix = suffixes[Random.Range(0, suffixes.Count)];

        // 50% шанс использовать среднюю часть
        if (Random.Range(0, 2) == 0)
        {
            return prefix + middle + suffix;
        }
        else
        {
            return prefix + suffix;
        }
    }
}
