using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TechPet.Data.Maps.Conversions
{
    internal static class ConverterTypes
    {
        internal static ValueConverter<Guid, string> GuidString()
            => new ValueConverter<Guid, string>(v =>  v.ToString(), v => new Guid(v));
    }
}
