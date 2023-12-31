/**
 * Class to represent a queue using an array to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class Queue {
    constructor() {
        this.items = [];
    }

    /**
     * Adds a new given item to the back of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} item The new item to add to the back.
     * @returns {number} The new size of this queue.
     */
    enqueue(item) {
        this.items.push(item);
        return this.items.length;
    }

    /**
     * Removes and returns the first item of this queue.
     * - Time: O(n) linear, due to having to shift all the remaining items to
     *    the left after removing first elem.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    dequeue() {
        // There is a built-in function Array.shift()
        // which removes the first element and returns that remove element;

        if (this.items.length < 1) return undefined;

        let res = this.items[0];
        for (let index = 0; index < this.items.length - 1; index++) {
            this.items[index] = this.items[index + 1];
        }
        this.items.pop();
        return res;
    }

    /**
     * Retrieves the first item without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    front() {
        return this.items[0];
    }

    /**
     * Returns whether or not this queue is empty.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean}
     */
    isEmpty() {
        return this.items.length < 1;
    }

    /**
     * Retrieves the size of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {number} The length.
     */
    size() {
        return this.items.length;
    }

    /**
     * Logs the items of this queue.
     * - Time: O(n) linear.
     * - Space: O(n) linear.
     * @returns {string} The same string that is logged.
     */
    print() {
        const str = this.items.join(" ");
        console.log(str);
        return str;
    }
    /**
   * Compares this queue to another given queue to see if they are equal.
   * Avoid indexing the queue items directly via bracket notation, use the
   * queue methods instead for practice.
   * Use no extra array or objects.
   * The queues should be returned to their original order when done.
   * - Time: O(n^2) quadratic, n = queue length. Quadratic due to dequeue on an
   *     array queue being O(n).
   * - Space: O(1) constant.
   * @param {Queue} q2 The queue to be compared against this queue.
   * @returns {boolean} Whether all the items of the two queues are equal and
   *    in the same order.
   */
    compareQueues(q2){
        if (this.size() != q2.size()) return false;

        let counter = 0;
        let isEqual = true;
        let queueSize = this.size();
        while (counter < queueSize) {
            const first = this.dequeue();
            const second = q2.dequeue();

            if (first != second) isEqual = false;
            this.enqueue();
            q2.enqueue();
            counter++;
        }
        return isEqual;
    }

    /**
   * Determines if the queue is a palindrome (same items forward and backwards).
   * Avoid indexing queue items directly via bracket notation, instead use the
   * queue methods for practice.
   * Use only 1 stack as additional storage, no other arrays or objects.
   * The queue should be returned to its original order when done.
   * - Time: O(n^2) quadratic, n = queue length. Quadratic due to dequeue on an
   *     array queue being O(n).
   * - Space: O(n) from the stack being used to store the items again.
   * @returns {boolean}
   */
    isPalindrome(){
        if (!this.size()) return false;

        // Two passes
        // First pass: push all the element into the stack
        // could use a foreach
        const queueSize = this.size();
        let stack = [];
        let counter = 0;
        while (counter < queueSize) {
            let item = this.dequeue();
            stack.push(item);
            this.enqueue(item);
            counter++;
        }

        // second pass: compare and enqueue back into the queue
        counter = 0;
        let flag = true;
        while (counter < queueSize) {
            let queueItem = this.dequeue();
            let stackItem = this.pop();
            if (queueItem != stackItem) flag = false;
            this.enqueue(queueItem);
            counter++;
        }

        return flag;
    }
}

// let test1 = new Queue();
// let test2 = new Queue();
// console.log(test1.enqueue(1));
// console.log(test1.enqueue(2));
// console.log(test1.enqueue(3));

// console.log(test2.enqueue(1));
// console.log(test2.enqueue(5));
// console.log(test2.enqueue(3));
// console.log(test1.dequeue());
// console.log(test1);
// console.log(test1.compareQueues(test2));

/* EXTRA: Rebuild the above class using a linked list instead of an array. */

/* 
    In order to maintain an O(1) enqueue time complexity like .push with an array
    We add a tail to our linked list so we can go directly to the last node
*/

class QueueNode {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

    class LinkedListQueue {
    constructor() {
        this.top = null;
        this.tail = null;
        this.size = 0;
    }

    /**
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean} Indicates if the list is empty.
     */
    isEmpty() {
        return this.size == 0;
    }

    /**
     * Adds a given val to the back of the queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} val
     * @returns {number} The new size of the queue.
     */
    enqueue(val) {
        const node = new QueueNode(val);
        if (this.isEmpty()) {
            this.top = node;
            this.tail = node;
            this.size++;
            return this.size;
        }

        this.tail.next = node;
        this.tail = node;
        this.size++;
        return this.size;
    }

    /**
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The removed item.
     */
    dequeue() {
        if (this.isEmpty()) return null;

        let dequeueNode = this.top;
        this.top = this.top.next;
        this.size--;
        return dequeueNode;
    }

    /**
     * Retrieves the first item without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The first item.
     */
    front() {
        return this.top;
    }

    /**
     * Determines if the given item is in the queue.
     * - Time: O(n) linear.
     * - Space: O(1) constant.
     * @param {any} searchVal
     * @returns {boolean}
     */
    contains(searchVal) {
        if (this.isEmpty()) return false;
        
        let curr = this.top;
        while (curr) {
            if (curr.data === searchVal) return true;
            curr = curr.next;
        }

        return false;
    }
}

const test1 = new LinkedListQueue();
test1.enqueue(1);
test1.enqueue(2);
test1.enqueue(3);
// test1.dequeue();
console.log(test1);
// console.log(test1.top);
// console.log(test1.contains(9));