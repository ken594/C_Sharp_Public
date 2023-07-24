/**
 * Class to represent a stack using an array to store the stacked items.
 * Follows a LIFO (Last In First Out) order where new items are stacked on
 * top (back of array) and removed items are removed from the top / back.
 */
class Stack {
    /**
     * The constructor is executed when instantiating a new Stack() to construct
     * a new instance.
     * @returns {Stack} This new Stack instance is returned without having to
     *    explicitly write 'return' (implicit return).
     */
    constructor() {
        this.items = [];
    }

    /**
     * Adds a new given item to the top / back of this stack.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} item The new item to be added to the top / back.
     * @returns {number} The new length of this stack.
     */
    push(item) {
        this.items.push(item);
        return this.items.length;
    }

    /**
     * Removes the top / last item from this stack.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The removed item or undefined if this stack was empty.
     */
    pop() {
        return this.items.pop();
    }

    /**
     * Retrieves the top / last item from this stack without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The top / last item of this stack.
     */
    peek() {
        if (this.items.length < 1) return null;
        return this.items[this.items.length - 1];
    }

    /**
     * Returns whether or not this stack is empty.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean}
     */
    isEmpty() {
        return this.items.length > 0;
    }

    /**
     * Returns the size of this stack.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {number} The length.
     */
    size() {
        return this.items.length;
    }
}

let empty = new Stack();
let myList = new Stack();

// Testing
// myList.push(3);
// myList.push("Test");
// console.log(myList.size())
// console.log(myList.peek());
// myList.pop();
// console.log(myList.items);


class StackNode {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

class LinkedListStack {
    constructor() {
        this.head = null;
    }

    /**
     * Adds a new item to the top of the stack (the head).
     * - Time: O(1) constant.
     * - Space: O(1).
     * @param {any} val The val to add.
     * @returns {void}
     */
    push(val) {
        const node = new StackNode(val);
        // if the linkedlist is empty
        if (!this.head) {
            this.head = node;
            return;
        }

        // get to the end of the linkedlist and push the node in
        let curr = this.head;
        while (curr.next) {
            curr = curr.next;
        }
        curr.next = node;
    }

    /**
     * Removes the top item (the head).
     * - Time: O(1) constant.
     * - Space: O(1).
     * @returns {any} The top item of the stack.
     */
    pop() {
        // if it is empty
        if (!this.head) return null;
        let res;

        // if there is only one node
        if (!this.head.next) {
            res = this.head;
            this.head = null;
            return res;
        }

        // keep track of the prev and curr while traversing to the end of the linked list
        let prev = this.head;
        let curr = prev.next;
        while (curr.next) {
            prev = prev.next;
            curr = curr.next;
        }
        // pop the last node
        res = curr;
        prev.next = null;

        return res;
    }

    /**
     * Returns the top item of the stack without removing it.
     * - Time: O(1) constant.
     * - Space: O(1).
     * @returns {any} The top item.
     */
    peek() {
        if (!this.head) return null;

        // find the last node and return
        let curr = this.head;
        while (curr.next) {
            curr = curr.next;
        }

        return curr;
    }

    /**
     * Determines if the stack is empty.
     * - Time: O(1) constant.
     * - Space: O(1).
     * @returns {boolean}
     */
    isEmpty() {
        return !this.head;
    }

    /**
     * Gets the count of items in the stack.
     * - Time: O(n) linear, n = list length.
     * - Space: O(1).
     * @returns {number} The total number of items.
     */
    size() {
        let size = 0;
        let curr = this.head;
        while (curr) {
            size++;
            curr = curr.next;
        }

        return size;
    }

    /**
     * Returns whether or not this stack contains the value passed in (val).
     * @returns {val} value passed in.
     */
    contains(val) {
        if (!this.head) return false;

        let curr = this.head;
        // traverse the linked list and check if the val equals the node's data
        while (curr) {
            if (curr.data == val) return val;
            curr = curr.next;
        }

        return false;
    }

    // Time: O(n) linear, n = list length
    // Space: O(n)
    print() {
        let runner = this.head;
        let vals = "";

        while (runner) {
            vals += `${runner.data}${runner.next ? ", " : ""}`;
            runner = runner.next;
        }
        console.log(vals);
        return vals;
    }
}

let emptyLLS = new LinkedListStack();
let myListLLS = new LinkedListStack()

myListLLS.push(1);
myListLLS.push(2);
myListLLS.push(3);
// myListLLS.pop();
// console.log(myListLLS.peek().data);
// console.log(myListLLS.contains(2));

myListLLS.print();