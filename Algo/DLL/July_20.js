/**
 * Class to represent a Node for a DoublyLinkedList.
 */
class DLLNode {
    /**
     * Executed when the new keyword is used to construct a new node instance.
     * @param {any} data The data the new node will store.
     */
    constructor(data) {
      this.data = data;
      /**
       * By default a new node instance will not be connected to any other nodes,
       * these properties will be set after instantiation to connect the node to
       * a list. However, the head prev should remain null.
       *
       * @type {DLLNode|null}
       */
      this.prev = null;
      /** @type {DLLNode|null} */
      this.next = null;
    }
  }
  
  /**
   * A class to represent a doubly linked list and contain all of it's methods.
   * A doubly linked list is a singly linked list that can be traversed in both
   * directions.
   */
  class DoublyLinkedList {
    /**
     * Executed when the new keyword is used to construct a new DoublyLInkedList
     * instance that inherits these methods and properties.
     */
    constructor() {
      // The list is empty to start.
      /** @type {DLLNode|null} */
      this.head = null;
      /** @type {DLLNode|null} */
      this.tail = null;
    }
  
    /**
     * Creates a new node and adds it at the front of this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} data The data for the new node.
     * @returns {DoublyLinkedList} This list.
     */
    insertAtFront(data) {
        const node = new DLLNode(data);
        if (this.isEmpty()) {
            this.head = node;
            this.tail = node;
        }
        else {
            const oldNode = this.head;
            this.head = node;
            node.next = oldNode;
            oldNode.prev = node;
        }
        return this;
    }
  
    /**
     * Creates a new node and adds it at the back of this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} data The data for the new node.
     * @returns {DoublyLinkedList} This list.
     */
    insertAtBack(data) {
        const node = new DLLNode(data);
        if (this.isEmpty()) {
            this.head = node;
            this.tail = node;
        } else {
            const oldNode = this.tail;
            this.tail = node;
            oldNode.next = node;
            node.prev = oldNode;
        }
        return this;
    }
  
    // EXTRA
    /**
     * Removes the middle node in this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {any} The data of the removed node.
     */
    removeMiddleNode() {
        // []
        if (this.isEmpty()) return null;
        // 1 ->
        if (!this.head.next) {
            let res = this.head;
            this.head = null;
            this.tail = null;
            return res.data;
        }
        // 1 -> 2
        if (!this.head.next.next) {
            let res = this.head;
            res.next.prev = null;
            this.head = res.next;
            res.next = null;
            return res.data;
        }
        // more than 2 nodes
        let slow = this.head;
        let fast = this.head;
        while (fast && fast.next && fast.next.next) {
            slow = slow.next;
            fast = fast.next.next;
        }
        slow.prev.next = slow.next;
        slow.next.prev = slow.prev;
        return slow.data;
    }
  
    /**
     * Determines if this list is empty.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean} Indicates if this list is empty.
     */
    isEmpty() {
      return this.head === null;
    }
  
    /**
     * Converts this list to an array of the node's data.
     * - Time: O(n) linear, n = list length.
     * - Space: O(n) linear, array grows as list length increases.
     * @returns {Array<any>} All the data of the nodes.
     */
    toArray() {
      const vals = [];
      let runner = this.head;
  
      while (runner) {
        vals.push(runner.data);
        runner = runner.next;
      }
      return vals;
    }
  
    /**
     * Adds all the given items to the back of this list.
     * @param {Array<any>} items Items to be added to the back of this list.
     * @returns {DoublyLinkedList} This list.
     */
    insertAtBackMany(items = []) {
      items.forEach((item) => this.insertAtBack(item));
      return this;
    }
  }
  
  const emptyList = new DoublyLinkedList();
  
  /**************** Uncomment these test lists after insertAtBack is created. ****************/
  const singleNodeList = new DoublyLinkedList().insertAtBack(1);
  // const biNodeList = new DoublyLinkedList().insertAtBack(1).insertAtBack(2);
  const triNodeList = new DoublyLinkedList().insertAtBack(1).insertAtBack(2).insertAtBack(3).insertAtBack(4).insertAtBack(5).insertAtBack(6).insertAtBack(7);
  // const firstThreeList = new DoublyLinkedList().insertAtBackMany([1, 2, 3]);
  // const secondThreeList = new DoublyLinkedList().insertAtBackMany([4, 5, 6]);
  // const unorderedList = new DoublyLinkedList().insertAtBackMany([-5,-10,4, -3, 6, 1, -7, -2,]);
  triNodeList.removeMiddleNode();
  console.log(singleNodeList.toArray())
  console.log(triNodeList.toArray())