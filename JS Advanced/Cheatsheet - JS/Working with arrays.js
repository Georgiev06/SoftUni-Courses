
// Adding items and removing items:
// 1. pop() removes the last element from an array and returns that element. This method changes the length of the array
let array = [10, 20, 30, 40, 50, 60, 70];
console.log(array.length); // 7
console.log(array.pop()); // 70
console.log(array.length); // 6
console.log(array); // [ 10, 20, 30, 40, 50, 60 ]

// 2. push() adds one or more elements to the end of an array and returns the new length of the array.
let array1 = [10, 20, 30, 40, 50, 60, 70];
console.log(array1.length); // 7
console.log(array1.push(80)); // 8 (array1.length)
console.log(array1); // [ 10, 20, 30, 40, 50, 60, 70, 80 ]

// 3. shift() method removes the first element from an array and returns that removed element. 
// This method changes the length of the array. shift() method removes the element at the zeroth index 
// and shifts the values at consecutive indexes down, then returns the removed value. 
// If the length property is 0, undefined is returned.
let array2 = [10, 20, 30, 40, 50, 60, 70];
console.log(array2.length); // 7
console.log(array2.shift()); // 10 (removed element)
console.log(array2);  // [ 20, 30, 40, 50, 60, 70 ]

// 4. unshift() method adds one or more elements to the beginning of an array and returns the new length of the array.
let array3 = [40, 50, 60];
console.log(array3.length); // 3
console.log(array3.unshift(30)); // 4 (array3.length)
console.log(array3.unshift(10, 20)); // 6 (array3.length)
console.log(array3); // [ 10, 20, 30, 40, 50, 60 ]

// 5. splice() changes the contents of an array by removing or replacing existing elements and/or adding new elements.
let array4 = [1, 3, 4, 5, 6];
array4.splice(1, 0, 2); // inserts at index 1
console.log(array4); // [ 1, 2, 3, 4, 5, 6 ]
array5.splice(4, 1, 19); // replaces 1 element at index 4
console.log(array4); // [ 1, 2, 3, 4, 19, 6 ]
let el = array4.splice(2, 1); // removes 1 element at index 2
console.log(array4); // [ 1, 2, 4, 19, 6 ]
console.log(el); // [ 3 ]

// 6. slice() method returns a shallow copy of a portion of an array into a new array
// object selected from start to end (end not included) where start and end represent 
// the index of items in that array. The original array will not be modified.
// Syntax: slice(); slice(start); slice(start, end)
const animals = ['ant', 'bison', 'camel', 'duck', 'elephant'];
console.log(animals.slice(2)); // expected output: Array ["camel", "duck", "elephant"]
console.log(animals.slice(2, 4)); // expected output: Array ["camel", "duck"]
console.log(animals.slice(1, 5)); // expected output: Array ["bison", "camel", "duck", "elephant"]
console.log(animals.slice(-2)); // expected output: Array ["duck", "elephant"]
console.log(animals.slice(2, -1)); // expected output: Array ["camel", "duck"]
console.log(animals.slice()); // expected output: Array ["ant", "bison", "camel", "duck", "elephant"]

// 7. fill() fills all the elements of an array from a start index to an end index with a static value.
let arr1 = [1, 2, 3, 4]; // fill with 0 from position 2 until position 4
console.log(arr1.fill(0, 2, 4)); // [1, 2, 0, 0] // fill with 5 from position 1
console.log(arr1.fill(5, 1)); // [1, 5, 5, 5] console.log(arr.fill(6)); // [6, 6, 6, 6]

// 8. reverse() the first array element becomes the last, and the last array element becomes the first.
let arr = [1, 2, 3, 4];
arr.reverse();
console.log(arr); // [ 4, 3, 2, 1 ]


// Sorting Arrays:
// 1. Sorting numbers 
let nums = [20, 40, 10, 30, 100, 5];
nums.sort((a, b) => a - b); // Compare elements as numbers
console.log(nums.join('|')); // 5|10|20|30|40|100

