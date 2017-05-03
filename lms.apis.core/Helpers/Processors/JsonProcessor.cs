using Newtonsoft.Json;
using System.Collections.Generic;

namespace lms.apis.core.Helpers.Processors
{
    public static class JsonProcessor
    {
        public static string TransformToJson<T>(this List<T> itemsList, Formatting formatting = Formatting.Indented)
        {
            return JsonConvert.SerializeObject(itemsList, formatting);
        }

        public static string TransformToJson<T>(this IEnumerable<T> itemsList, Formatting formatting = Formatting.Indented)
        {
            return JsonConvert.SerializeObject(itemsList, formatting);
        }
    }
}