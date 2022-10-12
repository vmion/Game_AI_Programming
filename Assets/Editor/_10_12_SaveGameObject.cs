using UnityEngine;
using System.IO;
using UnityEditor;

public class _10_12_SaveGameObject
{
    [MenuItem("Save/GameObject")]        
    static public void GameObjectSave()
    {
        Debug.Log("Save");        
        GameObject[] findObjs = GameObject.FindGameObjectsWithTag("Building");
        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/" + "GameObject.csv"))
        {
            sr.WriteLine("Index, Name, Parent, PositionX, PositionY, PositionZ, RotationX, RotaionY, RotaionZ, ScaleX, ScaleY, ScaleZ, Resources");
            for (int i = 0; i < findObjs.Length; i++)
            {
                Debug.Log(findObjs[i]);
                sr.Write(i+1);
                sr.Write(",");
                sr.Write(findObjs[i].name);
                sr.Write(",");
                if(findObjs[i].transform.parent != null)
                {
                    sr.Write(findObjs[i].transform.parent.name);                    
                }
                else
                {
                    sr.Write("X");
                }
                sr.Write(",");
                sr.Write(findObjs[i].transform.localPosition.x);
                sr.Write(",");
                sr.Write(findObjs[i].transform.localPosition.y);
                sr.Write(",");
                sr.Write(findObjs[i].transform.localPosition.z);
                sr.Write(",");
                sr.Write(findObjs[i].transform.localRotation.x);
                sr.Write(",");
                sr.Write(findObjs[i].transform.localRotation.y);
                sr.Write(",");
                sr.Write(findObjs[i].transform.localRotation.z);
                sr.Write(",");
                sr.Write(findObjs[i].transform.localScale.x);
                sr.Write(",");
                sr.Write(findObjs[i].transform.localScale.y);
                sr.Write(",");
                sr.Write(findObjs[i].transform.localScale.z);
                sr.Write(",");
                sr.Write(findObjs[i].tag);
                sr.Write("\n");
            }
            sr.Close();
        }
    }
}
