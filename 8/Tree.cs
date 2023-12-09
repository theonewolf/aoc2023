namespace day8 {
    public class Node<T>
{
   public T Value { get; set; }
   public Node<T> Left { get; set; }
   public Node<T> Right { get; set; }

   public Node(T value)
   {
       Value = value;
   }
}

public class Tree<T>
{
   public Node<T> Root { get; set; }

   public void Add(T value)
   {
       // Implement the logic to add a node to the tree
   }
}

}