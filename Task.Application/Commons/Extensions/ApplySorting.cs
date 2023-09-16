using Task.Application.Common.Models;

namespace Task.Application.Common.Extensions;

public static class Sorting
{
    public static List<T> ApplySorting<T>(this List<T> entities, Sorting<T>? sorting)
        where T : class
    {
        if (sorting is null)
            return entities;
        var asc = sorting.Asc;
        var desc = sorting.Desc;

        if (sorting.Asc == null && sorting.Desc == null)
            return entities;

        IOrderedEnumerable<T> result = null;

        if (asc != null)
        {
            result = entities
                .OrderBy(entity =>
                    entity.GetType().GetProperty(asc)?.GetValue(entity, null));
            //for (int i = 1; i < asc.Count; i++)
            //{
            //    int index = i;
            //    result = result
            //        .ThenBy(entity =>
            //            entity.GetType().GetProperty(asc[index])?.GetValue(entity, null));
            //}
        }


        if (desc != null)
        {
            result = (result ?? entities.AsEnumerable())
                .OrderByDescending(entity =>
                    entity.GetType().GetProperty(desc)?.GetValue(entity, null));
            //for (int i = 1; i < desc.Count; i++)
            //{
            //    int index = i;
            //    result = result
            //        .ThenByDescending(entity =>
            //            entity.GetType().GetProperty(desc[index])?.GetValue(entity, null));
            //}
        }

        return result?.ToList() ?? entities;
    }
}