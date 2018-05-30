using System;

class CustomNode
{
    public object data;

    public Node values;

    

    //Constructor
    public CustomNode(object data)
    {
        this.data = data;
    }

    public void insertValue(object x)
    {
        if (this.values == null)
        {
            this.values = new Node(x);
        }else
        {
            Node tmp = new Node(x);
            Node ptr = this.values;
            while (ptr.next != null)
            {
                ptr = ptr.next;
            }
            ptr.next = tmp;
        }
    }

    public void deleteValue(object x)
    {
        Node ptr = this.values;
        Node prevPtr = ptr;
        while (ptr.data != x )
        {
            prevPtr = ptr;
            ptr = ptr.next;            
        }

        if (ptr.data == x)
        {
            prevPtr.next = ptr.next;
        }else
        {
            Console.WriteLine(x + " not found in values");
        }
    }

}