using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ECDict
{
    //Redis操作封装
    class RedisOperator
    {
        private static string Constr = "";

        //获取时加锁
        private static object locker = new Object();
        private static ConnectionMultiplexer instance = null;

        //静态方法管理实例，一旦断开连接，重新获取
        public static ConnectionMultiplexer Instance
        {
            get
            {
                if (Constr.Length == 0)
                {
                    throw new Exception("未设置redis连接！");
                }
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null || !instance.IsConnected)
                        {
                            instance = ConnectionMultiplexer.Connect(Constr);
                        }
                    }
                }
                return instance;
            }
        }

        static RedisOperator()
        {
        }

        //获取连接字符串
        public static void setCon(string config)
        {
            Constr = config;
        }


        public static IDatabase getDatabase()
        {
            return Instance.GetDatabase();
        }

        //Key前缀
        private static string mergeKey(string key)
        {
            return key;
        }

        //根据Key获取缓存对象
        public static T getObj<T>(string key)
        {
            key = mergeKey(key);
            return deserialize<T>(getDatabase().StringGet(key));
        }

        //根据Key获取缓存对象
        public static object getObj(string key)
        {
            key = mergeKey(key);
            return deserialize<object>(getDatabase().StringGet(key));
        }

        //设置缓存
        public static void set(string key, object value, int expireMinutes = 0)
        {
            key = mergeKey(key);
            if (expireMinutes > 0)
            {
                getDatabase().StringSet(key, serialize(value), TimeSpan.FromMinutes(expireMinutes));
            }
            else
            {
                getDatabase().StringSet(key, serialize(value));
            }

        }


        //判断是否存在缓存
        public static bool isExist(string key)
        {
            key = mergeKey(key);
            return getDatabase().KeyExists(key);
        }

        //移除key对应对象
        public static bool remove(string key)
        {
            key = mergeKey(key);
            return getDatabase().KeyDelete(key);
        }

        //设置异步
        public static async Task setAsync(string key, object value)
        {
            key = mergeKey(key);
            await getDatabase().StringSetAsync(key, serialize(value));
        }

        //异步获取缓存
        public static async Task<object> getAsync(string key)
        {
            key = mergeKey(key);
            object value = await getDatabase().StringGetAsync(key);
            return value;
        }


        //对象序列化
        private static byte[] serialize(object o)
        {
            if (o == null)
            {
                return null;
            }
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, o);
                byte[] objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        //反序列化对象
        private static T deserialize<T>(byte[] stream)
        {
            if (stream == null)
            {
                return default(T);
            }
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(stream))
            {
                T result = (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }
    }
}
