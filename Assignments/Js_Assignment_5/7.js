class Animal {
  makeSound() {
    console.log("The animal makes a sound");
  }
}
class Dog extends Animal {
  makeSound() {
    console.log("Dog says: Woof Woof!");
  }
}
class Cat extends Animal {
  makeSound() {
    console.log("Cat says: Meow!");
  }
}
class Cow extends Animal {
  makeSound() {
    console.log("Cow says: Moo!");
  }
}
let animals = [new Dog(), new Cat(), new Cow()];
animals.forEach(a => a.makeSound());