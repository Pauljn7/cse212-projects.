public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Insert unique values only - no duplicates allowed.
    /// If the value already exists in the tree, do nothing.
    /// </summary>
    public void Insert(int value)
    {
        // Problem 1: if value already exists, don't add it (no duplicates)
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Search the tree for a value.
    /// Returns true if found, false if not found.
    /// Works just like Insert — compare and go left or right.
    /// </summary>
    public bool Contains(int value)
    {
        // Base case: found the value!
        if (value == Data)
            return true;

        // Value is smaller — search left subtree
        if (value < Data)
        {
            if (Left is null)
                return false; // Dead end, not in tree
            return Left.Contains(value);
        }
        // Value is larger — search right subtree
        else
        {
            if (Right is null)
                return false; // Dead end, not in tree
            return Right.Contains(value);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Get the height of this node's subtree.
    /// Height = 1 + the taller of (left height, right height).
    /// A single node by itself has height 1.
    /// </summary>
    public int GetHeight()
    {
        // Get height of left subtree (0 if no left child)
        int leftHeight  = Left  is null ? 0 : Left.GetHeight();

        // Get height of right subtree (0 if no right child)
        int rightHeight = Right is null ? 0 : Right.GetHeight();

        // This node adds 1 to whichever subtree is taller
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
