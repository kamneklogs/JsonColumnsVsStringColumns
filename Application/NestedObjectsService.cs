using Context;
using Newtonsoft.Json;

namespace Application;

public class NestedObjectsService
{

    public NestedObject GetObjectB()
    {
        using var context = new JsonColumnsContext();

        var allRecords = context.WithString.ToList();

        List<NestedObject> nestedObjects = new List<NestedObject>();

        foreach (var record in allRecords)
        {
            nestedObjects.Add(JsonConvert.DeserializeObject<NestedObject>(record.NestedObjectName));
        }

        var v = nestedObjects.FirstOrDefault(x => x.Name == "Felipe");

        return v;
    }


    public NestedObject GetObjectA()
    {
        using var context = new JsonColumnsContext();

        var v = context.WithJsonColumns.FirstOrDefault(x => x.NestedObject.Name == "Felipe");

        return v.NestedObject;
    }
}
