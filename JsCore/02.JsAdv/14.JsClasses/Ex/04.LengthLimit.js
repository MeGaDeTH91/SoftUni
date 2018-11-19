class Stringer{
    constructor(str, length){
        this.initialString = str;
        this.innerString = str;
        this.innerLength = length;
    }
    increase(length){
        this.innerLength += length;

        let endOfStr = Math.min(this.innerLength, this.initialString.length);

        if(this.innerLength === this.initialString.length){
            this.innerString = this.initialString;
        } else{
            this.innerString = this.initialString.substr(0, endOfStr) + "...";
        }

    }
    decrease(length){
        if(this.innerLength - length < 0){
            this.innerLength = 0;
        } else{
            this.innerLength -= length;
        }
        let initStrLength = this.initialString.length;
        let strLength = this.initialString.length;

        if(initStrLength === this.innerLength ){
            this.innerString = this.initialString;
            return this.innerString;
        } else if(this.innerLength < initStrLength){
            this.innerString =  this.initialString.substr(0, this.innerLength) + '...';
            return this.innerString;
        } else if(this.innerLength > initStrLength){
            this.innerString = this.initialString + "...";
        } else {
            return this.initialString.substr(0, this.innerLength);
        }
    }
    toString(){
        return this.innerString;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...

test.decrease(5);
console.log(test.toString()); //...
