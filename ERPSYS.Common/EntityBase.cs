using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ERPSYS.Common
{
    [DataContract]
    [Serializable]
    public class EntityBase
    {
        private DataFieldsDictionary _fields;

        public EntityBase()
        {
            _fields = new DataFieldsDictionary();
        }

        [XmlIgnore]
        public  this[string fieldName]
        {
            
        }

        [DataMember]
        public DataFieldsDictionary Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        public object this[string fieldName] => string.Empty;
    }
}