using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;
using UnityEditor;

public class Village : MonoBehaviour
{
    public NavMeshAgent nav;    
    float yVelocity;
    float smoothTime;
    bool z;
    Vector3 towardBack;
    float elapsed;
    void Start()
    {
        nav.destination = transform.position;
        yVelocity = 0.01f;
        smoothTime = 100f;
        z = false;
        towardBack = Vector3.zero;
        elapsed = 0f;
        LoadTerrain(Application.dataPath + "/" + "Terrain.txt");
        LoadBuilding(Application.dataPath + "/" + "Building.txt");
        Building();
        Terrain();
    }
    public void Building()
    {
        GameObject[] findBds = GameObject.FindGameObjectsWithTag("Building");
        EditorUtility.SaveFilePanel("SaveFile", Application.dataPath, "Building", "txt");
        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/" + "Building.txt"))
        {
            sr.WriteLine("Index, Name, PosX, PosY, PosZ, RotX, RotY, RotZ, ScaleX, ScaleY, ScaleZ");
            for (int i = 0; i < findBds.Length; i++)
            {
                sr.Write((i + 1).ToString());
                sr.Write(",");
                sr.Write(findBds[i].name);
                sr.Write(",");
                sr.Write(findBds[i].transform.localPosition.x);
                sr.Write(",");
                sr.Write(findBds[i].transform.localPosition.y);
                sr.Write(",");
                sr.Write(findBds[i].transform.localPosition.z);
                sr.Write("\n");
            }
            sr.Close();
        }
    }
    public void Terrain()
    {
        GameObject[] findTr = GameObject.FindGameObjectsWithTag("Terrain");
        EditorUtility.SaveFilePanel("SaveFile", Application.dataPath, "Terrain", "txt");
        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/" + "Terrain.txt"))
        {
            sr.WriteLine("Index, Name, PosX, PosY, PosZ, RotX, RotY, RotZ, ScaleX, ScaleY, ScaleZ, Tag");
            for (int i = 0; i < findTr.Length; i++)
            {
                sr.Write((i + 1).ToString());
                sr.Write(",");
                sr.Write(findTr[i].name);
                sr.Write(",");
                sr.Write(findTr[i].transform.localPosition.x);
                sr.Write(",");
                sr.Write(findTr[i].transform.localPosition.y);
                sr.Write(",");
                sr.Write(findTr[i].transform.localPosition.z);
                sr.Write(",");
                sr.Write(findTr[i].tag);
                sr.Write("\n");
            }
            sr.Close();
        }
    }
    public void LoadTerrain(string _fullPath)
    {
        string line = string.Empty;
        using (StreamReader sr = new StreamReader(_fullPath))
        {
            sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                Debug.Log(line);
                string[] datas = line.Split(",");
                int objIndex = int.Parse(datas[0]);
                string objName = datas[1];
                float xPos = float.Parse(datas[2]);
                float yPos = float.Parse(datas[3]);
                float zPos = float.Parse(datas[4]);
                Vector3 objPos = new Vector3(xPos, yPos, zPos);
            }
            sr.Close();
            GameObject a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            a.name = "Terrain" + Random.Range(1, 5);
            a.tag = "Terrain";
            a.transform.position = new Vector3(Random.Range(0f, 3f), -1, Random.Range(0, 3f));
        }
    }
    public void LoadBuilding(string _fullPath)
    {
        string line = string.Empty;
        using (StreamReader sr = new StreamReader(_fullPath))
        {
            sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                Debug.Log(line);
                string[] datas = line.Split(",");
                int objIndex = int.Parse(datas[0]);
                string objName = datas[1];
                float xPos = float.Parse(datas[2]);
                float yPos = float.Parse(datas[3]);
                float zPos = float.Parse(datas[4]);
                Vector3 objPos = new Vector3(xPos, yPos, zPos);
            }
            sr.Close();
            GameObject a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            a.name = "Building" + Random.Range(1, 5);
            a.tag = "Building";
            a.transform.position = new Vector3(Random.Range(-3f, 0), -1, Random.Range(-3f, 0));
            a.GetComponent("Test");            
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {                
                nav.destination = hitInfo.point;
            }
        }        
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            z = true;
            towardBack.Set(transform.position.x - transform.forward.x * 0.5f, 0, transform.position.z - transform.forward.z * 0.5f);
        }        
        if (z)
        {
            elapsed += Time.deltaTime;            
            float dx = Mathf.SmoothDamp(transform.position.x, towardBack.x, ref yVelocity, smoothTime);
            float dz = Mathf.SmoothDamp(transform.position.z, towardBack.z, ref yVelocity, smoothTime);            
            Vector3 back = new Vector3(towardBack.x - dx, 0, towardBack.z - dz);
            nav.Move(back);
            if (elapsed >= 0.5f)
            {
                z = false;
                elapsed = 0f;
            }
        }
        
    }
}
