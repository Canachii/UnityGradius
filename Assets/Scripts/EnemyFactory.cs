using System.Collections;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct EnemyData
{
    public string name;
    public GameObject prefab;
}

public class EnemyFactory : MonoBehaviour
{
    public TextAsset file;
    public EnemyData[] enemyData;

    private string[] _lines;

    // Start is called before the first frame update
    void Start()
    {
        if (file == null)
        {
            throw new System.NullReferenceException("Spawn data not found");
        }

        _lines = file.text.Split('\n');
        if (!_lines[0].Contains("Name,Position,Time"))
        {
            throw new System.Exception("Incorrect data");
        }

        StartCoroutine("StartCreate");
    }

    private IEnumerator StartCreate()
    {
        for (int i = 0; i < _lines.Length - 1; i++)
        {
            string[] data = _lines[i + 1].Split(',');
            string enemy = data[0];
            float y = float.Parse(data[1]);
            float time = float.Parse(data[2]);

            yield return new WaitForSeconds(time);
            Instantiate(CreateEnemy(enemy), new Vector3(transform.position.x, y),
                Quaternion.identity);
        }
    }

    GameObject CreateEnemy(string name)
    {
        var newObject = (from data in enemyData where data.name == name select data.prefab).FirstOrDefault();

        if (newObject == null)
        {
            throw new System.NullReferenceException("Enemy data not found");
        }

        return newObject;
    }
}