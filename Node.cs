﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLDrevo
{
    class Node
    {
        public Node left;
        public Node right;

        public int key;
        public int height;

        public Node(int x)
        {
            key = x;
        }
    }
}