// 2. Sorting strings
let words = ['nest', 'Eggs', 'bite', 'Grip', 'jAw'];
words.sort((a, b) => a.localeCompare(b)); // ['bite', 'Eggs', 'Grip', 'jAw', 'nest']


// Accessing every item:
// 1. To access every item in the array. You can do this using the for...of -
const birds = ['Parrot', 'Falcon', 'Owl'];

for (const bird of birds) {
    console.log(bird);
}


// Accessor Methods
// 1. Join creates and returns a new string by concatenating all of the elements in an array (or an array-like object), separated by commas or a specified separator string.
let elements = ['Fire', 'Air', 'Water'];
console.log(elements.join()); // "Fire,Air,Water"
console.log(elements.join('')); // "FireAirWater"
console.log(elements.join('-')); // "Fire-Air-Water"
console.log(['Fire'].join(".")); // Fire

// 2. concat() method is used to merge two or more arrays. This method does not change the existing arrays, but instead returns a new array.
const num1 = [1, 2, 3];
const num2 = [4, 5, 6];
const num3 = [7, 8, 9];
const numbers = num1.concat(num2, num3);
console.log(numbers); //  [1, 2, 3, 4, 5, 6, 7, 8, 9]

// 3. includes() determines whether an array contains a certain element, returning true or false as appropriate.
// array length is 3
// fromIndex is -100
// computed index is 3 + (-100) = -97
let arr2 = ['a', 'b', 'c'];
arr.includes('a', -100); // true
arr.includes('b', -100); // true
arr.includes('c', -100); // true
arr.includes('a', -2); // false

// 4. indexOf() method returns the first index at which a given element can be found in the array. Output is -1 if element is not present.
const beasts = ['ant', 'bison', 'camel', 'duck', 'bison'];
console.log(beasts.indexOf('bison')); // 1 // start from index 2
console.log(beasts.indexOf('bison', 2)); // 4 console.log(beasts.indexOf('giraffe')); // -1


// Iteration Methods:
// 1. forEach() method executes a provided function once for each array element.
const items = ['item1', 'item2', 'item3'];
const copy = [];
// For loop
for (let i = 0; i < items.length; i++) {
    copy.push(items[i]);
}
// ForEach
items.forEach(item => { copy.push(item); });

// 2. map() method creates a new array populated with the results of calling a provided function.
// on every element in the calling array.
const arr4 = [1, 4, 9, 16];
// pass a function to map
const map1 = arr4.map(x => x * 2);
console.log(map1);
// expected output: Array [2, 8, 18, 32]

// 4. some() method tests whether at least one element in the array passes the test implemented
// by the provided function. It returns true if, in the array, it finds an element for which 
// the provided function returns true; otherwise it returns false. It doesn't modify the array.
const array5 = [1, 2, 3, 4, 5];
// checks whether an element is even
const even = (element) => element % 2 === 0;
console.log(array5.some(even));
// expected output: true

// 5. find() returns the first found value in the array, if an element in the array satisfies the provided testing function or undefined if not found.
let array6 = [5, 12, 8, 130, 44]; 
let found = array6.find(function (element) {
    return element > 10;
});
console.log(found); // 12

// 7. filter() method creates a shallow copy of a portion of a given array, filtered down to just 
// the elements from the given array that pass the test implemented by the provided function.
const words1 = ['spray', 'limit', 'elite', 'exuberant', 'destruction', 'present'];
const result = words1.filter(word => word.length > 6);
console.log(result); // expected output: Array ["exuberant", "destruction", "present"]


// Reducing Arrays
// 1. reduce() method executes a user-supplied "reducer" callback function on each element 
// of the array, in order, passing in the return value from the calculation on the preceding element. 
// The final result of running the reducer across all elements of the array is a single value.

const numbersArr = [1, 2, 3, 4];
// 0 + 1 + 2 + 3 + 4
const initialValue = 0;
const sumWithInitial = numbersArr.reduce(
  (previousValue, currentValue) => previousValue + currentValue,
  initialValue
);
console.log(sumWithInitial); // expected output: 10








