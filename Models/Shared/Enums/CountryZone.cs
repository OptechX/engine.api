using System;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace api.engine_v2.Models.Shared.Enums
{
    public enum CountryZone
    {
        [EnumMember(Value = "Asia")] Asia,
        [EnumMember(Value = "Middle East")] Middle_East,
        [EnumMember(Value = "Europe")] Europe,
        [EnumMember(Value = "North America")] North_America,
        [EnumMember(Value = "Central America")] Central_America,
        [EnumMember(Value = "South America")] South_America,
        [EnumMember(Value = "Africa")] Africa,
        [EnumMember(Value = "Oceania")] Oceania
    }
}

