// Array
let array = [1, 2, 3, 4, 5];

// Loop
for (let item of array) {
    console.log(item);
}

// Add an element
// Not possible to add dynamically to an array

// Remove an element
// Not dynamically supported in arrays

// Get an element
let elementFromArray = array[2];

// Check the existence of an element
let existsInArray = array.includes(3);

// List
let list = [1, 2, 3, 4, 5];

// Loop
for (let item of list) {
    console.log(item);
}

// Add an element
list.push(6);

// Remove an element
let indexToRemove = list.indexOf(3);
if (indexToRemove !== -1) {
    list.splice(indexToRemove, 1);
}

// Get an element
let elementFromList = list[2];

// Check the existence of an element
let existsInList = list.includes(5);

// Map (can be used as a Dictionary)
let map = new Map();

// Loop
for (let [key, value] of map) {
    console.log(`${key}: ${value}`);
}

// Add an element
map.set("One", 1);

// Remove an element
map.delete("Three");

// Get an element
let valueFromMap = map.get("One");

// Check the existence of an element
let keyExists = map.has("Two");

// Set (can be used as an HashSet)
let set = new Set([1, 2, 3, 4, 5]);

// Loop
for (let item of set) {
    console.log(item);
}

// Add an element
set.add(6);

// Remove an element
set.delete(3);

// Check the existence of an element
let existsInSet = set.has(5);

// Linked List
class Node {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

class LinkedList {
    constructor() {
        this.head = null;
    }

    add(value) {
        const newNode = new Node(value);
        if (!this.head) {
            this.head = newNode;
        } else {
            let current = this.head;
            while (current.next) {
                current = current.next;
            }
            current.next = newNode;
        }
    }

    remove(value) {
        if (!this.head) return;
        if (this.head.value === value) {
            this.head = this.head.next;
            return;
        }
        let current = this.head;
        while (current.next) {
            if (current.next.value === value) {
                current.next = current.next.next;
                return;
            }
            current = current.next;
        }
    }

    contains(value) {
        let current = this.head;
        while (current) {
            if (current.value === value) return true;
            current = current.next;
        }
        return false;
    }
}

let linkedList = new LinkedList();

// Loop
let current = linkedList.head;
while (current) {
    console.log(current.value);
    current = current.next;
}

// Add an element
linkedList.add(1);

// Remove an element
linkedList.remove(2);

// Get an element
let elementFromLinkedList = linkedList.head ? linkedList.head.value : undefined;

// Check the existence of an element
let existsInLinkedList = linkedList.contains(1);

//sorted list
class SortedList {
    constructor() {
        this.list = [];
    }

    // Loop
    forEach(callback) {
        this.list.forEach(callback);
    }

    // Add an element
    add(value) {
        let index = this.findInsertionIndex(value);
        this.list.splice(index, 0, value);
    }

    // Remove an element
    remove(value) {
        const index = this.list.indexOf(value);
        if (index !== -1) {
            this.list.splice(index, 1);
        }
    }

    // Get an element by index
    get(index) {
        if (index >= 0 && index < this.list.length) {
            return this.list[index];
        }
        return undefined;
    }

    // Set an element at a specific index
    set(index, value) {
        if (index >= 0 && index < this.list.length) {
            this.list[index] = value;
        }
    }

    // Check the existence of a value
    contains(value) {
        return this.list.includes(value);
    }

    // Find the index for inserting a value while maintaining the sorted order
    findInsertionIndex(value) {
        let low = 0;
        let high = this.list.length;

        while (low < high) {
            const mid = Math.floor((low + high) / 2);
            if (value > this.list[mid]) {
                low = mid + 1;
            } else {
                high = mid;
            }
        }

        return low;
    }
}

sortedList.forEach((value) => {
    console.log(value);
});

sortedList.remove(3);

console.log("Contains 3:", sortedList.contains(3));
console.log("Get(2):", sortedList.get(2));

sortedList.set(1, 6);

sortedList.forEach((value) => {
    console.log(value);
});

//Stack
class Stack {
    constructor() {
        this.items = [];
    }

    // Add an element 
    push(value) {
        this.items.push(value);
    }

    // Remove the element 
    pop() {
        if (this.isEmpty()) {
            return undefined;
        }
        return this.items.pop();
    }

    // Return the element from the top of the Stack without removing it
    peek() {
        if (this.isEmpty()) {
            return undefined;
        }
        return this.items[this.items.length - 1];
    }

    // add element
    set(index, value) {
        if (index >= 0 && index < this.items.length) {
            this.items[index] = value;
        }
    }

    // Check if the Stack is empty
    isEmpty() {
        return this.items.length === 0;
    }

    // Check the existence of a value 
    contains(value) {
        return this.items.includes(value);
    }

    // Loop 
    forEach(callback) {
        this.items.forEach(callback);
    }
}

//Queue
class Queue {
    constructor() {
        this.items = [];
    }

    // Add an element 
    enqueue(value) {
        this.items.push(value);
    }

    // Remove the element 
    dequeue() {
        if (this.isEmpty()) {
            return undefined;
        }
        return this.items.shift();
    }

    // Return the element from the front of the Queue without removing it
    front() {
        if (this.isEmpty()) {
            return undefined;
        }
        return this.items[0];
    }

    // add element
    set(index, value) {
        if (index >= 0 && index < this.items.length) {
            this.items[index] = value;
        }
    }

    // Check if the Queue is empty
    isEmpty() {
        return this.items.length === 0;
    }

    // Check the existence 
    contains(value) {
        return this.items.includes(value);
    }

    // Loop 
    forEach(callback) {
        this.items.forEach(callback);
    }
}

// Example usage of Stack and Queue
const stack = new Stack();
stack.push(1);
stack.push(2);
stack.push(3);

stack.forEach((value) => {
    console.log("Stack:", value);
});

console.log("Pop:", stack.pop());
console.log("Peek:", stack.peek());
stack.set(0, 5);

stack.forEach((value) => {
    console.log("Stack:", value);
});

const queue = new Queue();
queue.enqueue("A");
queue.enqueue("B");
queue.enqueue("C");

queue.forEach((value) => {
    console.log("Queue:", value);
});

console.log("Dequeue:", queue.dequeue());
console.log("Front:", queue.front());
queue.set(0, "X");

queue.forEach((value) => {
    console.log("Queue:", value);
});
