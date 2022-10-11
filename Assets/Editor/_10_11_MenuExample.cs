using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class _10_11_MenuExample
{
    //MapData/Export의 메뉴를 선택하면 MapExport함수가 호출됨
    [MenuItem("MapData/Export")]
    static public void MapExport()
    {
        Debug.Log("Export");
        //게임씬에 생성된 "Monster"라는 태그를 갖는 게임 오브젝트를 검색하여
        //파일에 이름을 쉼표단위로 저장
        GameObject[] findObjs = GameObject.FindGameObjectsWithTag("Monster");
        //string selectedFile = EditorUtility.SaveFilePanel("SaveFile", Application.dataPath, "None", "csv");
        //메뉴를 클릭시 파일을 생성하고 데이터를 저장한다.
        //Application.dataPath는 Assets폴더 까지의 경로를 의미
        
        System.Array.Reverse(findObjs);
        //Reverse를 통해 배열을 내림차순 정리해준 후 파일에 작성하도록 만들어 깔끔하게 유지한다.

        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/" + "test.csv"))
        {
            //cvs파일의 첫줄(컬럼)에 표기성분 값을 Split을 이용하여 적어준다.
            /*
            string indexCVS = "Name, PositionX, PositionY, PositionZ ";
            string[] indexCVSsplit = indexCVS.Split(",");
            sr.Write(indexCVS);
            sr.Write("\n");
            */
            sr.WriteLine("Name, PositionX, PositionY, PositionZ");
            //성분이름들 밑에 성분값들을 적어준다.
            for (int i = 0; i < findObjs.Length; i++)
            {                
                sr.Write(findObjs[i].name);
                sr.Write(",");
                sr.Write(findObjs[i].transform.position.x);
                sr.Write(",");
                sr.Write(findObjs[i].transform.position.y);
                sr.Write(",");
                sr.Write(findObjs[i].transform.position.z);
                sr.Write("\n");               
            }
            sr.Close();
        }        
    }
}
