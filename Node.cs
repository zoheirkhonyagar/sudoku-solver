using System;

class Node
{
    public object data;
    public Node next;
    //Constructor

    public Node()
    {
        this.data = null;
        this.next = null;
    }
    public Node(object data)
    {
        this.data = data;
        this.next = null;
    }
    
}