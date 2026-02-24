let numbers = [10, 20, 30, 10, 40, 20, 50, 60, 60];
const uniqueNumbers = [...new Set(numbers)];
console.log("1. Unique Numbers:", uniqueNumbers);
const secondLargest = [...uniqueNumbers].sort((a, b) => b - a)[1];
console.log("2. Second Largest:", secondLargest);
const frequency = numbers.reduce((acc, num) => {
    acc[num] = (acc[num] || 0) + 1;
    return acc;
}, {});
console.log("3. Frequency:", frequency);
const firstNonRepeating = numbers.find(num => frequency[num] === 1);
console.log("4. First Non-Repeating:", firstNonRepeating);
const rotated = numbers.slice(2).concat(numbers.slice(0, 2));
console.log("5. Rotated Array (2 positions):", rotated);
const nested = [1, 2, [3, 4, [5]]];
const flattened = nested.flat(Infinity);
console.log("6. Flattened Array:", flattened);
const sequence = [1, 2, 3, 5, 6];
const findMissing = (arr) => {
    const n = arr[arr.length - 1];
    const expectedSum = (n * (n + 1)) / 2;
    const actualSum = arr.reduce((a, b) => a + b, 0);
    return expectedSum - actualSum;
};
console.log("7. Missing Number:", findMissing(sequence));