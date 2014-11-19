using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;

namespace DataBaseLayer
{
    public class DBSet<T> : IEnumerable<T>
        where T: new()
    {
        private IDataReader _dataReader;

        public DBSet(string entity, string entityKey)
        {
            _dataReader = new DataBase(entity, entityKey);
        }
         
       
        public IEnumerator<T> GetEnumerator()
        {
            IEnumerable<Dictionary<string,object>> data = _dataReader.GetData("*");

            IEnumerator<T> valueData = Reflection(data).GetEnumerator();

            return valueData;
        }
        IEnumerable<T> Reflection(IEnumerable<Dictionary<string, object>> data)
        {
            string[] propsName = typeof(T).GetProperties().Select(p => p.Name).ToArray();
            T obj = new T();
            int count = 0;

            foreach (var d in data)
            {
                for (int i = 0; i < propsName.Length; i++)
                {
                    string key = d.Keys.FirstOrDefault(s => s.ToLower() == propsName[i].ToLower());

                    if (!String.IsNullOrEmpty(key))
                    {
                        Array.ForEach<PropertyInfo>(obj.GetType().GetProperties(),
                            a => obj.GetType().GetProperty(propsName[i]).SetValue(obj, d[key]));
                    }
                }
                
                yield return obj;
                count += 1;
            }

        }
        public bool Add(T obj)
        {
            if (obj != null)
            {
                return _dataReader.Add(obj);
            }
            else
            {
                throw new ArgumentNullException("Object add");
            }
        }
        public bool Update(T obj)
        {
            if (obj != null)
            {
                return _dataReader.Update(obj);
            }
            else
            {
                throw new ArgumentNullException("Object update");
            }
        }
        public bool Delete(T obj)
        {
            if (obj != null)
            {
                return _dataReader.Delete(obj);
            }
            else
            {
                throw new ArgumentNullException("Object delete");
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return default(T).ToString().GetEnumerator();
        }
    }
}
