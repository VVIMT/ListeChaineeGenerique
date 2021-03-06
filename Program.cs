using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_ListeChaineeGenerique
{
    class Program
    {
        static void Main(string[] args)
        {
            Liste<int> list = new Liste<int>();

            Element<int> elem = new Element<int> { setPrecedent = null, setSuivant = null };
            elem.Content = 5;

            list.Add(elem);

            elem = new Element<int> { setPrecedent = null, setSuivant = null };
            elem.Content = 10;
            list.Add(elem);

            elem = new Element<int> { setPrecedent = null, setSuivant = null };
            elem.Content = 4;
            list.Add(elem);

            Element<int> tmp = list.Start;
            int index = 0;
            Console.WriteLine("***************");
            while (tmp != null)
            {
                Console.WriteLine(tmp.Content + ", index = " + tmp.index);
                tmp = list.Index(++index);
            }

            elem = new Element<int> { setPrecedent = null, setSuivant = null };
            elem.Content = 99;
            list.AddAt(0, elem);

            elem = new Element<int> { setPrecedent = null, setSuivant = null };
            elem.Content = 33;
            list.AddAt(2, elem);

            elem = new Element<int> { setPrecedent = null, setSuivant = null };
            elem.Content = 30;
            list.AddAt(2, elem);

            tmp = list.Start;
            Console.WriteLine("***************");
            while (tmp != null)
            {
                Console.WriteLine(tmp.Content + ", index = " + tmp.index);
                tmp = tmp.Suivant;
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public class Element<T>
        {
            public int index { get; set; }

            public Element<T> setPrecedent { get; set; }

            public Element<T> setSuivant { get; set; }

            public Element<T> Precedent { get { return setPrecedent; } }

            public Element<T> Suivant { get { return setSuivant; } }

            public T Content { get; set; }
        }

        public class Liste<E>
        {
            public static int i = 0;

            private static Element<E> _ancre;

            public void Add(Element<E> elem)
            {
                Element<E> tmp = End;

                if (_ancre != null)
                {
                    elem.setPrecedent = tmp;
                    elem.setSuivant = null;
                    tmp.setSuivant = elem;
                }
                else
                {
                    _ancre = elem;
                    elem.setPrecedent = null;
                    elem.setSuivant = null;
                }
                elem.index = i++;
            }

            public void AddAt(int index, Element<E> elem)
            {
                if (index >= i)
                {
                    Add(elem);
                    return;
                }

                Element<E> tmp = Index(index);

                if (tmp != null)
                {
                    elem.setPrecedent = tmp.setPrecedent;
                    if (index > 0)
                        elem.Precedent.setSuivant = elem;
                    elem.setSuivant = tmp;
                    tmp.setPrecedent = elem;
                }
                else if (tmp == null && index == 0)
                {
                    elem.setPrecedent = null;
                    elem.setSuivant = null;
                }
                if (index == 0)
                    _ancre = elem;
                i++;
                while (elem != null)
                {
                    elem.index = index++;
                    elem = elem.Suivant;
                }
            }

            public Element<E> Index(int index)
            {
                Element<E> elem = _ancre;

                if (_ancre != null)
                {
                    while (elem != null && elem.index != index)
                        elem = elem.Suivant;
                }
                return elem;
            }

            public Element<E> setStart()
            {
                return _ancre;
            }

            public Element<E> setEnd()
            {
                Element<E> elem = _ancre;

                if (elem != null)
                {
                    while (elem.Suivant != null)
                        elem = elem.Suivant;
                }
                return elem;
            }

            public Element<E> Start { get { return setStart(); } }

            public Element<E> End { get { return setEnd(); } }
        }
    }
}
