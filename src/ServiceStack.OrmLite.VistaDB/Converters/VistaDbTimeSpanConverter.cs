﻿using System;
using System.Data;
using ServiceStack.OrmLite.Converters;

namespace ServiceStack.OrmLite.VistaDB.Converters
{
    public class VistaDbTimeSpanConverter : TimeSpanConverter
    {
        private static readonly DateTime timeSpanOffset = new DateTime(1900, 01, 01);

        public override string ColumnDefinition
        {
            get { return "BIGINT"; }
        }

        public override DbType DbType
        {
            get { return DbType.DateTime; }
        }

        public override object ToDbValue(Type fieldType, object value)
        {
            if (value is DateTime)
            {
                var dateTimeValue = (DateTime)value;
                return dateTimeValue - timeSpanOffset;
            }
            return base.ToDbValue(fieldType, value);
        }
    }
}