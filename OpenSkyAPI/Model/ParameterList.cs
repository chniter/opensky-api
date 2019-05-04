using System.Collections.Generic;

namespace OpenSkyAPI.Model
{
    public class ParameterList : List<KeyValuePair<string, string>>
    {
        public void Add(string key, string value)
        {
            KeyValuePair<string, string> element = new KeyValuePair<string, string>(key, value);
            Add(element);
        }
    }
}