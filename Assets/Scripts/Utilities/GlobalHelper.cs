using UnityEngine;

public class GlobalHelper 
{
    public static GameObject FindGoByName(GameObject original,string targetName)
    {
        if (null == original) return null;
        GameObject result = null;
        if (original.name.Equals(targetName)) return original;
        foreach (Transform i in original.transform)
        {
            var child = i.gameObject;
            if (child.name.Equals(targetName)) return child;
            if (child.transform.childCount > 0)
                if ((result = FindGoByName(child, targetName)) != null) return result;

        }
        return null;
    }

    public static GameObject InstantiateMyPrefab(string path,Vector3 pos,Quaternion rot)
    {
        var obj = Resources.Load(path);
        var go = Object.Instantiate(obj) as GameObject;

        go.name = obj.name;//delete -clone
        go.transform.position = pos;
        go.transform.rotation = rot;
        go.transform.localScale = Vector3.one;
        
        return go;
    }
}
