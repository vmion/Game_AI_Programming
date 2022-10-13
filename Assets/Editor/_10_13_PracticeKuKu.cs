using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class _10_13_PracticeKuKU 
{
    [MenuItem("Save/kuku")]
    static public void KuKu()
    {
        Debug.Log("kuku");       
        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/" + "kuku.txt"))
        {
            for(int i = 1; i < 10; i++)
            {
                for(int j = 1; j < 10; j++)
                {
                    sr.Write(i);
                    sr.Write("*");
                    sr.Write(j);
                    sr.Write(" = ");
                    sr.Write(i * j);
                    sr.Write("\n");
                }
                sr.Write("\n");
            }
            sr.Close();
        }
    }
}

