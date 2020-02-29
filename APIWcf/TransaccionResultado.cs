using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    public enum TransaccionResultado
    {
        [EnumMember]
        Ok = 0,

        [EnumMember]
        Denegada = 996,

        [EnumMember]
        Expirada = 997,

        [EnumMember]
        ErrorArgumentos=998,

        [EnumMember]
        ErrorSistema = 999
    }
}