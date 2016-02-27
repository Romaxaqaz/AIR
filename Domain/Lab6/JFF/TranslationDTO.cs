using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Domain.Lab6.JFF
{
    [JsonObject(MemberSerialization.OptIn)]
    internal sealed class TranslationDTO
    {
        [JsonProperty("text")]
        public List<string> Translations { get; set; }

        public override string ToString()
        {
            return  string.Join(" / ", Translations ?? Enumerable.Empty<string>());
        }
    }
}
