using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
   [TestMethod]
// Scenario: Enqueue values "Low" (priority 1), "High1" (priority 5), "Medium" (priority 3), "High2" (priority 5)
// Expected Result: Dequeue order should be High1, High2, Medium, Low
//   (High1 and High2 are tied at priority 5, but High1 was added first, so it goes first)
// Defect(s) Found: The loop that searched for the highest priority item stopped one index early (index < _queue.Count - 1), so it never checked the last item in the list. It also used >= instead of > when comparing priorities, so on a tie it kept the most recently added item instead of the first one added (breaking FIFO order for ties). Finally, Dequeue never removed the item from the list after returning it, so calling Dequeue multiple times kept returning the same item.
public void TestPriorityQueue_HighestPriorityAndFifoTiebreak()
{
    var priorityQueue = new PriorityQueue();
    priorityQueue.Enqueue("Low", 1);
    priorityQueue.Enqueue("High1", 5);
    priorityQueue.Enqueue("Medium", 3);
    priorityQueue.Enqueue("High2", 5);

    Assert.AreEqual("High1", priorityQueue.Dequeue());
    Assert.AreEqual("High2", priorityQueue.Dequeue());
    Assert.AreEqual("Medium", priorityQueue.Dequeue());
    Assert.AreEqual("Low", priorityQueue.Dequeue());
}

   [TestMethod]
// Scenario: Try to get an item from an empty queue
// Expected Result: Exception should be thrown with appropriate error message.
// Defect(s) Found: None. The empty-queue check already threw the correct InvalidOperationException with the message "The queue is empty."
public void TestPriorityQueue_EmptyQueueThrowsException()
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
    catch (AssertFailedException)
    {
        throw;
    }
    catch (Exception e)
    {
        Assert.Fail(
             string.Format("Unexpected exception of type {0} caught: {1}",
                            e.GetType(), e.Message)
        );
    }
}
    [TestMethod]
    // Scenario: Enqueue "First" (priority 1), "Second" (priority 1), "Third" (priority 1) — all same priority
    // Expected Result: Dequeue order should be First, Second, Third (FIFO order when priorities are equal)
    // Defect(s) Found: None once Dequeue was fixed. Confirms Enqueue adds to the back and equal-priority items are returned in the order they were added.
    public void TestPriorityQueue_EqualPrioritiesFollowFifoOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 1);
        priorityQueue.Enqueue("Third", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }
    // Add more test cases as needed below.
}