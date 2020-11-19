using System;
using System.Collections;


namespace SignalR_GameServer_v1
{
    interface IAbstractCollection
    {
        Iterator CreateIterator();
    }

    class Collection : IAbstractCollection
    {
        private ArrayList _items = new ArrayList();
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
    }

    interface IAbstractIterator
    {
        Word First();
        Word Next();
        bool IsDone { get; }
        Word CurrentItem { get; }
    }

    class Iterator : IAbstractIterator
    {
        private Collection _collection;
        private int _current = 0;
        private int _step = 1;

        public Iterator(Collection collection)
        {
            this._collection = collection;
        }

        public Word First()
        {
            _current = 0;
            return _collection[_current] as Word;
        }

        public Word Next()
        {
            _current += _step;
            if (!IsDone)
                return _collection[_current] as Word;
            else
                return null;
        }

        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        public Word CurrentItem
        {
            get { return _collection[_current] as Word; }
        }

        public bool IsDone
        {
            get { return _current >= _collection.Count; }
        }
    }
}