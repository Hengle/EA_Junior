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
}
