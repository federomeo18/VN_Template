using System.IO;
using UnityEngine;

public class ScriptReader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReadCSVFile();
    }

    void ReadCSVFile()
    {
        StreamReader strReader = new StreamReader("D:\\GitHub\\Unity\\VN_Template\\Assets\\Dialogue\\StoryScript.txt");
        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = strReader.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }

            var data_values = data_String.Split(',');
            //Debug.Log(data_values[0].ToString() + " " + data_values[1].ToString() + " " + data_values[2].ToString());

        }
    }
}
