﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PrtgAPI.Request.Serialization.Cache
{
    class TypeCache : AttributeCache
    {
        public Type Type { get; set; }

        private Lazy<List<PropertyCache>> properties;

        public List<PropertyCache> Properties => properties.Value;

        private Lazy<List<FieldCache>> fields;

        public List<FieldCache> Fields => fields.Value;

        public TypeCache(Type type)
        {
            Type = type;

            properties = new Lazy<List<PropertyCache>>(GetProperties);
            fields = new Lazy<List<FieldCache>>(GetFields);
        }

        private List<PropertyCache> GetProperties()
        {
            var props = Type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            return props.Select(p => new PropertyCache(p)).ToList();
        }

        private List<FieldCache> GetFields()
        {
            return Type.GetFields().Select(f => new FieldCache(f)).ToList();
        }

        protected override MemberInfo attributeSource => Type;
    }
}
