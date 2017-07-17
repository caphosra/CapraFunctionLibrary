#if !MUSEUM

using System;
using System.Collections.Generic;

namespace Cpr314Lib
{
    namespace Museum
    {
        public class CprMuseum<T>
        {
#if DEBUG
            public List<MuseumItem<T>> Items =
                new List<MuseumItem<T>>();
#else
            private List<MuseumItem<T>> Items =
                new List<MuseumItem<T>>();
#endif

            /// <summary>
            /// Itemを増やします
            /// </summary>
            /// <param name="name">Item name</param>
            /// <param name="item">Item</param>
            /// <returns>True or False</returns>
            public bool Add(string name, T item)
            {
                foreach (MuseumItem<T> m in Items)
                    if (m.Name == name) return false;
                Items.Add(new MuseumItem<T>(name, item));
                return true;
            }

            /// <summary>
            /// Itemを増やします
            /// </summary>
            /// <param name="item">Item</param>
            /// <returns>True or False</returns>
            public bool Add(MuseumItem<T> item)
            {
                foreach (MuseumItem<T> m in Items)
                    if (m.Name == item.Name) return false;
                Items.Add(item);
                return true;
            }

            /// <summary>
            /// Itemを上書きします
            /// </summary>
            /// <param name="name">Item name</param>
            /// <param name="item">Item</param>
            public void Override(string name, T item)
            {
                foreach (MuseumItem<T> m in Items)
                    if (m.Name == name) Items.Remove(m);
                Items.Add(new MuseumItem<T>(name, item));
            }

            /// <summary>
            /// Itemを上書きします
            /// </summary>
            /// <param name="item">Item</param>
            public void Override(MuseumItem<T> item)
            {
                foreach (MuseumItem<T> m in Items)
                    if (m.Name == item.Name) Items.Remove(m);
                Items.Add(item);
            }

            /// <summary>
            /// Itemを探します
            /// </summary>
            /// <param name="name">Item name</param>
            /// <returns>Item</returns>
            public T Search(string name)
            {
                foreach (MuseumItem<T> m in Items)
                {
                    if (m.Name == name) return m.Item;
                }
                throw new ArgumentException();
            }

            /// <summary>
            /// Itemが存在するか確認します
            /// </summary>
            /// <param name="name">Item name</param>
            /// <returns>True or False</returns>
            public bool Exist(string name)
            {
                foreach (MuseumItem<T> m in Items)
                {
                    if (m.Name == name) return true;
                }
                return false;
            }

            /// <summary>
            /// Itemを削除します。
            /// </summary>
            /// <param name="name">Items name</param>
            /// <returns>True or False</returns>
            public bool Delete(string name)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Name == name)
                    {
                        Items.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// Itemを削除します。
            /// </summary>
            /// <param name="name">Items name</param>
            /// <returns>True or False</returns>
            public bool Delete(MuseumItem<T> item)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i] == item)
                    {
                        Items.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// 配列感覚で使用
            /// </summary>
            /// <param name="name">Item name</param>
            /// <returns>Item</returns>
            public T this[string name]
            {
                get
                {
                    foreach (MuseumItem<T> m in Items)
                    {
                        if (m.Name == name) return m.Item;
                    }
                    throw new ArgumentException();
                }

                set
                {
                    foreach (MuseumItem<T> m in Items)
                    {
                        if (m.Name == name)
                        {
                            Items.Remove(m);
                            Items.Add(new MuseumItem<T>(name, value));
                            return;
                        }
                    }
                    throw new ArgumentException();
                }
            }

            public static CprMuseum<T> operator +(CprMuseum<T> museum,MuseumItem<T> museumitem)
            {
                museum.Add(museumitem);
                return museum;
            }

            public static CprMuseum<T> operator -(CprMuseum<T> museum, MuseumItem<T> museumitem)
            {
                museum.Delete(museumitem);
                return museum;
            }
        }

        public class MuseumItem<T>
        {
            public string Name;
            public T Item;

            public MuseumItem(string name, T item)
            {
                Name = name;
                Item = item;
            }
        }
    }
}

#endif
