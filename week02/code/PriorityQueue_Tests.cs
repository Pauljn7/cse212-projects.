using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities and dequeue them all.
    // Expected Result: Items come out highest priority first: "high", "medium", "low"
    // Defect(s) Found: 
    // 1. The loop in Dequeue stopped at _queue.Count - 1 which skipped the last item.
    //    Changed to _queue.Count to fix this.
    // 2. The item was never actually removed from the queue after dequeuing.
    //    Added _queue.RemoveAt(highPriorityIndex) to fix this.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("medium", 2);
        priorityQueue.Enqueue("high", 3);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("medium", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add two items with the same highest priority and one with lower priority.
    // Expected Result: First item enqueued with highest priority comes out first (FIFO rule).
    //                  Order should be: "first", "second", "other"
    // Defect(s) Found: 
    // 1. The loop used >= instead of > when comparing priorities so later items with
    //    equal priority would overwrite earlier ones breaking the FIFO rule.
    //    Changed >= to > to fix this.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);
        priorityQueue.Enqueue("other", 1);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("other", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty."
    // Defect(s) Found: No defect found. Exception is thrown correctly.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Add only one item to the queue and dequeue it.
    // Expected Result: The single item "only" is returned correctly.
    // Defect(s) Found: 
    // 1. With only one item the loop would skip it because it started at index 1
    //    and stopped at _queue.Count - 1 which was 0. Fixed by changing to _queue.Count.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("only", 1);

        Assert.AreEqual("only", priorityQueue.Dequeue());
    }
}
