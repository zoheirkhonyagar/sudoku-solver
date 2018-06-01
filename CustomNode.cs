using System;
using System.Collections.Generic;

class CustomNode
{
    public object data;

    public List<int> values;

    

    //Constructor
    public CustomNode(object data)
    {
        this.data = data;
        this.values = new List<int>();
    }

    public void insertValue(object x)
    {
        this.values.Add(Convert.ToInt32(x));
        // if (this.values == null)
        // {
        //     this.values = new Node(x);
        // }else
        // {
        //     Node tmp = new Node(x);
        //     Node ptr = this.values;
        //     while (ptr.next != null)
        //     {
        //         ptr = ptr.next;
        //     }
        //     ptr.next = tmp;
        // }
    }

    public void deleteValue(object x)
    {
        this.values.Remove(Convert.ToInt32(x));
        // Node ptr = this.values;
        // Node prevPtr = ptr;
        // while (ptr.data != x )
        // {
        //     prevPtr = ptr;
        //     ptr = ptr.next;            
        // }

        // if (ptr.data == x)
        // {
        //     prevPtr.next = ptr.next;
        // }else
        // {
        //     Console.WriteLine(x + " not found in values");
        // }
    }

}