using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Task.Application.Common.Models
{
    public class Sorting<T>
    {
        [JsonPropertyName("asc")]
        public string Asc { get; set; }
        [JsonPropertyName("desc")]
        public string Desc { get; set; }
        public void Toggle(Expression<Func<T, object>> expression)
        {
            PropertyInfo propertyInfo = expression.GetPropertyAccess();
            if (propertyInfo is null)
                return;

            if (this.Asc == propertyInfo.Name != null)
            {
                this.Asc = null;
                this.Desc = propertyInfo.Name;
            }
            else if (this.Desc == propertyInfo.Name != null)
            {
                this.Asc = propertyInfo.Name;
                this.Desc = null;
            }
            else
            {
                this.Asc = propertyInfo.Name;
            }
        }
    }
}
