function sortedList(){
    let obj = (() => {
        let arr = [];
        let sortingPattern = (a, b) => a - b;

        let add = function(element){
            
            arr.push(element);
            arr.sort(sortingPattern);
            this.size++;
        }
        let remove = function(index){
            if(arr.length > 0 && index >= 0 && index < arr.length){
                arr.splice(index, 1);
                arr.sort(sortingPattern);
                this.size--;
            }
        }
        let get = function(index){
            if(index >= 0 && index < arr.length){
                return arr[index];
            }
        }
        let size = 0;

        return {add, remove, get, size};
    })()

    return obj;
}
let sorted = sortedList();

for (let i = 0; i < 10; i++) {
    sorted.add(i);
}
console.log(sorted.size);