using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Helpers
{
    public class DataTableConverter
    {
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    try
                    {
                        if (pro.Name == column.ColumnName)
                            //pro.SetValue(obj, dr[column.ColumnName], null);
                            pro.SetValue(obj,
                                Convert.ChangeType(dr[column.ColumnName],
                                    Nullable.GetUnderlyingType(pro.PropertyType) ?? pro.PropertyType, null));
                        else
                            continue;
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
            return obj;
        }


    }
}
