using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLDrevo
{
    class AvlThree
    {
        public Node root;

        private int height(Node p)
        {
            return p == null ? 0 : p.height;
        }

        private Node insert(Node p, int x)
        {
            if (p == null)
                return new Node(x);
            if (x < p.key)
                p.left = insert(p.left, x);
            else
                p.right = insert(p.right, x);

            p.height = 1 + Math.Max(height(p.left), height(p.right));

            int balance = p == null ? 0 : height(p.left) - height(p.right);

            if (balance > 1 && x > p.left.key) // right key
                return RightRotate(p);
            if (balance < - 1 && x > p.right.key) // left key
                return LeftRotate(p);
            return p;
        }

        private Node RightRotate(Node y)
        {
            var x = y.left;
            var T2 = x.right;

            x.right = y;
            y.left = T2;

            y.height = Math.Max(height(y.left), height(y.right)) + 1;
            x.height = Math.Max(height(x.left), height(x.right)) + 1;

            return x;
        }

        private Node LeftRotate(Node x)
        {
            var y = x.right;
            var T2 = y.left;

            y.left = x;
            x.right = T2;

            y.height = Math.Max(height(y.left), height(y.right)) + 1;
            x.height = Math.Max(height(x.left), height(x.right)) + 1;

            return y;
        }

        public void Insert(int x)
        {
            root = insert(root, x);
        }

        public Node RR(Node rt)
        {
            var pivot = rt.left;
            rt.left = pivot.right;
            pivot.right = rt;
            return pivot;
        }

        public Node LL(Node rt)
        {
            var pivot = rt.right;
            rt.right = pivot.left;
            pivot.left = rt;
            return pivot;
        }

        public void Print1()
        {
            var lst = new List<List<int>>();
            lst.Add(new List<int>());
            print1(root, 0, lst);

            var max = lst.Max(obj => obj.Count);
            for (int i = 0; i < lst.Count; i++)
            {
                var t = Enumerable.Repeat(-1, max - lst[i].Count).ToList();
                lst[i].AddRange(t);
            }


            var temp = new List<List<int>>();
            for (int i = 0; i < max; i++)
            {
                temp.Add(Enumerable.Repeat(-1, lst.Count).ToList());
            }
            for (int i = 0; i != lst.Count; i++)
                for (int j = 0; j != lst[i].Count; j++)
                    temp[j][lst.Count - i - 1] = lst[i][j];


            int ml = lst.Max(row => row.Max()).ToString().Length;
            for (int i = 0; i < lst.Count; i++)
            {
                var tt = new System.Text.StringBuilder();
                if (lst[i].Max() < 0)
                    continue;
                for (int j = 0; j < lst[i].Count; j++)
                {
                    if (lst[i][j] == -1)
                        tt.Append(string.Concat(Enumerable.Repeat(' ', ml)).ToCharArray());
                    else
                    {
                        tt.Append(lst[i][j].ToString());
                        tt.Append(string.Concat(Enumerable.Repeat(' ', ml - lst[i][j].ToString().Length)).ToCharArray());
                    }
                }
            }

            foreach (var i in temp)
            {
                foreach (var j in i)
                {
                    if (j >= 0)
                        Console.Write(j + " ");
                    else
                        Console.Write(" ");
                }
                Console.Write("\n");
            }
        }

        private void print1(Node n, int step, List<List<int>> lst)
        {
            if (n.right != null)
                print1(n.right, step + 1, lst);

            for (int i = 0; i != step; i++)
                lst.Last().Add(-1);
            lst.Last().Add(n.key);
            lst.Add(new List<int>());

            if (n.left != null)
                print1(n.left, step + 1, lst);
        }
    }
}
