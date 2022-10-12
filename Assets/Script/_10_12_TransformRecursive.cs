using UnityEngine;

public class _10_12_TransformRecursive : MonoBehaviour
{
    public Transform rootTransform;
    void Start()
    {
        ProcessChild(rootTransform);
        Transform findTransform = FindChild("Cube_2_1_1", rootTransform);
        Debug.Log(findTransform.name);
        //gameObjectÀÇ ºÎ¸ð
        Debug.Log(findTransform.parent.name);
        Debug.Log(findTransform.parent.parent.name);        
    }
    public void ProcessChild(Transform _root)
    {
        for(int i = 0; i < _root.childCount; i++)
        {
            Transform childTransform = _root.GetChild(i);
            Debug.Log(childTransform.name);
            ProcessChild(childTransform);
        }
    }
    public Transform FindChild(string _findName, Transform _root)
    {
        for (int i = 0; i < _root.childCount; i++)
        {
            Transform childTransform = _root.GetChild(i);
            if (childTransform.name.Equals(_findName))
            {                
                return childTransform;               
            }
            Transform findChild = FindChild(_findName, childTransform);
            if (findChild != null)
                return findChild;
        }
        return null;     
    }
    void Update()
    {
        
    }
}
