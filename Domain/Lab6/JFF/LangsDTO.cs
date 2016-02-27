using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Lab6.JFF
{
    [JsonObject(MemberSerialization.OptIn)]
    internal sealed class LangsDTO
    {
        [JsonProperty("dirs")]
        public List<string> Langs { get; set; }

        public override string ToString()
        {
            return string.Join(",", Langs);
        }
    }
}
