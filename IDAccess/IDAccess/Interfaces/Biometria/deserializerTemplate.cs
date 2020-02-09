using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using IDAccess.Interfaces.Biometria;

namespace deserializerTemplate
{
    public class JsonHelper
    {
        public static T DeSerializar<T>(string json)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            return (T)ser.ReadObject(ms);
        }
    }
}
