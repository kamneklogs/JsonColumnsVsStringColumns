using Bogus;
using Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


using (var context = new JsonColumnsContext())
{
    context.WithJsonColumns.AddRange(GenerateObjectsWithJsonColums().Generate(5000));
    context.WithString.AddRange(GenerateObjectsWithStringColums().Generate(5000));

    await context.WithJsonColumns.ExecuteDeleteAsync();
    await context.WithString.ExecuteDeleteAsync();

    context.SaveChanges();
}

Faker<ObjectA> GenerateObjectsWithJsonColums()
{
    var faker = new Faker<ObjectA>()
        .RuleFor(o => o.NestedObject, f => new NestedObject
        {
            Name = f.Name.FirstName(),
            Values = [.. f.Make(f.Random.Int(1, 30), () => Guid.NewGuid().ToString())]
        });


    return faker;
}

Faker<ObjectB> GenerateObjectsWithStringColums()
{
    var faker = new Faker<ObjectB>()
        .RuleFor(o => o.NestedObjectName, f =>
        {
            var no = new NestedObject
            {
                Name = f.Name.FirstName(),
                Values = [.. f.Make(f.Random.Int(1, 30), () => Guid.NewGuid().ToString())]
            };

            return JsonConvert.SerializeObject(no);
        }
        );

    return faker;
}
