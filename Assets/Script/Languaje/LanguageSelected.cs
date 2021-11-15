using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelected
{
    public static Dictionary<Language, Dictionary<string, string>> LoadCodex(string source)
    {
        var codex = new Dictionary<Language, Dictionary<string, string>>();

        string[] rows = source.Split('\r');
        var columToIndex = new Dictionary<string, int>();

        bool first = true;
        int lineNum = 0;

        foreach(var row in rows)
        {
            lineNum++;
            string[] cells = row.Split(',');

            if (first)
            {
                first = false;
                for (int i = 0; i < cells.Length; i++)
                {
                    columToIndex[cells[i]] = i;
                }
                continue;
            }

            string langName = cells[columToIndex["Language"]];
            Language lang = default;

            try
            {
                lang = (Language)Enum.Parse(typeof(Language), langName);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                continue;
            }

            var idName = cells[columToIndex["ID"]];
            var text = cells[columToIndex["Text"]];

            if (!codex.ContainsKey(lang))
            {
                codex[lang] = new Dictionary<string, string>();
            }

            codex[lang][idName] = text;
        }

        return codex;
    }
}
