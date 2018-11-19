(function sortedList(){
    let sortingPattern = (a, b) => a - b;

    return class SortedList{
        constructor(){
            this.arr = [];
            this.size = 0;
        }
        add(element){

            this.arr.push(element);
            this.arr.sort(sortingPattern);
            this.size++;
        };
        remove(index){
            if(this.arr.length > 0 && index >= 0 && index < this.arr.length){
                this.arr.splice(index, 1);
                this.arr.sort(sortingPattern);
                this.size--;
            }
        };
        get(index){
            if(index >= 0 && index < this.arr.length){
                return this.arr[index];
            }
        };
    }
})()
let sorted = sortedList();

for (let i = 0; i < 10; i++) {
    sorted.add(i);
}
console.log(sorted.size);