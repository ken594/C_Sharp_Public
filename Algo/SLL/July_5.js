/*
https://visualgo.net/en
https://www.geeksforgeeks.org/applications-of-linked-list-data-structure/
*/
// This is the class for our Singly Linked Node
class SLNode {
    // The constructor is built to take 1 parameter; the value of the node we want
    // to create
    constructor(val) {
      // The node's actual value being set to the value passed in through the constructor
    this.value = val;
      // And the pointer that refers to the node next in the sequence after
      // this node. Note it starts as null, because when you first create a node,
      // it is not connected to anything.
    this.next = null;
    }
}
class SLList {
    constructor() {
      // The head marks the beginning of the linked list.
    this.head = null;
      // Note that it's null. This is because when you first create a list, it's empty!
    }
    /**
   * Determines if this list is empty. Write a method that returns a
   * boolean based on whether or not the list is empty.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @returns {boolean}
   */
    isEmpty() {
        // return this.head === null;
        return !this.head;
    }

    /**
     * Creates a new node with the given data and inserts that node at the front
     * of this list.
     * - Time: (?).
     * - Space: (?).
     * @param {any} data The data for the new node.
     * @returns {SLList} This list.
     */
    addToFront(value) {
        let newNode = new SLNode(value);
        if (this.isEmpty()) {
            this.head = newNode;
            return this;
        }

        newNode.next = this.head;
        this.head = newNode;

        return this;
    }
    
    /*
    Write a method that will add to the back of a singly linked list.

    Hint: Essentially, have a runner start at the head, traverse along to the end, 
    then create a new node at the end, and reassign the last node's .next pointer
    to the new node.

    * Creates a new node with the given data and inserts it at the back of
    * this list.
    * - Time: O(n) linear, n = length of list.
    * - Space: O(1) constant.
    * @param {any} data The data to be added to the new node.
    * @returns {SinglyLinkedList} This list.
*/
    addToBack(value) {
        if (this.isEmpty()) {
            return this.addToFront(value);
        }

        let runner = this.head;
        while (runner.next) {
            runner = runner.next;
        }
        let newNode = new SLNode(value);
        runner.next = newNode;

        return this;
    }
    /**
     * BONUS: Creates a new node with the given data and inserts it at the back of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} data The data to be added to the new node.
     * @param {?SLNode} runner The current node during the traversal of this list
     *    or null when the end of the list has been reached.
     * @returns {SLList} This list.
     */
    addToBackRecursive(data, runner = this.head) {
        if (!runner) {
            this.head = new SLNode(data);
            return this;
        }
        if (!runner.next) {
            runner.next = new SLNode(data);
            return this;
        }
        this.addToBackRecursive(data, runner.next);
    }


    /**
     * Removes the first node of this list.
     * - Time: (?).
     * - Space: (?).
     * @returns {any} The data from the removed node.
     */
    removeHead() {
        if (this.isEmpty()) return;

        let tempNode = this.head;
        this.head = this.head.next;
        tempNode.next = null;

        return tempNode;
    }

    // 
    /**BONUS: Calculates the average of this list.
     * - Time: (?).
     * - Space: (?).
     * @returns {number|NaN} The average of the node's data.
     */
    average() {
        if (this.isEmpty()) return 0;
        let sum = 0;
        let count = 0;
        let runner = this.head;
        while (runner) {
            sum += runner.value;
            count++;
            runner = runner.next;
        }
        return sum / count;
    }

    /**
     * Removes the last node of this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {any} The data from the node that was removed.
     */
    removeBack() {
        // might wanna check at least 2 nodes
        if (this.isEmpty()) return;
        let temp;
        if (!this.head.next) {
            temp = this.head;
            this.head = null;
            return temp;
        }

        let runner = this.head;
        while (runner.next && runner.next.next) {
            runner = runner.next;
        }
        temp = runner.next;
        runner.next = null;
        return temp;
    }

    /**
     * Determines whether or not the given search value exists in this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The data to search for in the nodes of this list.
     * @returns {boolean}
     */
    contains(val) {
        if (this.isEmpty()) return false;
        let runner = this.head;
        while (runner.next) {
            if (runner.value == val) return true;
            runner = runner.next;
        }
        return false;
    }

    /**
     * Determines whether or not the given search value exists in this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The data to search for in the nodes of this list.
     * @param {?ListNode} current The current node during the traversal of this list
     *    or null when the end of the list has been reached.
     * @returns {boolean}
     */
    containsRecursive(val, current = this.head) {
        if (!current) return false;
        if (current.value == val) return true;
        return this.containsRecursive(val, current.next);
    }


    // Here's a gimme: This will print the contents of a singly linked list.
    printList() {
        if (this.isEmpty()) {
        console.log("This list is empty");
        return this;
        }
        let toPrint = "";
        let runner = this.head;
        while (runner != null) {
        toPrint += `${runner.value} -> `;
        runner = runner.next;
        }
        console.log(toPrint);
        return this;
    }

}

    /******************************************************************* 
    Multiple test lists already constructed to test your methods on.
    Below commented code depends on insertAtBack method to be completed,
    after completing it, uncomment the code.
    */
    let myList = new SLList();
    myList.addToBack(1).addToBack(2).addToBack(3).addToBack(4).addToBack(5).addToBack(-8).addToBack(-6);
    // console.log(myList.containsRecursive(10));
    // myList.addToBackRecursive(10).addToBackRecursive(5);
    // console.log(myList.average());
    // console.log(myList.contains(7));
    // myList.removeBack();
    // myList.removeHead();
    myList.printList()

  // const singleNodeList = new SinglyLinkedList().addToBack([1]);
  // const biNodeList = new SinglyLinkedList().addToBack([1, 2]);
  // const firstThreeList = new SinglyLinkedList().addToBack([1, 2, 3]);
  // const secondThreeList = new SinglyLinkedList().addToBack([4, 5, 6]);
  // const unorderedList = new SinglyLinkedList().addToBack([-5, -10, 4, -3, 6, 1, -7, -2,]);