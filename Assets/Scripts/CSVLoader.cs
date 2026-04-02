    using System.Collections.Generic;
    using UnityEngine;
    using System.Text.RegularExpressions;

    public class CSVLoader : MonoBehaviour
    {
        public TextAsset csvFile;

        public List<DialogueLine> LoadDialogue()
        {
            List<DialogueLine> lines = new List<DialogueLine>();

            string[] rows = csvFile.text.Split('\n');

            for (int i = 1; i < rows.Length; i++) // skip header
            {
                if (string.IsNullOrWhiteSpace(rows[i]))
                    continue;

                string[] columns = Regex.Split(rows[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                DialogueLine line = new DialogueLine
                {
                    speaker = columns[1],
                    text = columns[2],
                    delay = float.Parse(columns[3])
                };

                lines.Add(line);
            }

            return lines;
        }
    }