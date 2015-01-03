using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;

namespace DataBaseLayer
{
    public class DBSet<TEntity>: IEnumerable<TEntity>
        where TEntity: new()
    {
        private IDataReader _dataReader;

        public DBSet(SqlConnection connection, string keyEntity,bool isAutoinc)
        {
            _dataReader = new DataBase(connection);

            _dataReader.EntityName = typeof(TEntity).Name;
            _dataReader.KeyEntity = keyEntity;
            _dataReader.IsAutoinc = isAutoinc;
        }
        public DBSet(SqlConnection connection)
        {
            _dataReader = new DataBase(connection);

            _dataReader.EntityName = typeof(TEntity).Name;
            _dataReader.KeyEntity = "";
            _dataReader.IsAutoinc = true;
        }
        public IEnumerable<TEntity> GetAll()
        {
            IEnumerable<Dictionary<string, object>> data = _dataReader.GetData("*");

            IEnumerable<TEntity> valueData = Reflection(data);

            return valueData;
        }
        public IEnumerator<TEntity> GetEnumerator()
        {
            IEnumerable<Dictionary<string,object>> data = _dataReader.GetData("*");

            IEnumerator<TEntity> valueData = Reflection(data).GetEnumerator();

            return valueData;
        }
        IEnumerable<TEntity> Reflection(IEnumerable<Dictionary<string, object>> data)
        {
            string[] propsName = typeof(TEntity).GetProperties().Select(p => p.Name).ToArray();
            TEntity obj = new TEntity();

            foreach (var d in data)
            {
                obj = new TEntity();

                for (int i = 0; i < propsName.Length; i++)
                {
                    string key = d.Keys.FirstOrDefault(s => s.ToLower() == propsName[i].ToLower());

                    if (!String.IsNullOrEmpty(key))
                    {
                        Array.ForEach<PropertyInfo>(obj.GetType().GetProperties(),
                            a => {
                                try
                                {
                                    obj.GetType().GetProperty(propsName[i]).SetValue(obj, d[key]);
                                }
                                catch
                                {
                                }
                            });
                    }
                }
                
                yield return obj;
            }

        }
        public bool Add(TEntity obj)
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
        public bool Update(TEntity obj)
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
        public bool Delete(TEntity obj)
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
        public IEnumerable<TEntity> GetBy(string args)
        {
            IEnumerable<Dictionary<string, object>> data = _dataReader.GetData(args);

            IEnumerable<TEntity> valueData = Reflection(data);

            return valueData;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }
}
