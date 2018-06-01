using System;

class Children
{
    public ChildNode childNode;
    public ChildNode lastPtr;
    public Children()
    {
        this.childNode = null;
        this.lastPtr = null;
    }
    
    public void add(object data)
    {
        if (this.childNode == null)
        {
            this.childNode = new ChildNode();
            this.lastPtr = this.childNode;
        }else
        {
            this.lastPtr.next = new ChildNode();
            this.lastPtr = this.lastPtr.next;
        }
    }

}