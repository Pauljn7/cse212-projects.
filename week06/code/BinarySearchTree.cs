using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new node in the BST.
    /// </summary>
    public void Insert(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the tree is empty, set the root to the new node.
        if (_root is null)
        {
            _root = newNode;
        }
        // If the tree is not empty, use Node.Insert to find the right spot.
        else
        {
            _root.Insert(value);
        }
    }

    /// <summary>
    /// Check to see if the tree contains a certain value
    /// </summary>
    /// <param name="value">The value to look for</param>
    /// <returns>true if found, otherwise false</returns>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Yields all values in the tree
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the BST (smallest to largest)
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Iterate backward through the BST (largest to smallest).
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Exact mirror of TraverseForward.
    /// Go RIGHT first (largest), add the node, then go LEFT (smaller).
    /// This gives us largest to smallest order.
    /// </summary>
    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            // Go right first to get the largest values
            TraverseBackward(node.Right, values);
            // Add current node
            values.Add(node.Data);
            // Then go left for the smaller values
            TraverseBackward(node.Left, values);
        }
    }

    /// <summary>
    /// Get the height of the tree
    /// </summary>
    public int GetHeight()
    {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}

/// <summary>
/// Extension method to help print IEnumerable as a string
/// </summary>
public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}

/// <summary>
/// #############
/// # Problem 5 #
/// #############
/// Builds a balanced BST from a sorted array by always inserting
/// the MIDDLE value first, then recursing on left half and right half.
/// This prevents the tree from becoming a linked list shape.
/// Uses 'first' and 'last' indexes — NO list slicing.
/// </summary>
public static class TreeBuilder
{
    public static void InsertMiddle(BinarySearchTree tree, int[] sortedNumbers, int first, int last)
    {
        // Base case: no more values to insert in this range
        if (first > last)
            return;

        // Find the middle index
        int mid = (first + last) / 2;

        // Insert the middle value first — this keeps the tree balanced
        tree.Insert(sortedNumbers[mid]);

        // Recurse on the left half (values before mid)
        InsertMiddle(tree, sortedNumbers, first, mid - 1);

        // Recurse on the right half (values after mid)
        InsertMiddle(tree, sortedNumbers, mid + 1, last);
    }

    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(bst, sortedNumbers, 0, sortedNumbers.Length - 1);
        return bst;
    }
}
